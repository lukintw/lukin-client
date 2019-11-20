using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MenuDotween : MonoBehaviour
{
    // Dotween移動目標位置
    private Vector3 targetPos;

    // Dotween移動速度
    [Range(0.0f, 3.0f), SerializeField]
    private float _moveduration = 0.25f;

    // Dotween移動方式
    public Ease _moveEase;

    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
        transform.position = this.transform.parent.position;
        Tweener tweenbutton = transform.DOMove(targetPos, _moveduration).SetEase(_moveEase);
        tweenbutton.SetAutoKill(false);
        tweenbutton.Pause();
    }

    // Update is called once per frame
    public void Buttontouch(bool click)
    {
        if (click)
        {
            transform.DOPlayForward();
        }
        else
        {
            transform.DOPlayBackwards();
        }

    }
}
