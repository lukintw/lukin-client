using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class buttondotweentest : MonoBehaviour {

	[SerializeField]
	private bool click = false;

	private Vector2 targetPos;

	[Range(0.0f,10.0f), SerializeField]
	private float _moveduration = 1f;
	[SerializeField]
	private Ease _moveEase;

	// Use this for initialization
	void Start () {
		targetPos = transform.position;
		transform.position = this.transform.parent.position;
		Tweener tweenbutton = transform.DOMove(targetPos,_moveduration).SetEase(_moveEase);
        tweenbutton.SetAutoKill(false);
        tweenbutton.Pause();  
	}
	
	// Update is called once per frame
	public void Buttontouch () {
			if(click = !click){
				transform.DOPlayForward();
			}
			else{
				transform.DOPlayBackwards();

			}
	}
}
