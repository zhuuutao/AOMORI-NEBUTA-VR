using UnityEngine;

public class VerticalFloat : MonoBehaviour
{
    public float floatAmplitude = 0.5f; // 上下浮动的幅度
    public float floatFrequency = 1f; // 上下浮动的频率

    private Vector3 originalPosition; // 原始位置

    void Start()
    {
        // 记录物品的原始位置
        originalPosition = transform.position;
    }

    void Update()
    {
        // 计算上下浮动的偏移值
        float floatOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

        // 应用上下浮动效果
        transform.position = originalPosition + Vector3.up * floatOffset;
    }
}
