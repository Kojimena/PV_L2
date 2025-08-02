using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
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
                GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");
                foreach (GameObject trap in traps)
                {
                    trap.SetActive(!trap.activeSelf);
                }
            }
            else if (hit.collider.CompareTag("Key"))
            {
                PlayerInventory.hasKey = true;
                Destroy(hit.collider.gameObject);
                Debug.Log("Llave recogida");
            } else if (hit.collider.CompareTag("Box"))
            {
                hit.collider.attachedRigidbody.AddForce(-hit.normal * 5f, ForceMode.Impulse);
                
            }
        }
    }
    
}