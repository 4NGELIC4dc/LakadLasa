using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void LoadGuide()
    {
        SceneManager.LoadScene("GuideScene");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }
}
