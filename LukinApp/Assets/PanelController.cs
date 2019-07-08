using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelController : MonoBehaviour {

	[SerializeField]
	private Transform[] _panelName;

	[Range(0.0f,10.0f), SerializeField]
	private float _moveduration = 1f;

	[SerializeField]
	private Ease _moveEase;

	// Use this for initialization
	void Start () {
		foreach(Transform _panel in _panelName){
			if(_panel != null){
				_panel.localScale = new Vector3(0,0,0);
				Tweener tweenPanel = _panel.DOScale(new Vector3(1,1,1),_moveduration).SetEase(_moveEase);
				tweenPanel.SetAutoKill(false);
				tweenPanel.Pause();  
			}
		}
	}
	
	// Update is called once per frame
	public void panelOpen (int panelID) {
		foreach(Transform _panel in _panelName)
			if(_panel != null)
				_panel.DOPlayBackwards();
		if(panelID != 0){
			_panelName[panelID].SetSiblingIndex(_panelName.Length -1);
			_panelName[panelID].DOPlayForward();
		}
		
	}
}
