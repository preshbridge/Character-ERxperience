using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;
    public Slider volumeSlider;

    void Awake()
    {
        // Prevent duplicates
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (volumeSlider != null)
        {
            musicSource.volume = volumeSlider.value;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void TogglePlayStop()
    {
        if (musicSource.isPlaying)
            musicSource.Pause();
        else
            musicSource.Play();
    }

    public void SetVolume(float value)
    {
        musicSource.volume = value;
    }
}
