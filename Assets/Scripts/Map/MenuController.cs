using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelname;
    public void StartGame()
    {
        // Loading scene called "MainGame"
        SceneManager.LoadScene(levelname);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelname);
        }
    }
}

