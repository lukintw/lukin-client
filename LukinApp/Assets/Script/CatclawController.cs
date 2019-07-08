using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatclawController : MonoBehaviour {

	[SerializeField]
	private GameObject mask;
	[SerializeField]
	private GameObject[] catclaw;
	private bool click = false;

	// Update is called once per frame
	public void menuclick () {
		click = !click;
		mask.GetComponent<MaskDoTween>().masktween(click);
		foreach (var claw in catclaw)
		{
			claw.GetComponent<buttondotweentest>().Buttontouch(click);
		}
	}

}
