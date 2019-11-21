using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarReset : MonoBehaviour
{
    public float ScrollbarStartPos = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Scrollbar>().value = ScrollbarStartPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
