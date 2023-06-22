using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemController2 : MonoBehaviour
{
    SpriteRenderer spRender;    // �����_���[�R���|�[�l���g�擾
    Vector3 pos;                // �o���ʒu
    int itemType;               // �A�C�e���̎��
    float speed;                // �������x
    public Image timeGauge;
    public static float lastTime;

    void Start()
    {
        itemType = Random.Range(0, 4);  // �A�C�e���̎��0�`3
        speed = 5f;                     // �������x

        // itemType=0:�� / itemType=1:�� / itemType=2:�@/ itemType=3:�}�[���^
        Color[] col = { Color.yellow, Color.green, Color.blue, Color.magenta };
        spRender = GetComponent<SpriteRenderer>();
        spRender.color = col[itemType];

        // �o���ʒu
        pos.x = Random.Range(-8f, 8f);
        pos.y = 6f;
        pos.z = 0;
        transform.position = pos;

        // ����3�b
        Destroy(gameObject, 3f); 
    }

    void Update()
    {
        // �������� speed m/s �ňړ�
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    // �d�Ȃ蔻��
    void OnTriggerEnter2D(Collider2D c)
    {
        // �d�Ȃ�������̃^�O���yPlayer�z��������
        if (c.gameObject.tag == "Player")
        {
            // PlayerController�R���|�[�l���g��ۑ�
            PlayerController pCon = c.gameObject.GetComponent<PlayerController>();

            // �A�C�e���̎�ޕʂɏ�����ύX
            if (itemType == 0)       // ���F�e���x���{�P
            {
                pCon.ShotLevel += 1; 
            }
            else if (itemType == 1)  // �΁F�X�s�[�h�{�T
            {
                pCon.Speed += 5;     
            }
            else if (itemType == 2)  // �F�e���x���O�@�X�s�[�h�T
            {
                pCon.Speed     = 5;
                pCon.ShotLevel = 0;
            }
            else if (itemType == 3)  // �� : ����60����
            {
                GameDirector.lastTime -= 60f;
            }

            // �����i�A�C�e���j�폜
            Destroy(gameObject);
        }
    }
}
