using UnityEngine;

public class LightDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GermanLight")
        {
            Debug.Log("CAUGHT");
        }
    }
}
