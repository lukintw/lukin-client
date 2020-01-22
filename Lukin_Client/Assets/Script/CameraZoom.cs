using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float minDistance = 20f;
    public float maxDistance = 100f;
    public float wheelSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            camerazoom();
    }
    // Camera視角滾輪縮放
    private void camerazoom()
    {
        if (Vector3.Distance(transform.position, transform.parent.position) >= minDistance)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                transform.Translate(Vector3.forward * wheelSpeed);
        }
        if (Vector3.Distance(transform.position, transform.parent.position) <= maxDistance)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
                transform.Translate(Vector3.forward * -wheelSpeed);
        }

    }
}
