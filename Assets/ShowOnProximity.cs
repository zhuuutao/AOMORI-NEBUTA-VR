using UnityEngine;

public class ShowOnProximity : MonoBehaviour
{
    public GameObject player; // 在 Unity 编辑器中将 Player 对象拖放到这个字段上
    public float proximityDistance = 2f; // 玩家靠近的触发距离

    private bool isPlayerNear = false;

    void Update()
    {
        // 计算玩家和物品之间的距离
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // 如果玩家靠近并且物品当前不可见，则显示物品
        if (distanceToPlayer < proximityDistance && !isPlayerNear)
        {
            ShowObject();
        }
        // 如果玩家离开并且物品当前可见，则隐藏物品
        else if (distanceToPlayer >= proximityDistance && isPlayerNear)
        {
            HideObject();
        }
    }

    // 显示物品
    void ShowObject()
    {
        gameObject.SetActive(true);
        isPlayerNear = true;
    }

    // 隐藏物品
    void HideObject()
    {
        gameObject.SetActive(false);
        isPlayerNear = false;
    }
}
