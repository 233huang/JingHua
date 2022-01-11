using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class BaseDatebase
{
    public int ID;
}

public class ConfigTable<TDatebase,T> : Singleton<T> 
    where TDatebase:BaseDatebase,new()
    where T:new()
{
    //id，数据条目
    Dictionary<int, TDatebase> _cache = new Dictionary<int, TDatebase>();

    protected void LoadTable(string path)
    {
        var table = Resources.Load<TextAsset>(path);
        var tableStream = new MemoryStream(table.bytes);
        using (var reader = new StreamReader(tableStream, Encoding.GetEncoding("gb2312")))
        {

            reader.ReadLine();//跳过第一行

            var lineStr = reader.ReadLine();
            while (lineStr != null)
            {
                var itemStrArray = lineStr.Split(',');

                var LoadDB = new TDatebase();
                LoadDB.ID = int.Parse(itemStrArray[0]);

                ReadDate(LoadDB, itemStrArray);

                _cache[LoadDB.ID] = LoadDB;

                lineStr = reader.ReadLine();
            }
        }
    }

    public TDatebase this[int index]
    {
        get
        {
            TDatebase db;
            _cache.TryGetValue(index, out db);
            return db;
        }
    }

    public TDatebase GetData(int id)
    {
        TDatebase db;
        _cache.TryGetValue(id, out db);
        return db;
    }

    public Dictionary<int, TDatebase> GetAll()
    {
        return _cache;
    }


    protected virtual void ReadDate(TDatebase datebase,string[] itemStrArray)
    {

    }
}
