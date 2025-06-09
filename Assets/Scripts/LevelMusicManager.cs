using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public string[] levelsToPlayIn;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        bool shouldPlay = false;
        foreach (string level in levelsToPlayIn)
        {
            if (currentScene == level)
            {
                shouldPlay = true;
                break;
            }
        }

        if (shouldPlay)
        {
            audioSource.loop = true;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            Destroy(gameObject); 
        }

        DontDestroyOnLoad(gameObject);
    }
}
