using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndFloat : MonoBehaviour
{
    public Transform centerObject; // 物品B的Transform组件
    public float rotationSpeed = 30f; // 旋转速度
    public float floatSpeed = 0.5f; // 浮动速度
    public float floatHeight = 0.5f; // 浮动高度

    private void Update()
    {
        // 旋转物品A围绕着物品B
        RotateAroundCenter();

        // 上下浮动物品A
        FloatUpDown();
    }

    void RotateAroundCenter()
    {
        // 获取物品A当前位置到物品B的方向
        Vector3 directionToCenter = transform.position - centerObject.position;

        // 计算旋转角度
        float rotationStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Quaternion.Euler(0, rotationStep, 0) * directionToCenter;

        // 更新物品A的位置
        transform.position = centerObject.position + newDirection;
    }

    void FloatUpDown()
    {
        // 计算浮动效果
        float floatOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // 更新物品A的高度
        transform.position = new Vector3(transform.position.x, centerObject.position.y + floatOffset, transform.position.z);
    }
}
