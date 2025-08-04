using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip switchSound;
    [SerializeField] private AudioClip keySound;
    [SerializeField] private AudioClip boxSound;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    private void Click()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Switch"))
            {
                AudioManager.instace.PlayAudioClip(switchSound);
                GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");
                foreach (GameObject trap in traps)
                {
                    trap.SetActive(!trap.activeSelf);
                }
            }
            else if (hit.collider.CompareTag("Key"))
            {
                AudioManager.instace.PlayAudioClip(keySound);
                PlayerInventory.hasKey = true;
                Destroy(hit.collider.gameObject);
                Debug.Log("Key collected!");
            } else if (hit.collider.CompareTag("Box"))
            {
                AudioManager.instace.PlayAudioClip(boxSound);
                hit.collider.attachedRigidbody.AddForce(-hit.normal * 5f, ForceMode.Impulse);
                
            }
        }
    }
    
}