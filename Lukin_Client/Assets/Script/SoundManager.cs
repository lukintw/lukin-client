using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance = null;
    public static SoundManager Instance
    {
        get
        {
            return _instance;
        }
    }
    public AudioClip[] Sound;
    private AudioSource _Audio = null;
    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this.gameObject);

        // 初始化
        DontDestroyOnLoad(this.gameObject);
        _Audio = this.GetComponent<AudioSource>();
        _Audio.loop = false;
        _Audio.Stop();
    }

    // Update is called once per frame
    public void Play(AudioClip music)
    {
        if(!music) return;
        _Audio.clip = music;
        _Audio.Play();
    }

}
