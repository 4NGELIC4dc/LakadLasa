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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();

            winLoseMenuGroup.SetActive(true);

            player.SetActive(false);

            cluesPanel.SetActive(false); // Hide clues

            // Check if player wins/loses
            if (HasPlayerWon(playerController))
            {
                winImage.gameObject.SetActive(true);
                loseImage.gameObject.SetActive(false);

                // Show HowButton only on win
                howButton.gameObject.SetActive(true);

                // Remove old listeners and add new one
                howButton.onClick.RemoveAllListeners();
                howButton.onClick.AddListener(PlayRecipeAnimation);
            }
            else
            {
                winImage.gameObject.SetActive(false);
                loseImage.gameObject.SetActive(true);

                // Hide HowButton on lose
                howButton.gameObject.SetActive(false);
            }

            // Button listeners
            retryButton.onClick.RemoveAllListeners();
            retryButton.onClick.AddListener(RetryLevel);

            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(ExitToMainMenu);
        }
    }

    // Checks if player has collected all correct ingredients and no wrong ones
    private bool HasPlayerWon(PlayerController playerController)
    {
        // Player did not collect anything
        if (playerController.collectedCorrectIngredients.Count == 0 && playerController.collectedWrongIngredients.Count == 0)
            return false;

        // Player collected any wrong ingredient
        if (playerController.collectedWrongIngredients.Count > 0)
            return false;

        // Check all correct ingredients
        foreach (var correct in playerController.correctIngredients)
        {
            if (!playerController.collectedCorrectIngredients.Contains(correct))
                return false;
        }

        return true;
    }

    // Reloads current level scene
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

    // Loads main menu scene
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
            // Make sure the GameObject is active before playing
            recipeAnimator.gameObject.SetActive(true);

            // Set trigger to play animation
            recipeAnimator.SetTrigger("EnterRecipe");
        }
    }
}
