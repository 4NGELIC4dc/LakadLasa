using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuAndLevelLoader : MonoBehaviour
{
    private string selectedLevel;

    // References to UI checkmark GameObjects
    public GameObject checkBananacue;
    public GameObject checkTortangTalong;
    public GameObject checkEscabeche;
    
    // Call selected level
    public void SelectLevel(string levelName)
    {
        selectedLevel = levelName; 
        UpdateCheckmarks(levelName);
        Debug.Log("Selected Level: " + selectedLevel);
    }

    // Visible or invisble UI checkmark
    private void UpdateCheckmarks(string selected)
    {
        checkBananacue.SetActive(selected == "LVLbananacue");
        checkTortangTalong.SetActive(selected == "LVLtortangtalong");
        checkEscabeche.SetActive(selected == "LVLescabechengisda");
    }

    // Loads selected level
    public void StartSelectedLevel()
    {
        if (!string.IsNullOrEmpty(selectedLevel))
        {
            SceneManager.LoadScene(selectedLevel);
        }
        else
        {
            Debug.LogWarning("No level selected.");
        }
    }

    // Loads main menu scene
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
