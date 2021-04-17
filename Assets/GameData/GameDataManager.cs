using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.GameData.Base;
using Common.GameData.data;

public class GameDataManager : InstanceBase<GameDataManager>
{
    private string _csvResourcesFilePath = "CSV_File/";
    private Dictionary<Type, object> _dataTable = new Dictionary<Type, object>();

    public override void StartUp()
    {
        MainLoadCSVFile();
    }

    //讀CSV檔案
    public void RegisteredCSVFile<TClass,TData>(string fileName)
        where TClass : DataMap<TData> , new()
    {
        TClass dataMap = new TClass();
        int id = 0;

        TextAsset _binAsset = Resources.Load(_csvResourcesFilePath + fileName, typeof(TextAsset)) as TextAsset;
        string[] _lineData = _binAsset.text.Split('\n');
        for (int i = 1; i < _lineData.Length; i++)
        {
            string[] _data = _lineData[i].Split(',');
            List<string> _savedata = new List<string>();
            for (int j = 0; j < _data.Length; j++)
            {
                //第一個一定是ID
                if (j == 0)
                {
                    Int32.TryParse(_data[j], out id);
                }
                else
                {
                    _savedata.Add(_data[j]);
                }
            }

            if (id > 0)
            {
                dataMap.SetDataList(id, _savedata);
            }
        }
        _dataTable.Add(typeof(TData), dataMap);
    }

    //主要放要load的CSV檔案RegisteredCSVFile<要對應的資料class>(檔案名稱)
    public void MainLoadCSVFile()
    {
        RegisteredCSVFile<CatchDataClass.CatchDataTable, CatchDataClass.CatchData>("catch");
    }

    //var data = GetData<CatchDataClass.CatchData>(ID); => example
    public TData GetData<TData>(int id)
        where TData : struct
    {
        object datas;
        if (_dataTable.TryGetValue(typeof(TData), out datas))
        {
            var dataTable = datas as DataMap<TData>;
            var data = dataTable.GetData(id);
            return data;
        }
        return default(TData);
    }
}
