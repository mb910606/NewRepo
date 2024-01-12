using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    public int attackdamage;
    public float flashtime;
    public GameObject BloodEffect;

    private SpriteRenderer sr;
    private Color OriginalColor;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        sr = GetComponent<SpriteRenderer>();
        OriginalColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Enemy defeated!");
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy health: " + health); // 檢查 health 的值
        FlashColor(flashtime);
        Instantiate(BloodEffect, transform.position, Quaternion.identity);
        GameController.camshake.shake();
    }

    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }

    void ResetColor()
    {
        sr.color = OriginalColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other is CapsuleCollider2D)
        {
            Debug.Log("Player entered the trigger"); // 確認觸發事件
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(attackdamage);
            }
        }
    }
}
