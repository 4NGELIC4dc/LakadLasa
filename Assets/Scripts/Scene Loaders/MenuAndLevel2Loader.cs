using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuAndLevel2Loader : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToLVLtortangtalong()
    {
        SceneManager.LoadScene("LVLtortangtalong");
    }
}
