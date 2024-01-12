using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyene : MonoBehaviour
{
    public float speed;
    public float startwaitTime;
    private float waitTime;

    public Transform movePos; // 移動的目標位置
    private Vector3 originalPos; // 初始位置
    private bool movingRight = true; // 是否向右移動
    private bool followPlayer = false; // 是否追蹤玩家

    private void Start()
    {
        waitTime = startwaitTime;
        originalPos = transform.position;
    }

    private void Update()
    {
        if (followPlayer)
        {
            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            if (playerTransform != null)
            {
                // 追蹤玩家
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

                // 如果敵人接近玩家，則停止追蹤並等待一段時間
                if (Vector3.Distance(transform.position, playerTransform.position) < 1.0f)
                {
                    followPlayer = false;
                    waitTime = startwaitTime;
                }
                

            }
        }
        else
        {
            // 根據movingRight變數決定敵人的移動方向
            Vector3 targetPos = movingRight ? movePos.position : originalPos;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            // 到達目標位置後，等待一段時間再改變移動方向
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {

                if (waitTime <= 0)
                {
                    Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
                    if (playerTransform != null)
                    {
                        // 在到達目標位置後，有50%的機率開始追蹤玩家
                        if (Random.Range(0f, 1f) > 0.5f)
                        {
                            followPlayer = true;
                        }
                        else
                        {
                            movingRight = !movingRight;
                        }
                    }

                    if (playerTransform != null)
                    {
                        // 在这里使用 playerTransform 对象
                    }

                    waitTime = startwaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

}
