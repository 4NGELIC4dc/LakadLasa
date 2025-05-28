using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CookingPot : MonoBehaviour
{
    [Header("UI Groups")]
    public GameObject winLoseMenuGroup; 
    public Image winImage;               
    public Image loseImage;              

    [Header("Buttons")]
    public Button retryButton;         
    public Button exitButton;          

    [Header("Player")]
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();

            winLoseMenuGroup.SetActive(true);

            player.SetActive(false);

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

        // Destroy the LevelMusicManager before reloading
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
}
