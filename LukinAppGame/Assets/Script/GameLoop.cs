using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    public enum SceneState { Loop, Login, Main };
    private SceneState _nowSceneState = SceneState.Loop;
    public SceneState _nextSceneState = SceneState.Loop;
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
        Object.DontDestroyOnLoad(this.gameObject);

        // 判斷手機內部是否有儲存的遊戲帳戶資料

        // 如果有 呼叫登入API 直接進入Main
        // _nextSceneState = SceneState.Main;

        // 如果沒有 or 錯誤   update 等待切換場景登入
        _nextSceneState = SceneState.Login;

    }

    // Update is called once per frame
    void Update()
    {
        // 玩家輸入?
        // api?
        // 畫面更新?
        // 場景更新
        if (_nowSceneState != _nextSceneState)
        {
            string name = "";
            if (_nextSceneState == SceneState.Login)
                name = "Login";
            else if (_nextSceneState == SceneState.Main)
                name = "Main";
            _nextSceneState = SceneState.Login;
            SceneChange(name);
        }
    }

    private void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
    }
}
