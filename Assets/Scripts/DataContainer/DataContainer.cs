using System.Collections.Generic;
using System.IO;
using Models;
using Newtonsoft.Json;
using UnityEngine;

namespace DataContainer
{
    public interface IContainer<TData>
    {
        TData Data { get; set; }
        void SaveData();
    }

    public class Container<TData> : IContainer<TData> where TData : class
    {
        private readonly string _applicationPersistenDataPath;
        private readonly string _fileName;
        public TData Data { get; set; }


        public Container()
        {
            _applicationPersistenDataPath = Application.persistentDataPath+ "/" + typeof(TData).Name + "data.json";
            _fileName = typeof(TData).Name + "data.json";
            Debug.Log("Your files are located at: _applicationPersistenDataPath");
            LoadData();
        }

        private void LoadData()
        {
            if (!File.Exists(_applicationPersistenDataPath))
            {
                var jsonAsset = Resources.Load(_fileName.Replace(".json", "")) as TextAsset;
                var jsonContent = jsonAsset?.text;
                File.WriteAllText(_applicationPersistenDataPath, jsonContent);

            }




            var jsonData = File.ReadAllText(_applicationPersistenDataPath);
            Data = JsonConvert.DeserializeObject<TData>(jsonData);

        }

        public void SaveData()
        {
            File.WriteAllText(_applicationPersistenDataPath, JsonConvert.SerializeObject(Data));
        }

    }
}

