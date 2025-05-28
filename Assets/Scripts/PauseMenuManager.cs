using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuGroup; // Assign PauseMenuGroup in the Inspector
    public GameObject player;         // Assign your Player GameObject in the Inspector

    private bool isPaused = false;

    void Start()
    {
        pauseMenuGroup.SetActive(false); // Hide pause UI initially
        Time.timeScale = 1f;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuGroup.SetActive(true);

        // Optional: Disable player controls (if needed separately)
        if (player != null)
            player.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuGroup.SetActive(false);

        if (player != null)
            player.SetActive(true);
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f; // Unpause
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f; // Unpause before exiting

        // Stop/destroy the level music object
        GameObject music = GameObject.Find("LevelMusicManager");
        if (music != null)
        {
            Destroy(music);
        }

        SceneManager.LoadScene("MainMenu");
    }
}
