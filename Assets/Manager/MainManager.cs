using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.GameData.Base;
public class MainManager : InstanceBase<MainManager>
{
    public Test test = null;
    // Start is called before the first frame update
    void Start()
    {
        GameDataManager.Instance.StartUp();
        if (test)
        {
            test.TestObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
