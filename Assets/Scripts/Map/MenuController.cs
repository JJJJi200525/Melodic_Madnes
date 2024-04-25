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
        // �ж��Ƿ���Unity�༭��������
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#else
        Application.Quit();  
#endif
    }
}

