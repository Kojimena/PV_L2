using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnStartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Llama a este método desde el botón "Quit" (OnClick)
    public void OnExitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
        }
}