using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CookingPot : MonoBehaviour
{
    [Header("UI Groups")]
    public GameObject winLoseMenuGroup; // Group with WinLose UI
    public Image winImage;               // UI Image for win_TortangTalong
    public Image loseImage;              // UI Image for lose_TortangTalong

    [Header("Buttons")]
    public Button retryButton;          // Retry button under WinLoseGroup
    public Button exitButton;           // Exit button under WinLoseGroup

    [Header("Player")]
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();

            // Show the win/lose UI group
            winLoseMenuGroup.SetActive(true);

            // Disable player movement
            player.SetActive(false);

            // Determine win or lose
            if (HasPlayerWon(playerController))
            {
                winImage.gameObject.SetActive(true);
                loseImage.gameObject.SetActive(false);
            }
            else
            {
                winImage.gameObject.SetActive(false);
                loseImage.gameObject.SetActive(true);
            }

            // Hook up retry and exit buttons directly here
            retryButton.onClick.RemoveAllListeners();
            retryButton.onClick.AddListener(RetryLevel);

            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(ExitToMainMenu);
        }
    }

    private bool HasPlayerWon(PlayerController playerController)
    {
        // Lose if no ingredients collected
        if (playerController.collectedCorrectIngredients.Count == 0 && playerController.collectedWrongIngredients.Count == 0)
            return false;

        // Lose if collected wrong ingredients
        if (playerController.collectedWrongIngredients.Count > 0)
            return false;

        // Must have collected all correct ingredients
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ExitToMainMenu()
    {
        Time.timeScale = 1f;

        // Optionally stop/destroy music
        GameObject music = GameObject.Find("LevelMusicManager");
        if (music != null)
        {
            Destroy(music);
        }

        SceneManager.LoadScene("MainMenu");
    }
}
