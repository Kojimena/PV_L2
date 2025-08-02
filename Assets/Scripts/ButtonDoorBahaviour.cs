using UnityEngine;

public class ButtonDoorBahaviour : MonoBehaviour
{
    [SerializeField] private GameObject wallToDeactivate; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box") || other.CompareTag("Player"))
        {
            
            // Move the button down by pressDepth
            wallToDeactivate.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box") || other.CompareTag("Player"))
        {
            // Move the button back to its original position
            wallToDeactivate.SetActive(true); 
        }
    }
}
