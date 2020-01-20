using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Location;
using Mapbox.Utils;
using UnityEngine;

public class PlayerGPS : MonoBehaviour
{
    bool _isInitialized;
    ILocationProvider _locationProvider;
    ILocationProvider LocationProvider
    {
        get
        {
            if (_locationProvider == null)
            {
                _locationProvider = location.Instance.DefaultLocationProvider;
            }

            return _locationProvider;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // location.Instance.mapManager.OnInitialized += () => { _isInitialized = true; };

    }

    // Update is called once per frame
    void Update()
    {
        var map = location.Instance.mapManager;
        transform.localPosition = map.GeoToWorldPosition(new Vector2d(TestMap.Instance.testlat, TestMap.Instance.testlon));

    }
}
