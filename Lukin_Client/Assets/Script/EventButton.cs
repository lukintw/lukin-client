using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void touch(string name){
        GameLoop.Instance._nextSceneState = (Global.SceneState)Enum.Parse(typeof(Global.SceneState), name);
    }
}
