using UnityEngine;

public class GameNoise : MonoBehaviour
{
    public static float EnvironmentNoise = 0f;
    public static float decayRate = 1f;
    void Update()
    {
        // Slowly decay environmental noise over time
        EnvironmentNoise = Mathf.MoveTowards(EnvironmentNoise, 0f, decayRate * Time.deltaTime);
    }
    public static void AddNoise(float amount)
    {
        EnvironmentNoise += amount;
        EnvironmentNoise = Mathf.Clamp(EnvironmentNoise, 0f, 1f); // prevent overflows
    }
    public static void RemoveNoise(float amount)
    {
        EnvironmentNoise -= amount;
        EnvironmentNoise = Mathf.Max(EnvironmentNoise, 0f);
    }
}
