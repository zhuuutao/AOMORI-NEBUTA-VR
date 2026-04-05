using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectOnContact : MonoBehaviour
{
    public GameObject player;
    public GameObject objectA; // 玩家接触的物体
    public GameObject objectB; // 需要移动的物体
    public float moveSpeed = 5f; // 移动速度
    public float moveDistance = 3f; // 移动距离

    private Vector3 initialBPosition; // 物体B的初始位置
    private bool hasPlayerContactedA = false; // 记录是否玩家接触到了物体A

    private void Start()
    {
        // 记录物体B的初始位置
        initialBPosition = objectB.transform.position;
    }

    private void Update()
    {
        // 检测玩家是否接触到物体A
        if (!hasPlayerContactedA && player != null && objectA != null && player.GetComponent<Collider>().bounds.Intersects(objectA.GetComponent<Collider>().bounds))
        {
            // 玩家接触到物体A，启动移动物体B的协程
            StartCoroutine(MoveObjectCoroutine());
            hasPlayerContactedA = true;
        }
    }

    private IEnumerator MoveObjectCoroutine()
    {
        float distanceMoved = 0f;

        // 移动物体B直到达到指定的移动距离
        while (distanceMoved < moveDistance)
        {
            // 计算物体B的新位置（向前移动）
            Vector3 newPosition = objectB.transform.position + objectB.transform.forward * moveSpeed * Time.deltaTime;

            // 移动物体B
            objectB.transform.position = newPosition;

            // 更新移动距离
            distanceMoved += moveSpeed * Time.deltaTime;

            yield return null; // 等待一帧
        }
    }

    // 在Inspector面板中可以调整移动距离的函数
    private void OnValidate()
    {
        moveDistance = Mathf.Max(0f, moveDistance); // 移动距离不能为负数
    }

    // 重新开始游戏时重置状态
    public void ResetState()
    {
        objectB.transform.position = initialBPosition;
        hasPlayerContactedA = false;
    }
}
