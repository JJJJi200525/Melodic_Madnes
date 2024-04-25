using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Loading scene called "MainGame"
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        // 判断是否在Unity编辑器中运行
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#else
        Application.Quit();  
#endif
    }
}

