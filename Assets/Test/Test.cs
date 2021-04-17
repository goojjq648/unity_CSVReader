using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.GameData.Base;
using Common.GameData.data;

public class Test : BaseObject
{
    // Start is called before the first frame update

    public void TestObject()
    {
        var data = GameDataManager.Instance.GetData<CatchDataClass.CatchData>(2);
        var dataA = GameDataManager.Instance.GetData<CatchDataClass.CatchData>(3);
        Debug.Log(data.catch_prob);
        Debug.Log(dataA.common);
    }

}
