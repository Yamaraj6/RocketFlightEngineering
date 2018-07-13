using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DataContainer
{
    public interface IContainer<TData>
    {
        TData Data { get; set; }

    }

    public class Container<TData> : IContainer<TData> where TData : class
    {
        private readonly string _applicationPersistenDataPath;
        private readonly string _fileName;
        private TData _data;
        public TData Data
        {
            get => _data;
            set
            {
                _data = value;
                SaveData();
            }
        }

        public Container()
        {
            _applicationPersistenDataPath = Application.persistentDataPath + Data.GetType().Name + "data.json";
            _fileName = Data.GetType().Name + "data.json";
            Debug.Log(_applicationPersistenDataPath + _fileName);
            LoadData();
        }

        private void LoadData()
        {
            var path = $@"{_applicationPersistenDataPath}\{_fileName}";
            Debug.Log(path);
            if (!File.Exists(_applicationPersistenDataPath))
            {
                var jsonAsset = Resources.Load(_fileName.Replace(".json", "")) as TextAsset;
                if (jsonAsset == null)
                {
                    File.WriteAllText(_applicationPersistenDataPath, JsonConvert.SerializeObject(Data));
                }
                else
                {
                    var jsonContent = jsonAsset?.text;
                    File.WriteAllText(_applicationPersistenDataPath, jsonContent);
                }
            }

            var jsonData = File.ReadAllText(_applicationPersistenDataPath);
            _data = JsonConvert.DeserializeObject<TData>(jsonData);

        }

        private void SaveData()
        {
            File.WriteAllText(_applicationPersistenDataPath, JsonConvert.SerializeObject(_data));
        }

    }
}
