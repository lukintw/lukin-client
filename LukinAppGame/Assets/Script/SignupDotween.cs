using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SignupDotween : MonoBehaviour
{
    // Dotween移動速度
    [Range(0.0f, 3.0f), SerializeField]
    private float _moveduration = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        Tweener tweenbutton = transform.DOMove(this.transform.parent.position, _moveduration);
        tweenbutton.SetAutoKill(false);
        tweenbutton.Pause();
    }

    // Update is called once per frame
    public void touch(bool click)
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
