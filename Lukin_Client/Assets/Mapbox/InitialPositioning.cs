using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPositioning : MonoBehaviour
{
    private static InitialPositioning _instance;
    public static InitialPositioning Instance{
        get{
            return _instance;
        }
        private set{
            _instance = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(!Instance){
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
