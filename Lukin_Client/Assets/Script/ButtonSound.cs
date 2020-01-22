using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip clip = null;
    void Start()
    {
        if(!clip)
            clip = SoundManager.Instance.Sound[0];
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ButtonSoundPlay);
    }
    // 切換場景
    public void ButtonSoundPlay(){
        if(!SoundManager.Instance)return;
        SoundManager.Instance.Play(clip);
    }
}
