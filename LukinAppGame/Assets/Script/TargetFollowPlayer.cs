using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform _target;      //跟隨目標

    [SerializeField]
    [Range(0f, 5f)]
    private float Radius;           //跟隨目標距離

    [SerializeField]
    [Range(0f, 5f)]
    private float Smooth;           //平滑速度

    private Vector3 smoothPosition = Vector3.zero;  //本身位置

    // Use this for initialization
    private void Start()
    {
        if (!_target)
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.parent = null;
        transform.position = _target.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (CheckMargin())      //檢查距離是否大於跟隨距離
        {
            smoothPosition.x = Mathf.Lerp(transform.position.x, _target.position.x, Smooth * Time.deltaTime);
            smoothPosition.y = Mathf.Lerp(transform.position.y, _target.position.y, Smooth * Time.deltaTime);
            smoothPosition.z = Mathf.Lerp(transform.position.z, _target.position.z, Smooth * Time.deltaTime);
            transform.position = smoothPosition;
        }
    }

    private bool CheckMargin()          //檢查距離是否大於跟隨距離
    {
        return Vector3.Distance(transform.position, _target.position) > Radius;
    }
}
