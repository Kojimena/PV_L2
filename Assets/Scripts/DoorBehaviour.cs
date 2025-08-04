using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 
using StarterAssets;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private Material openDoorMaterial;
    [SerializeField] private MeshRenderer doorRenderer;
    [SerializeField] private GameObject customCursor;
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI messageText;
    [Header("Audio")]
    [SerializeField] private AudioClip unlockSound;
    [SerializeField] private AudioClip lockedSound;


    private bool hasEscaped = false;

    private void Start()
    {
        PlayerInventory.hasKey = false;
        messageText.text = "";
    }
    
    private void Update()
    {
        
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
            if (customCursor != null)
                customCursor.SetActive(false);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible   = true;

            var fps = FindAnyObjectByType<FirstPersonController>();
            if (fps != null)
                fps.enabled = false;
            
            if (unlockSound != null){
                AudioManager.instace.PlayAudioClip(unlockSound);
            }
            
            SceneManager.LoadScene("WinMenu");

        }
        else if (other.CompareTag("Player"))
        {
            if (lockedSound != null)
            {
                AudioManager.instace.PlayAudioClip(lockedSound);
            }
            ShowMessage("Necesitas una llave para abrir esta puerta.");
        }
    }

    private void ShowMessage(string text)
    {
        messageText.text = text;
        messageText.gameObject.SetActive(true);
        CancelInvoke(nameof(ClearMessage));
        Invoke(nameof(ClearMessage), 2f); 
    }
    
    private void ClearMessage()
    {
        messageText.text = "";
    }
    
}