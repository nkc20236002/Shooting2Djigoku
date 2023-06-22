using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test02 : MonoBehaviour
{
    test01 t01;

    void Start()
    {
        t01 = GameObject.Find("Game01").GetComponent<test01>();
        t01.Score = 5;

        Debug.Log(t01.Score);
    }

    void Update()
    {
        
    }
}
