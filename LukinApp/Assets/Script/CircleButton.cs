using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
        Image image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 0.1f;
	}
	
}
