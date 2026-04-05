using UnityEngine;

public class ContinuousFollowPlayerOnTouch : MonoBehaviour
{
    public Transform player; // 在 Unity 编辑器中将 Player 对象拖放到这个字段上
    public float followSpeed = 5f; // 跟随玩家的速度
    public float floatAmplitude = 0.1f; // 上下浮动的幅度
    public float floatFrequency = 1f; // 上下浮动的频率
    public float distanceAhead = 2f; // 物品相对于玩家的前方距离
    public Vector3 targetOffset = new Vector3(0f, 0f, 0f); // 目标位置的偏移

    private Vector3 originalPosition; // 原始位置
    private Vector3 targetPosition; // 目标位置

    void Start()
    {
        // 记录物品的原始位置
        originalPosition = transform.position;
    }

    void Update()
    {
        // 计算上下浮动的偏移值
        float floatOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

        // 计算目标位置（玩家的左前方 + 偏移）
        Vector3 forwardDirection = player.forward;
        Vector3 leftDirection = -player.right;
        targetPosition = player.position + forwardDirection * distanceAhead + leftDirection * distanceAhead + targetOffset;

        // 应用上下浮动效果
        targetPosition.y += floatOffset;

        // 使用 Lerp 平滑移动物品到目标位置
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    // 当玩家触碰到物品时调用
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 这里不再停止跟随的逻辑
        }
    }
}
