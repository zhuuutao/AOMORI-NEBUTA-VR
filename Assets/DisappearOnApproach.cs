using UnityEngine;

public class DisappearOnApproach : MonoBehaviour
{
    public GameObject player; // 在 Unity 编辑器中将 Player 对象拖放到这个字段上
    public float proximityDistance = 2f; // 玩家靠近物品的距离阈值

    private Vector3 originalPosition; // 原始的物品位置
    private bool isPlayerApproaching = false;

    void Start()
    {
        // 记录物品的原始位置
        originalPosition = transform.position;
    }

    void Update()
    {
        // 计算玩家和物品之间的距离
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // 如果玩家靠近物品并且物品未消失，则让物品消失
        if (distanceToPlayer < proximityDistance && !isPlayerApproaching)
        {
            Disappear();
            isPlayerApproaching = true;
        }
      
        
    }

    // 使物品消失
    void Disappear()
    {
        gameObject.SetActive(false);
    }

    
}
