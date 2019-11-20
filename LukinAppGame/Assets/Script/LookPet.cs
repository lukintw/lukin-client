using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPet : MonoBehaviour
{
    [SerializeField]
    private GameObject _petTarget = null;

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(_petTarget.transform.position);
    }
}
