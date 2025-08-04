using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserTrap : MonoBehaviour
{
    private Vector3 startPos; 
    [SerializeField] private AudioClip laserSound;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else if (other.CompareTag("Box"))
        {
            AudioManager.instace.PlayAudioClip(laserSound);
            Destroy(other.gameObject);
        }
        
    }
    
    void Start()
    {
        startPos = transform.position;

    }
    
    void Update()
    {
        float speed = 2f; 
        float distance = 0.5f; 
        float offset = Mathf.Sin(Time.time * speed) * distance;
        transform.position = startPos + new Vector3(0, 0, offset);
            
    }
    
}