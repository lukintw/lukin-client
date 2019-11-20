using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class GameDBA : MonoBehaviour
{
    private string url = "http://18.222.92.89/api/";
    private static GameDBA _instance = null;
    public static GameDBA Instance
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
    }
    // Update is called once per frame
    void Update()
    {
        // Global.player_id = "Test123";

    }


    // ===============================================
    // =====================GET=======================
    // =============================================== 
    // 測試
    public void Load_PlayerData()
    {
        string url_name = "PlayerData";
        WWWForm form = new WWWForm();
        form.AddField("player_id", "123456789");
        StartCoroutine(Get(url_name));

    }
    IEnumerator Get(string url_name)
    {
        UnityWebRequest request = UnityWebRequest.Get(url + url_name);
        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
            Debug.Log("Error : " + request.error);
        else
        {
            Debug.Log("Request : " + request.responseCode);
            Debug.Log("Request : " + request.downloadHandler.text);
        }
    }

    // ===============================================
    // =====================POST======================
    // ===============================================
    // 新增好友
    // http://18.222.92.89/api/friends 建立好友 ( POST )
    //      (required) player_id={id},
    //      (required) friend_id={id}
    public void ADD_Friends(string friend_id)
    {
        string url_name = "friends";
        WWWForm form = new WWWForm();
        form.AddField("player_id", "123456789");
        form.AddField("friend_id", "987654321");
        StartCoroutine(Post(url_name, form));
    }
    // 更新玩家遊戲資料
    // http://18.222.92.89/api/datum/update_data 更新玩家遊戲資料 ( POST )
    //      (required) player_id={id}
    //      data : {
    //          point :  3
    //          current_hp : 3
    //          current_pet : 1
    //          latitude : 15.5
    //          longitude : 16.7
    //      }
    public void Update_Data()
    {
        string url_name = "datum/update_data";
        WWWForm form = new WWWForm();
        form.AddField("player_id", "123456789");
        string datajson = "{\"point\":\"3\",\"current_hp\":\"3\" ,\"current_pet\":\"1\" ,\"latitude\":\"15.5\" ,\"longitude\":\"16.7\" }";
        form.AddField("data", datajson);
        StartCoroutine(Post(url_name, form));
    }




    // POST
    IEnumerator Post(string url_name, WWWForm form)
    {
        // WWW request = new WWW(url + url_name, form);
        UnityWebRequest request = UnityWebRequest.Post(url + url_name, form);
        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
            Debug.Log("Error : " + request.error);
        else
        {
            Debug.Log("Request : " + request.responseCode);
            Debug.Log("Request : " + request.downloadHandler.text);
        }
    }

    #region API資料分類
    public void apiDataCheck<T>(T data)
    {
        // 代寫......
    }
    #endregion

    #region Json檔案讀寫 
    // 讀取json資料 泛型
    // loadData = GameDBA.Instance.readJson<PlayerData>("PlayerLoginData");
    public T readJson<T>(string dataname)
    {
        string loadJson;
        try
        {
            StreamReader file = new StreamReader(System.IO.Path.Combine(Application.persistentDataPath, dataname));
            loadJson = file.ReadToEnd();
            file.Close();
        }
        catch (Exception e)
        {
            string filePath = dataname.Replace(".json", "");
            TextAsset file = Resources.Load<TextAsset>(filePath);
            loadJson = file.text;
        }
        return JsonUtility.FromJson<T>(loadJson);
    }

    // 寫入json資料 泛型
    // GameDBA.Instance.writeJson<PlayerData>(loadData, "PlayerLoginData");
    public void writeJson<T>(T data, string dataname)
    {
        StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.persistentDataPath, dataname));
        file.Write(JsonUtility.ToJson(data));
        file.Close();
    }

    #endregion

    // http://18.222.92.89/api/pets/{pet_id} 更新寵物資料 ( PUT )
    //      pet : {
    //          is_used: false,
    //          lv: 1
    //          equipment: ‘sword’,
    //          experience: 4.5
    //          go_time: 2018-01-01 18:00:00,
    //          back_time: 2018-01-01 18:00:00,
    //      }

    // http://18.222.92.89/api/chats/say_hello 和陌生人打招戶 ( POST )
    //      (required) player_id={id}
    //      (required) friend_id={id}


    //     核心機制:
    // 1. 使用者每次使用 App，都要到 FB 拿到 FB_id，並將 FB 打到 API 端點 '/api/home/auth'
    // 我會判斷，如果沒有這個 id，就會建立一個新 player，有的話，就回傳 id 和目前系統記錄的登入時間。

    // 2. 每次呼叫 API 時，都要將 fb_id 和登入 timestamp 做加密。
    // 我使用 HMAC-SHA256 加密，key 是登入 timestamp(毫秒)，data 是fb_id。加密後的文字儲存在 auth_token
    // 然後要在 header 設置如 -
    // fb_id: 100
    // timestamp: 1566490222000
    // auth_token: 6a3bf3c845a54633aa1ff7e65f7233cb2bd12365252eec7bc1adda828b040bba

    // 否則 status_code 會回 401

    // 可以自行試著加密，看能不能組出這個 token
    // 補充第一點，打過來 auth 的 fb_id 要先用 base_64 加密唷～
}
