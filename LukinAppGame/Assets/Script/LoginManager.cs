using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    // 用戶帳號密碼
    private PlayerData loadData = new PlayerData();
    // 用戶輸入手機號碼(帳號)
    public InputField account;
    // 用戶輸入密碼
    public InputField password;

    void Start()
    {
        // 判斷是否有用戶資料自動登入
        // autoLogin();
    }

    // 自動登入
    void autoLogin()
    {
        // 讀取登入json文件
        loadingJson();
        // 有資料先寫上格子
        account.text = loadData.account;
        password.text = loadData.password;

    }
    public void login()
    {
        // 呼叫api 
        // GameDBA.Instance.xxxxxxxxxxxxxx
        // 判斷

        // 登入 or 顯示有誤

        // test login
        SceneManager.LoadScene("Main");
    }






    // 讀取登入json文件
    void loadingJson()
    {
        // string loadJson;
        // try
        // {
        //     StreamReader file = new StreamReader(System.IO.Path.Combine(Application.persistentDataPath, "PlayerLoginData"));
        //     loadJson = file.ReadToEnd();
        //     file.Close();
        // }
        // catch (Exception e)
        // {
        //     Debug.Log(e.Data);
        //     string path = "PlayerLoginData";
        //     string filePath = path.Replace(".json", "");
        //     TextAsset file = Resources.Load<TextAsset>(filePath);
        //     loadJson = file.text;
        // }
        // loadData = JsonUtility.FromJson<PlayerData>(loadJson);
        loadData = GameDBA.Instance.readJson<PlayerData>("PlayerLoginData");

    }
    // 存取登入json文件
    void writingJson()
    {
        //測試
        GameDBA.Instance.writeJson<PlayerData>(loadData, "PlayerLoginData");

        // //將登入文件轉換成json格式
        // string saveString = JsonUtility.ToJson(loadData);
        // //將字串saveString存到硬碟中
        // StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.persistentDataPath, "PlayerLoginData"));
        // file.Write(saveString);
        // file.Close();
    }


}
