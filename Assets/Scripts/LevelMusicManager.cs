using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public string[] levelsToPlayIn;

    private bool isValidScene = false;

    void Awake()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogWarning("No AudioSource found on LevelMusicManager.");
                return;
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        foreach (string level in levelsToPlayIn)
        {
            if (currentScene == level)
            {
                isValidScene = true;
                break;
            }
        }

        if (isValidScene)
        {
            if (GameSettingsManager.Instance != null)
            {
                audioSource.loop = true;
                audioSource.volume = GameSettingsManager.Instance.bgmVolume;

                if (!audioSource.isPlaying)
                    audioSource.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isValidScene && audioSource != null && GameSettingsManager.Instance != null)
        {
            audioSource.volume = GameSettingsManager.Instance.bgmVolume;
        }
    }
}
