using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuGroup; 
    public GameObject player;         

    private bool isPaused = false; // Is game paused

    void Start()
    {
        pauseMenuGroup.SetActive(false); // HIdes pause menu
        Time.timeScale = 1f; // Ensure game is running at normal speed
    }

    // Toggle for pausing and resuming the game
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

    // Pauses game
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuGroup.SetActive(true);

        if (player != null)
            player.SetActive(false);
    }

    // Resumes game
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuGroup.SetActive(false);

        if (player != null)
            player.SetActive(true);
    }

    // Reloads current level
    public void RetryLevel()
    {
        Time.timeScale = 1f;

        GameObject music = GameObject.Find("LevelMusicManager");
        if (music != null)
        {
            Destroy(music);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Exits to main menu scene
    public void ExitToMainMenu()
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
