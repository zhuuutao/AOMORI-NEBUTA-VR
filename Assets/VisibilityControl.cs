using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityControl : MonoBehaviour
{
    public GameObject player;
    public GameObject objectA; // 需要控制可见性的物体
    public float detectionDistance = 1f; // 检测距离

    private void Update()
    {
        if (player != null && objectA != null)
        {
            // 计算玩家和物体A之间的距离
            float distanceToPlayer = Vector3.Distance(player.transform.position, objectA.transform.position);

            // 根据距离设置物体A的可见性
            if (distanceToPlayer <= detectionDistance)
            {
                SetObjectVisibility(true); // 在检测距离内，设置为可见状态
            }
            else
            {
                SetObjectVisibility(false); // 超出检测距离，设置为不可见状态
            }
        }
    }

    private void SetObjectVisibility(bool isVisible)
    {
        if (objectA != null)
        {
            objectA.SetActive(isVisible);
        }
    }

    // 在Inspector面板中可以调整检测距离的函数
    private void OnValidate()
    {
        detectionDistance = Mathf.Max(0f, detectionDistance); // 检测距离不能为负数
    }
}
