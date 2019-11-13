using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class testTest1 : MonoBehaviour
{
    abstract public void upTest();

    public string testStr = "testStr";

    virtual public void Update()
    {
        upTest2();
        upTest3();
    }

    virtual public void upTest2()
    {
        if ( testStr != "" )
            Debug.Log("testTest1_upTest2.");
    }
    virtual public void upTest3()
    {
        if ( testStr != "" )
        {
            Debug.Log("testTest1_upTest3");
            Debug.Log(testStr);
            testStr = "";
        }
    }
}

public class testTest2 : testTest1
{
    override public void upTest()
    {
        Debug.Log("testTest2_upTest.");
    }
}
public class testTest3 : testTest2
{
    override public void upTest()
    {
        Debug.Log("testTest3_upTest.");
    }
    override public void upTest2()
    {
        if ( testStr != "" )
            Debug.Log("testTest3_upTest2.");
    }
    new public void upTest3()
    {
        if ( testStr != "" )
        {
            Debug.Log("testTest3_upTest3.");
            testStr = "";
        }
    }
}

public class test : testTest3
{

    // Start is called before the first frame update
    void Start()
    {
        upTest();
        upTest2();
        upTest3();
        testStr = "testStr";
    }

    // Update is called once per frame
    // new void Update()
    // {
        
    // }
}
