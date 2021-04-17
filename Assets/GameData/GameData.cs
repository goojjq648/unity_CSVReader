using System;
using System.Collections;
using System.Collections.Generic;
using Common.GameData.Base;

namespace Common.GameData.data
{
    public static class CatchDataClass
    {
        public struct CatchData
        {
            public int monster_id;
            public int catch_prob;
            public string common;

            public void Init()
            {
                monster_id = 0;
                catch_prob = 0;
                common = "";
            }
        };

        public class CatchDataTable :DataMap<CatchData>
        {
            public override void SetDataList(int id, List<string> data)
            {
                CatchData _data = new CatchData();
                _data.Init();
                
                //照著data idx順序塞入資料
                Int32.TryParse(data[0], out _data.monster_id);
                Int32.TryParse(data[1], out _data.catch_prob);
                _data.common = data[2];

                base.GameDataMap.Add(id, _data);
            }
        }

    }
}
