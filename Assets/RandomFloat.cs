using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloat : MonoBehaviour
{
    public float floatRange = 0.5f; // 浮动幅度
    public float floatSpeed = 1.0f; // 浮动速度

    private Vector3 startPosition;

    void Start()
    {
        // 保存物品A的初始位置
        startPosition = transform.position;
    }

    void Update()
    {
        // 计算随机浮动的偏移量
        float xOffset = Mathf.Sin(Time.time * floatSpeed) * floatRange;
        float yOffset = Mathf.Cos(Time.time * floatSpeed) * floatRange;

        // 更新物品A的位置
        transform.position = new Vector3(startPosition.x + xOffset, startPosition.y + yOffset, startPosition.z);
    }
}

