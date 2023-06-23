using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemController2 : MonoBehaviour
{
    SpriteRenderer spRender;    // レンダラーコンポーネント取得
    Vector3 pos;                // 出現位置
    int itemType;               // アイテムの種類
    float speed;                // 落下速度
    public Image timeGauge;
    public static float lastTime;

    void Start()
    {
        itemType = Random.Range(0, 5);  // アイテムの種類0～4
        speed = 5f;                     // 落下速度

        // itemType=0:黄 / itemType=1:緑 / itemType=2:青　/ itemType=3:マゼンタ/ itemType=4:シアン
        Color[] col = { Color.yellow, Color.green, Color.blue, Color.magenta, Color.cyan };
        spRender = GetComponent<SpriteRenderer>();
        spRender.color = col[itemType];

        // 出現位置
        pos.x = Random.Range(-8f, 8f);
        pos.y = 6f;
        pos.z = 0;
        transform.position = pos;

        // 寿命3秒
        Destroy(gameObject, 3f); 
    }

    void Update()
    {
        // 下方向に speed m/s で移動
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    // 重なり判定
    void OnTriggerEnter2D(Collider2D c)
    {
        // 重なった相手のタグが【Player】だったら
        if (c.gameObject.tag == "Player")
        {
            // PlayerControllerコンポーネントを保存
            PlayerController pCon = c.gameObject.GetComponent<PlayerController>();

            // アイテムの種類別に処理を変更
            if (itemType == 0)       // 黄：弾レベル＋１
            {
                pCon.ShotLevel += 1; 
            }
            else if (itemType == 1)  // 緑：スピード＋５
            {
                pCon.Speed += 5;     
            }
            else if (itemType == 2)  // 青：弾レベル０　スピード５
            {
                pCon.Speed     = 5;
                pCon.ShotLevel = 0;
            }
            else if (itemType == 3)  // マゼンタ : 時間60減少
            {
                GameDirector.lastTime -= 60f;
            }
            else if (itemType == 4)  // シアン : 時間5減少
            {
                GameDirector.lastTime -= 5f;
            }

            // 自分（アイテム）削除
            Destroy(gameObject);
        }
    }
}
