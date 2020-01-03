using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject[] catclaw;
    private bool click = false;

    void Start()
    {
        
    }
    // Update is called once per frame
    public void menuclick()
    {
        click = !click;
        foreach (var claw in catclaw)
        {
            claw.GetComponent<MenuButtonDotween>().Buttontouch(click);
        }
    }
}
