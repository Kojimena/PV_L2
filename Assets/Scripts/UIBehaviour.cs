using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pausePanel;

    public MonoBehaviour fpsController;

    private void Start()
    {
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        bool isPaused = pausePanel.activeSelf;
        
        //imprime el estado del juego
        Debug.Log("Estado del juego: " + (isPaused ? "Pausado" : "Reanudado"));

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