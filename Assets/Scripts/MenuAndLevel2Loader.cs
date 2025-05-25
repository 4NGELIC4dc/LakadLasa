using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuAndLevel2Loader : MonoBehaviour
{
    // Call this to load MainMenu scene
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Call this to load LVLtortangtalong scene
    public void GoToLVLtortangtalong()
    {
        SceneManager.LoadScene("LVLtortangtalong");
    }
}
