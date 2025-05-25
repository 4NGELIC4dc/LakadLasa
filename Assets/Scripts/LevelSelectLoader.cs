using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectLoader : MonoBehaviour
{
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
