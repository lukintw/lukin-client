using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using UnityEngine;

public class location : MonoBehaviour
{
    [SerializeField]
    public AbstractMap mapManager;
    private static location _instance;
    public static location Instance
    {
        get
        {
            return _instance;
        }

        private set
        {
            _instance = value;
        }
    }
    ILocationProvider _defaultLocationProvider;
    public ILocationProvider DefaultLocationProvider
    {
        get
        {
            return _defaultLocationProvider;
        }
        set
        {
            _defaultLocationProvider = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
