using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
   [SerializeField] private UpgradeBuilding[] buildings;

   public void Initialize(GameData gameData)
   {
    //если нет данных в gameData._BuildingData возвращаем пустой
    if (gameData._BuildingData == null) return;
    //если есть, создаём массив, чтобы перебрать дату
    var data = gameData._BuildingData;
    //перебор зданий, раздаём data  , если даты меньше, чем зданий, break and exit
     for (int i = 0; i < buildings.Length; i++)
            {
                if (i >= data.Count) break;

                buildings[i].Initialize(data[i]);
            }

   }

//получаем дату
   public List<GameData.BuildingData> GetBuildingData()
   {
        var list  = new List<GameData.BuildingData>();
        for (int i = 0; i < buildings.Length; i++)
        {
            list.Add(new GameData.BuildingData(buildings[i].IsUnLook, buildings[i].CurrentLevel));
        }
        return list;
   }
}
