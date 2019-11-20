using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{

    [SerializeField]
    private Transform _target;      //跟隨目標
                                    // 默认距离
    private const float default_distance = 5f;

    // 计算移动
    private Vector3 position;
    // 计算旋转
    private Quaternion rotation;
    Vector2 finger1;

    // Use this for initialization
    void Start()
    {
        // 旋转归零
        transform.rotation = Quaternion.identity;
        // 初始位置是模型
        position = _target.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount <= 0)
            return;

        if (Input.touchCount == 1)
        {

            if (Input.touches[0].phase == TouchPhase.Began)
                finger1 = Input.touches[0].position;
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                var rot = (Input.touches[0].position.x - finger1.x);
                finger1 = Input.touches[0].position;

                // 获取摄像机欧拉角
                Vector3 angles = transform.rotation.eulerAngles;
                // 欧拉角表示按照坐标顺序旋转，比如angles.x=30，表示按x轴旋转30°，dy改变引起x轴的变化
                angles.y = Mathf.Repeat(angles.x + 180f, 360f) - 180f;
                angles.y += rot;
                // 计算摄像头旋转
                rotation.eulerAngles += new Vector3(0, angles.y, 0);


            }
        }



    }

    private void FixedUpdate()
    {
        // 设置摄像头旋转
        transform.rotation = rotation;
        // 设置摄像头位置
        transform.position = position - rotation * new Vector3(0, 0, default_distance);
    }





    // [SerializeField]
    // private Transform _target;      //跟隨目標

    // [SerializeField]
    // private Transform _camera;       //底下的camera
    // [SerializeField]
    // private Vector2 m_screenPos = new Vector2();


    // public Vector2 finger1 = new Vector2();
    // public Vector2 finger2 = new Vector2();

    // public float first_distance = 0f;
    // public float now_distance = 0f;

    // public float distance = 0f;

    // public float minDistance = 2f;
    // public float maxDistance = 10f;




    // private void Start()
    // {
    //     if (!_target)
    //         _target = GameObject.FindGameObjectWithTag("LookPoint").transform;
    //     if (!_camera)
    //         _camera = Camera.main.transform;
    //     Input.multiTouchEnabled = true;

    // }

    // void Update()
    // {
    //     MobileInput();
    // }

    // void MobileInput()
    // {
    //     if (Input.touchCount <= 0)
    //         return;

    //     if (Input.touches[0].phase == TouchPhase.Began)
    //         finger1 = Input.touches[0].position;

    //     //1個手指觸碰螢幕
    //     if (Input.touchCount == 1)
    //     {
    //         if (Input.touches[0].phase == TouchPhase.Ended)
    //             return;

    //         if (Input.touches[0].phase == TouchPhase.Moved)
    //         {
    //             //旋轉target
    //             _target.transform.Rotate(new Vector3(0, -Input.touches[0].deltaPosition.x, 0));
    //         }
    //         return;
    //     }

    //     if (Input.touches[1].phase == TouchPhase.Began)
    //     {
    //         finger2 = Input.touches[1].position;
    //         first_distance = Vector2.Distance(finger1, finger2);
    //     }

    //     //攝影機縮放，如果2個手指觸碰螢幕
    //     if (Input.touchCount == 2)
    //     {
    //         if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[1].phase == TouchPhase.Ended)
    //             return;
    //         if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved)
    //         {
    //             now_distance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
    //             distance = now_distance - first_distance;
    //             Camera.main.transform.position += Camera.main.transform.position.normalized * distance;
    //         }

    //         //記錄兩個手指位置
    //         // Vector2 finger1 = new Vector2();
    //         // Vector2 finger2 = new Vector2();

    //         // //記錄兩個手指移動距離
    //         // Vector2 move1 = new Vector2();
    //         // Vector2 move2 = new Vector2();

    //         // //是否是小於2點觸碰
    //         // for (int i = 0; i < 2; i++)
    //         // {
    //         //     UnityEngine.Touch touch = UnityEngine.Input.touches[i];

    //         //     if (touch.phase == TouchPhase.Ended)
    //         //         break;

    //         //     if (touch.phase == TouchPhase.Moved)
    //         //     {





    //         //         // //每次都重置
    //         //         // float move = 0;

    //         //         // //觸碰一點
    //         //         // if (i == 0)
    //         //         // {
    //         //         //     finger1 = touch.position;
    //         //         //     move1 = touch.deltaPosition;

    //         //         // }
    //         //         // else      //另一點
    //         //         // {
    //         //         //     finger2 = touch.position;
    //         //         //     move2 = touch.deltaPosition;

    //         //         //     //取最大X
    //         //         //     if (finger1.x > finger2.x)
    //         //         //     {
    //         //         //         move = move1.x;
    //         //         //     }
    //         //         //     else
    //         //         //     {
    //         //         //         move = move2.x;
    //         //         //     }

    //         //         //     //取最大Y，並與取出的X累加
    //         //         //     if (finger1.y > finger2.y)
    //         //         //     {
    //         //         //         move += move1.y;
    //         //         //     }
    //         //         //     else
    //         //         //     {
    //         //         //         move += move2.y;
    //         //         //     }

    //         //         //     if (Camera.main.transform.position.y + move < 25 && Camera.main.transform.position.y + move > 5)
    //         //         //         //當兩指距離越遠，Z位置加的越多，相反之
    //         //         //         Camera.main.transform.Translate(0, 0, move);
    //         //         // }
    //         //     }
    //         // }//end for
    //     }//end else if
    // }//end void
}
