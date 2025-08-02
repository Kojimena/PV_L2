using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private Material openDoorMaterial;
    [SerializeField] private MeshRenderer doorRenderer;
    [SerializeField] private GameObject customCursor;
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private GameObject fadePanel;
    [SerializeField] private TextMeshProUGUI finalMessageText;

    private bool hasEscaped = false;

    private void Start()
    {
        messageText.text = "";
        fadePanel.SetActive(false);
    }
    
    private void Update()
    {
        if (hasEscaped && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasEscaped) return;

        if (other.CompareTag("Player") && PlayerInventory.hasKey)
        {
            if (doorRenderer != null && openDoorMaterial != null)
            {
                doorRenderer.material = openDoorMaterial;
            }

            hasEscaped = true;
            fadePanel.SetActive(true);
            customCursor.SetActive(false);
            finalMessageText.text = "Has logrado escapar... esta vez.\n\nPresiona R para reiniciar el nivel.";
        }
        else if (other.CompareTag("Player"))
        {
            ShowMessage("Necesitas una llave para abrir esta puerta.");
        }
    }

    private void ShowMessage(string text)
    {
        messageText.text = text;
        CancelInvoke(nameof(ClearMessage));
        Invoke(nameof(ClearMessage), 2f); 
    }

    private void ClearMessage()
    {
        messageText.text = "";
    }
    
}