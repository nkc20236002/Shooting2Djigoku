using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemy2_0; // �G�̃v���n�u��ۑ�����ϐ�
    float span = 1;             // �G���o���Ԋu�i�b�j
    float delta = 0;            // ���Ԍv�Z�p�ϐ�

    void Update()
    {
        delta += Time.deltaTime; // �o�ߎ��Ԃ��v�Z

        // span�b���ɏ������s��
        if(delta > span)
        {
            delta = 0;  // ���Ԍv�Z�p�ϐ����O�ɂ���
            span -= (span >= 0.5f)? 0.01f : 0f;  // �X�p�����������Z������

            // �G�̃v���n�u���q�G�����L�[�ɓo�ꂳ����
            GameObject go = Instantiate(Enemy2_0);
            int py = Random.Range(-5, 6);
            go.transform.position = new Vector3(10, py, 0);
        }
    }
}
