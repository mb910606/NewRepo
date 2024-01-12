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

        // ���o SpriteRenderer �ե�
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
            Destroy(gameObject); // �b health �p�󵥩� 0 �ɾP���ĤH����
        }
        else
        {
            // ����ˮ`�ɩI�s�{�{�ĪG
            BlinkPlayer();
        }
    }

    // ����{�{�ĪG
    private void BlinkPlayer()
    {
        // �ϥΨ�{�ӱ����{�{�ĪG
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        // ����{�{�����ƩM�ɶ����j�]�i�H�ھڻݭn�վ�^
        int blinkCount = 2;
        float blinkInterval = 0.1f;

        for (int i = 0; i < blinkCount; i++)
        {
            // �}��/���� SpriteRenderer �Ӳ��Ͱ{�{�ĪG
            sr.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
            sr.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
