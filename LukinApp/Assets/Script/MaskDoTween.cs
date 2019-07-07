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
	private bool click = false;
	// Use this for initialization
	void Start () {
		
		Tweener tweenpanel = this.transform.GetComponent<Image>().DOFade(_fadenumber,_fadeduration);
	    tweenpanel.SetAutoKill(false);
        tweenpanel.Pause();  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void masktween(){
		
			if(click = !click){
				this.transform.GetComponent<Image>().DOPlayForward();
			}
			else{
				this.transform.GetComponent<Image>().DOPlayBackwards();
			}
			this.transform.GetComponent<Image>().raycastTarget = click;
	}
}
