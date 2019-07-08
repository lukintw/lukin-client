using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MaskDoTween : MonoBehaviour {

	[SerializeField]
	private float _fadenumber = 0.65f;
	
	[SerializeField]
	private float _fadeduration = 0.1f;
	// Use this for initialization
	void Start () {
		Tweener tweenpanel = transform.GetComponent<Image>().DOFade(_fadenumber,_fadeduration);
	    tweenpanel.SetAutoKill(false);
        tweenpanel.Pause();  
	}
	
	public void masktween(bool click){
		
			if(click){
				transform.GetComponent<Image>().DOPlayForward();
			}
			else{
				transform.GetComponent<Image>().DOPlayBackwards();
			}
			transform.GetComponent<Image>().raycastTarget = click;
	}
}
