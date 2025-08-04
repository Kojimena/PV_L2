using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private AudioClip buttonSound;

    public void OnStartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void PlayClickSound()
    {
        if (buttonSound != null)
            AudioManager.instace.PlayAudioClip(buttonSound);
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