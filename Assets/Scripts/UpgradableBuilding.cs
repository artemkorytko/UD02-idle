using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class UpgradableBuilding : MonoBehaviour
{
    [SerializeField] private UpgradableBuildingConfig _config = null;
    [SerializeField] private Transform _modelsContainer = null;
    [SerializeField] private Canvas _canvas = null;
    [SerializeField] private BuildingButtonController _button = null;

    public bool IsUnlock { get; private set; } = false;
    public int Level => _currentLevel;
    public System.Action<int> OnProcessFinished = null;

    private int _currentLevel = -1;
    private GameObject _currentModel = null;
    private Coroutine _timer = null;

    public void Initialize(bool isUnlock, int upgradeLevel = -1)
    {
        IsUnlock = isUnlock;
        _currentLevel = upgradeLevel;
        _canvas.worldCamera = Camera.main;

        if (IsUnlock && _currentLevel >= 0) SetModel(_currentLevel);
        UpdateButtonState();
        GameManager.Instance.OnMoneyValueChange += _button.OnMoneyValueChanged;
    }

    public void Upgrade()
    {
        if (!IsUnlock)
        {
            IsUnlock = true;
            UpdateButtonState();
            GameManager.Instance.Money -= _config.UnlockPrice;
            return;
        }

        if (_config.IsUpgradeExist(_currentLevel + 1))
        {
            _currentLevel++;
            GameManager.Instance.Money -= GetCost(_currentLevel);
            StartCoroutine(SetModel(_currentLevel));
            UpdateButtonState();
        }
    }

    private IEnumerator SetModel(int level)
    {
        UpgradeConfig upgradeConfig = _config.GetUpgrade(level);

        if (_currentModel != null)
        {
            Addressables.ReleaseInstance(_currentModel);
        }

        AsyncOperationHandle<GameObject> handler = Addressables.InstantiateAsync(upgradeConfig.Model, _modelsContainer);
        
        yield return handler;
        _currentModel = handler.Result;
        _currentModel.transform.localPosition = Vector3.zero;

        if (_timer == null)
        {
            _timer = StartCoroutine(Timer());
        }
    }

    private void UpdateButtonState()
    {
        if (!IsUnlock)
        {
            _button.UpdateButton("BUY", _config.UnlockPrice);
            return;
        }

        if (_config.IsUpgradeExist(_currentLevel + 1))
        {
            _button.UpdateButton("UPGRADE", GetCost(_currentLevel + 1));
        }
        else
        {
            _button.gameObject.SetActive(false);
        }
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            OnProcessFinished?.Invoke(_config.GetUpgrade(_currentLevel).ProcessResuilt);
        }
    }

    private float GetCost(int level)
    {
        return (float) System.Math.Round(_config.StartUpgeadeCost * Mathf.Pow(_config.Multiplier, level), 2);
    }
}