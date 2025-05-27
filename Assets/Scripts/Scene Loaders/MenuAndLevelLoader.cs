using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuAndLevelLoader : MonoBehaviour
{
    private string selectedLevel;

    public GameObject checkBananacue;
    public GameObject checkTortangTalong;
    public GameObject checkEscabeche;

    public void SelectLevel(string levelName)
    {
        selectedLevel = levelName;
        UpdateCheckmarks(levelName);
        Debug.Log("Selected Level: " + selectedLevel);
    }

    private void UpdateCheckmarks(string selected)
    {
        checkBananacue.SetActive(selected == "LVLbananacue");
        checkTortangTalong.SetActive(selected == "LVLtortangtalong");
        checkEscabeche.SetActive(selected == "LVLescabechengisda");
    }

    public void StartSelectedLevel()
    {
        if (!string.IsNullOrEmpty(selectedLevel))
        {
            SceneManager.LoadScene(selectedLevel);
        }
        else
        {
            Debug.LogWarning("No level selected!");
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
