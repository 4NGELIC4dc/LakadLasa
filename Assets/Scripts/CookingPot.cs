using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Attached to the cooking pot and handles win/lose conditions
public class CookingPot : MonoBehaviour
{
    [Header("Clues UI")]
    public GameObject cluesPanel;

    [Header("UI Groups")]
    public GameObject winLoseMenuGroup;
    public Image winImage;
    public Image loseImage;

    [Header("Buttons")]
    public Button retryButton;
    public Button exitButton;

    [Header("How Button")]
    public Button howButton;
    public Animator recipeAnimator;

    [Header("Player")]
    public GameObject player;

    [Header("Audio")]
    public AudioClip winSFX;
    public AudioClip loseSFX;
    public AudioClip paperSFX;
    private AudioSource audioSource;

    void Update()
    {
        if (audioSource != null)
            audioSource.volume = GameSettingsManager.Instance.sfxVolume;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.loop = false;
        audioSource.volume = GameSettingsManager.Instance.sfxVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();

            winLoseMenuGroup.SetActive(true);
            player.SetActive(false);
            cluesPanel.SetActive(false); // Hide clues

            if (HasPlayerWon(playerController))
            {
                winImage.gameObject.SetActive(true);
                loseImage.gameObject.SetActive(false);

                // Play win sound
                if (winSFX != null)
                    audioSource.PlayOneShot(winSFX, GameSettingsManager.Instance.sfxVolume);

                howButton.gameObject.SetActive(true);
                howButton.onClick.RemoveAllListeners();
                howButton.onClick.AddListener(PlayRecipeAnimation);
            }
            else
            {
                winImage.gameObject.SetActive(false);
                loseImage.gameObject.SetActive(true);

                // Play lose sound
                if (loseSFX != null)
                    audioSource.PlayOneShot(loseSFX, GameSettingsManager.Instance.sfxVolume);

                howButton.gameObject.SetActive(false);
            }

            retryButton.onClick.RemoveAllListeners();
            retryButton.onClick.AddListener(RetryLevel);

            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(ExitToMainMenu);
        }
    }

    private bool HasPlayerWon(PlayerController playerController)
    {
        if (playerController.collectedCorrectIngredients.Count == 0 && playerController.collectedWrongIngredients.Count == 0)
            return false;

        if (playerController.collectedWrongIngredients.Count > 0)
            return false;

        foreach (var correct in playerController.correctIngredients)
        {
            if (!playerController.collectedCorrectIngredients.Contains(correct))
                return false;
        }

        return true;
    }

    private void RetryLevel()
    {
        Time.timeScale = 1f;

        GameObject music = GameObject.Find("LevelMusicManager");
        if (music != null)
        {
            Destroy(music);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ExitToMainMenu()
    {
        Time.timeScale = 1f;

        GameObject music = GameObject.Find("LevelMusicManager");
        if (music != null)
        {
            Destroy(music);
        }

        SceneManager.LoadScene("MainMenu");
    }

    private void PlayRecipeAnimation()
    {
        if (recipeAnimator != null)
        {
            recipeAnimator.gameObject.SetActive(true);
            recipeAnimator.SetTrigger("EnterRecipe");

            // Play paper SFX
            if (audioSource != null && paperSFX != null)
            {
                audioSource.PlayOneShot(paperSFX, GameSettingsManager.Instance.sfxVolume);
            }
        }
    }
}
