using UnityEngine;

public class AutoPlayAudio : MonoBehaviour
{
    public AudioClip audioClip; // 音频剪辑
    [Range(0f, 1f)] public float volume = 1f; // 音量

    private AudioSource audioSource;

    private void Start()
    {
        // 创建音频源组件
        audioSource = gameObject.AddComponent<AudioSource>();

        // 设置音频剪辑和循环播放
        audioSource.clip = audioClip;
        audioSource.loop = true;

        // 设置初始音量
        SetVolume(volume);

        // 启动播放音频
        PlayAudio();
    }

    private void Update()
    {
        // 检查音频是否播放结束
        if (!audioSource.isPlaying)
        {
            // 音频结束后重新播放
            PlayAudio();
        }
    }

    // 在Inspector面板中可以调整音量的函数
    private void OnValidate()
    {
        SetVolume(volume);
    }

    private void PlayAudio()
    {
        // 播放音频
        if (audioSource != null && audioClip != null)
        {
            audioSource.Play();
        }
    }

    private void SetVolume(float newVolume)
    {
        // 设置音量
        if (audioSource != null)
        {
            audioSource.volume = newVolume;
        }
    }
}
