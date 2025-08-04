using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pausePanel;
    public MonoBehaviour fpsController;
    [SerializeField] private AudioClip pauseSound;
    [SerializeField] private AudioClip buttonSound;

    private void Start()
    {
        Time.timeScale = 1f; 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        if (fpsController != null)
            fpsController.enabled = true;
    }
    
    public void PlayClickSound()
    {
        if (buttonSound != null)
            AudioManager.instace.PlayAudioClip(buttonSound);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Play the pause sound
            AudioManager.instace.PlayAudioClip(pauseSound);
            TogglePause();
        }
    }

    public void TogglePause()
    {
        bool isPaused = pausePanel.activeSelf;
        
        // 1) Mostrar/ocultar UI
        pausePanel.SetActive(!isPaused);

        // 2) Pausar/reanudar tiempo
        Time.timeScale = isPaused ? 1f : 0f;

        // 3) Cursor
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // 4) Desactivar/Reactivar controlador FPS
        if (fpsController != null)
            fpsController.enabled = isPaused;
    }

    public void OnRestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void OnStartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void OnExitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
                Application.Quit();
    #endif
    }
}