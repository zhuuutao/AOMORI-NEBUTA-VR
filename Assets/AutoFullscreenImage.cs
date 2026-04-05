using UnityEngine;

public class AutoFullscreenImage : MonoBehaviour
{
    public Texture2D imageTexture; // 图片纹理
    public float displayTime = 3f; // 显示时间

    private float timer = 0f;
    private bool isPlaying = false;

    private void Start()
    {
        // 在启动时开始播放图片
        StartDisplayImage();
    }

    private void Update()
    {
        if (isPlaying)
        {
            // 计时器增加
            timer += Time.deltaTime;

            // 检查是否达到显示时间
            if (timer >= displayTime)
            {
                // 停止显示图片
                StopDisplayImage();
            }
        }
    }

    private void OnGUI()
    {
        if (isPlaying)
        {
            // 在全屏显示图片
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), imageTexture);
        }
    }

    private void StartDisplayImage()
    {
        // 启动显示图片
        isPlaying = true;
        timer = 0f;
        Cursor.visible = false; // 隐藏鼠标光标
    }

    private void StopDisplayImage()
    {
        // 停止显示图片
        isPlaying = false;
        Cursor.visible = true; // 恢复鼠标光标
    }
}
