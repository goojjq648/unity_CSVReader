using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.GameData.Base
{
    public class BaseObject : MonoBehaviour
    {
        public virtual void AwakeUp()
        {

        }
        public virtual void StartUp()
        {

        }
        public virtual void UpdateUp()
        {

        }
        public virtual void FixedUpdateUp()
        {

        }
    }

    public class InstanceBase<TClass> : BaseObject
        where TClass : class, new()
    {
        private static TClass _instance = null;
       
        public static TClass Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TClass();
                }
                return _instance;
            }
        }
    }

    public class DataMap<TData> 
    {
        public Dictionary<int, TData> GameDataMap;
        public int GetDataCount() { return GameDataMap.Count; }
        public virtual void SetDataList(int id, List<string> data) { }
        public DataMap()
        {
            GameDataMap = new Dictionary<int, TData>();
        }

        public TData GetData(int id)
        {
            TData data;
            if (GameDataMap.TryGetValue(id, out data))
            {
                return data;
            }

            return default(TData);
        }
    }
}
