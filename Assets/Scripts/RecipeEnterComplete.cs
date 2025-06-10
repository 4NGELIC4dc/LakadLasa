using UnityEngine;

public class RecipeEnterComplete : MonoBehaviour
{
    public Animator btnTortangTalongAnimator;
    public Animator btnBananacueAnimator;
    public Animator btnEscabechengIsdaAnimator;

    [Header("Audio")]
    public AudioClip paperSFX;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    public void PlayButtonAnimations()
    {
        btnTortangTalongAnimator.gameObject.SetActive(true);
        btnBananacueAnimator.gameObject.SetActive(true);
        btnEscabechengIsdaAnimator.gameObject.SetActive(true);

        btnTortangTalongAnimator.SetTrigger("Enter");
        btnBananacueAnimator.SetTrigger("Enter");
        btnEscabechengIsdaAnimator.SetTrigger("Enter");

        // Apply SFX volume before playing
        audioSource.volume = GameSettingsManager.Instance.sfxVolume;

        if (paperSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(paperSFX, GameSettingsManager.Instance.sfxVolume);
        }
    }
}
