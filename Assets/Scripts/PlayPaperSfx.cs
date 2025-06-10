using UnityEngine;

public class PlayPaperSfx : MonoBehaviour
{
    public AudioClip paperSFX;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.loop = false;
        audioSource.playOnAwake = false;

        // Apply SFX volume
        audioSource.volume = GameSettingsManager.Instance.sfxVolume;

        if (paperSFX != null)
            audioSource.PlayOneShot(paperSFX, GameSettingsManager.Instance.sfxVolume);
    }
}
