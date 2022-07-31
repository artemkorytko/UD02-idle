using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;




namespace MyNamespace
{
    public class SaveSystem : MonoBehaviour
    {
        private string _savePath;

        private void Awake()
        {
            _savePath = Application.persistentDataPath + "gameData.txt";
        }
        
        public void SaveData(GameData gameData)
        {
            FileStream dataStream = new FileStream(_savePath, FileMode.OpenOrCreate); //тектсовый документ
            //создаём форматор бинарного кода:
            BinaryFormatter formatter = new BinaryFormatter();
            //он знает как сериализовать текст
            formatter.Serialize(dataStream, gameData);
            //сохранили в текстовый документ дату
            dataStream.Close();
            print("всё сохранили");
        }

        
        public GameData LoadData() 
        {
            // if (File.Exists(_savePath))
            // {
            //     print("зашли в существующее сохранение");
            //     //здесь же надо дату загрузить в игру ( десериализовать )
            //     FileStream dataStream = new FileStream(_savePath, FileMode.Open);
            //     BinaryFormatter formatter = new BinaryFormatter();
            //     // десериализуем и неявно преобразовываем дату в gameData
            //     GameData data = formatter.Deserialize(dataStream) as GameData;
            //     dataStream.Close();
            //     return data;
            // }
            // else
            // {
                return new GameData();
            //}
        }
    }

    
    

    //Serializable - атрибут позволяющий нам записать класс в бинарник
    [Serializable] public class GameData
    {
        //задел под drag and drop строительство
        public int countOfBuildings = 4;
        public int money = 60;             //
        public List<PointData> PointData;

        public GameData()  //конструктор                                          
        {
            
            PointData = new List<PointData>();
            for (int i = 0; i < countOfBuildings; i++)
            {
                PointData.Add(new PointData());
            }
        }
        public GameData(int countOfBuildings, int money, List<PointData> pointData)
        {
            this.countOfBuildings = countOfBuildings;
            this.money = money;
            PointData = pointData;
        }
    }

    
    
  
    [Serializable] public class PointData
    {
        public readonly int Money;
        public readonly int UpgradeLevel;
        public readonly bool IsUnlocked = false;

        public PointData()  //всё стоковое
        {
            IsUnlocked = false;
            UpgradeLevel = 0;
            Money = 60;
        }
        public PointData(bool isUnlocked, int money, int upgradeLevel)
        {
            IsUnlocked = isUnlocked;
            Money = money;
            UpgradeLevel = upgradeLevel;
        }
    }
}