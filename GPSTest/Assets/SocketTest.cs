using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SocketTest : MonoBehaviour
{
    public string url = "http://18.222.92.89/api/home";
    public string url2 = "http://18.222.92.89/api/friends";
    public string url3 = "http://18.222.92.89/api/datum/update_data";
    public string url4 = "http://18.222.92.89/api/pets/{pet_id}";
    // http://18.222.92.89/api/home
    // http://18.222.92.89/api/friends 建立好友 ( POST )
    // http://18.222.92.89/api/datum/update_data 更新玩家遊戲資料 ( POST )
    // http://18.222.92.89/api/pets/{pet_id} 更新寵物資料 ( POST )
    void Start()
    {

        // StartCoroutine(Upload(url));

        // StartCoroutine(Get(url));
        // StartCoroutine(Get(url2));
        // StartCoroutine(Get(url3));
        // StartCoroutine(Get(url4));
    }

    IEnumerator Get(string uri)
    {
        // json
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }



        // 圖片
        // using (WWW www = new WWW(url))
        // {
        //     yield return www;
        //     Renderer renderer = GetComponent<Renderer>();
        //     renderer.material.mainTexture = www.texture;
        // }
    }
    IEnumerator Upload(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", "test");
        UnityWebRequest request = UnityWebRequest.Post(uri, form);
        yield return request.SendWebRequest();
        Debug.Log(request.error);
        Debug.Log(request.responseCode);
        Debug.Log(request.downloadHandler.text);

    }
}
