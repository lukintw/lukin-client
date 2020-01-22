using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance = null;
    public static MusicManager Instance
    {
        get
        {
            return _instance;
        }
    }
    public AudioClip[] BGMusic;
    private AudioSource _Audio = null;
    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this.gameObject);

        // 初始化
        GameObject.DontDestroyOnLoad(this.gameObject);
        _Audio = GetComponent<AudioSource>();
        _Audio.loop = true;
        _Audio.Stop();
    }

    // Update is called once per frame
    public void ChangeMusic(Global.SceneState music)
    {
        _Audio.clip = BGMusic[(int)music];
        _Audio.Play();
    }
}
