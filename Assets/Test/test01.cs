using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test01 : MonoBehaviour
{
    int score;
    //score�ϐ��ɃA�N�Z�X����v���p�e�B��p�ӂ���
    public int Score
    {
        set { score = value;
            score = Mathf.Clamp(score, 0, 9999);
        }
        get { return score;  }
    }

    void Start()
    {
        Debug.Log("test01 =" + score);
    }

    void Update()
    {
        
    }
}
