using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    // public enum SceneState { GameLoop, LoginPage, MainPage, MapPage  };
    private Global.SceneState _nowSceneState = Global.SceneState.GameLoop;
    public Global.SceneState _nextSceneState = Global.SceneState.GameLoop;
    private static GameLoop _instance = null;
    public static GameLoop Instance
    {
        get
        {
            return _instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this.gameObject);

        // 初始化
        DontDestroyOnLoad(this.gameObject);

        // 判斷手機內部是否有儲存的遊戲帳戶資料

        // 如果有 呼叫登入API 直接進入Main
        // _nextSceneState = SceneState.Main;

        // 如果沒有 or 錯誤   update 等待切換場景登入
        _nextSceneState = Global.SceneState.LoginPage;

    }

    // Update is called once per frame
    void Update()
    {
        // 玩家輸入?
        // api?
        // 畫面更新?
        // 場景更新
        if(_nowSceneState != _nextSceneState){
            _nowSceneState = _nextSceneState;
            SceneManager.LoadScene(_nextSceneState.ToString());
            MusicManager.Instance.ChangeMusic(_nextSceneState);
            // SceneChange(_nextSceneState.ToString());
        }
    }

    // private void SceneChange(string name)
    // {
    //     SceneManager.LoadScene(name);
    // }
}
