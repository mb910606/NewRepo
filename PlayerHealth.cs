using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize player's health here if needed

        // 取得 SpriteRenderer 組件
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add any health-related logic you need here
    }

    public void DamagePlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // 在 health 小於等於 0 時銷毀敵人物件
        }
        else
        {
            // 受到傷害時呼叫閃爍效果
            BlinkPlayer();
        }
    }

    // 角色閃爍效果
    private void BlinkPlayer()
    {
        // 使用協程來控制角色閃爍效果
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        // 角色閃爍的次數和時間間隔（可以根據需要調整）
        int blinkCount = 2;
        float blinkInterval = 0.1f;

        for (int i = 0; i < blinkCount; i++)
        {
            // 開啟/關閉 SpriteRenderer 來產生閃爍效果
            sr.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
            sr.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
