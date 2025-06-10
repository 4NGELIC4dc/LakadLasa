using UnityEngine;
using UnityEngine.UI;

public class UIButtonSFX : MonoBehaviour
{
    public AudioClip clickSFX; // Assign this in the inspector

    private AudioSource sfxSource;

    void Start()
    {
        GameObject sfxManager = GameObject.Find("SFXManager");
        if (sfxManager != null)
        {
            sfxSource = sfxManager.GetComponent<AudioSource>();

            if (sfxSource != null)
            {
                Button button = GetComponent<Button>();
                button.onClick.AddListener(PlayClickSound);
            }
        }
    }

    void PlayClickSound()
    {
        if (sfxSource != null && clickSFX != null)
        {
            sfxSource.PlayOneShot(clickSFX, GameSettingsManager.Instance.sfxVolume);
        }
    }
}
