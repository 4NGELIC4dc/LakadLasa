using UnityEngine;
using UnityEngine.UI;

public class UIButtonSFX : MonoBehaviour
{
    private AudioSource sfxSource;

    void Start()
    {
        sfxSource = GameObject.Find("SFXManager").GetComponent<AudioSource>();

        Button button = GetComponent<Button>();

        button.onClick.AddListener(PlayClickSound);
    }

    void PlayClickSound()
    {
        sfxSource.Play();
    }
}
