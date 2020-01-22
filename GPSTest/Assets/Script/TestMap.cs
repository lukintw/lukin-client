using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Map;
using UnityEngine;
using UnityEngine.UI;

public class TestMap : MonoBehaviour
{
    public bool windowTest = true;
    private static TestMap _instance;
    public static TestMap Instance
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

    [SerializeField]
    private AbstractMap _abstractmap;

    [SerializeField]
    private Text _text;

    [SerializeField]
    public float testlat = 25.0808f;
    [SerializeField]
    public float testlon = 121.4797f;

    private float test = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        Input.location.Start(10.0f, 10.0f);

        if (windowTest)
        {
            _abstractmap.Options.locationOptions.zoom = 16;
            _abstractmap.Options.locationOptions.latitudeLongitude = testlat.ToString() + ',' + testlon.ToString();
        }
        else
        {
            testlat = Input.location.lastData.latitude;
            testlon = Input.location.lastData.longitude;
            _abstractmap.Options.locationOptions.zoom = 16;
            _abstractmap.Options.locationOptions.latitudeLongitude = Input.location.lastData.latitude.ToString() + ',' + Input.location.lastData.longitude.ToString();

        }
        StartCoroutine(StartGPS());
    }

    IEnumerator StartGPS()
    {
        if (windowTest)
        {
            _abstractmap.Options.locationOptions.latitudeLongitude = testlat.ToString() + ',' + testlon.ToString();
        }
        else
        {
            while (Input.location.status == LocationServiceStatus.Initializing)
            {

                _abstractmap.Options.locationOptions.latitudeLongitude = Input.location.lastData.latitude.ToString() + ',' + Input.location.lastData.longitude.ToString();

                // 暂停协同程序的执行(1秒)
                yield return new WaitForSeconds(0.5f);
            }
        }
        yield break;
    }

    private void Update()
    {
        if (windowTest)
        {

            _abstractmap.Options.locationOptions.latitudeLongitude = testlat.ToString() + ',' + testlon.ToString();
            _text.text = testlat.ToString() + ',' + testlon.ToString(); ;
        }
        else
        {
            testlat = Input.location.lastData.latitude;
            testlon = Input.location.lastData.longitude;
            if (Input.location.isEnabledByUser)
            {
                _text.text = testlat.ToString() + ',' + testlon.ToString(); ;
            }
            else
            {
                _text.text = "Error";
            }
        }


    }

}