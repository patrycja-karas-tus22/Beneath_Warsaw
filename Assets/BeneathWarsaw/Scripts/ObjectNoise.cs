using UnityEngine;

public class ObjectNoise : MonoBehaviour
{
    public float noiseAmount = 0.5f;
    public AudioClip impactSound;
    private AudioSource audioSource;
    private bool hasMadeNoise = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1.5f)
        {
            // Play sound
            if (impactSound != null)
            {
                audioSource.PlayOneShot(impactSound);

                // Add noise for the duration of the sound
                StartCoroutine(TemporaryNoise(impactSound.length));
            }
        }
    }

    System.Collections.IEnumerator TemporaryNoise(float duration)
    {
        GameNoise.AddNoise(noiseAmount); // add noise
        yield return new WaitForSeconds(duration); // wait for sound to finish
        GameNoise.RemoveNoise(noiseAmount); // remove noise
    }
}
