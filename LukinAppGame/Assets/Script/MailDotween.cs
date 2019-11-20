using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MailDotween : MonoBehaviour
{
    // Dotween移動目標位置
    private Vector3 targetPos;
    [SerializeField]
    private Transform _mailboxPos;

    // Dotween移動速度
    [Range(0.0f, 3.0f), SerializeField]
    private float _moveduration = 0.1f;

    bool click = false;

    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
        transform.localPosition = _mailboxPos.localPosition;
        transform.localScale = new Vector3(0, 0, 0);
        Tweener mailMove = transform.DOMove(targetPos, _moveduration);
        Tweener mailScale = transform.DOScale(new Vector3(1, 1, 1), _moveduration);
        mailMove.SetAutoKill(false);
        mailScale.SetAutoKill(false);
        mailMove.Pause();
        mailScale.Pause();
    }

    // Update is called once per frame
    public void Buttontouch()
    {
        if (click = !click)
        {
            transform.DOPlayForward();
        }
        else
        {
            transform.DOPlayBackwards();
        }
    }
}
