using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource;

    private string[] allowedScenes = { "MainMenu", "CreditsScene", "OptionsScene", "LevelSelect", "GuideScene" };

    void Awake()
    {
        if (FindObjectsOfType<BGMManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bool shouldPlay = false;
        foreach (var name in allowedScenes)
        {
            if (scene.name == name)
            {
                shouldPlay = true;
                break;
            }
        }

        if (shouldPlay && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (!shouldPlay && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
