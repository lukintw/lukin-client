using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonEvent : MonoBehaviour
{
    public Global.SceneState NextScene = Global.SceneState.GameLoop;
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeScene);
    }
    // 切換場景
    public void ChangeScene(){
        GameLoop.Instance._nextSceneState = NextScene;
    }
}
