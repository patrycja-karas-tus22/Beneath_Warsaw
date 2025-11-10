using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class MovementSettings : MonoBehaviour
{
    [Header("Movement Settings")]
    public Slider movementSlider;
    public DynamicMoveProvider dynamicMoveProvider;

    [Header("Turn Settings")]
    public ContinuousTurnProvider smoothTurn;
    public SnapTurnProvider snapTurn;

    [Header("Vignette Settings")]
    public Transform player;
    public Volume vignetteVolume;
    public float maxIntensity;
    public float currentIntensity = 0f;
    private Vignette vignette;
    private Vector3 lastPosition;
    
    private void Start()
    {
        lastPosition = player.position;

        movementSlider.value = dynamicMoveProvider.moveSpeed;
        movementSlider.onValueChanged.AddListener(UpdateSpeed);

        if (vignetteVolume.profile.TryGet<Vignette>(out var v))
            vignette = v;
    }
    private void Update()
    {
        float movementThreshold = 0.001f;
        if (Vector3.Distance(player.position, lastPosition) > movementThreshold)
            vignette.intensity.value = maxIntensity;
        else
            vignette.intensity.value = 0f;

        lastPosition = player.position;
    }
    private void UpdateSpeed(float newSpeed)
    {
        dynamicMoveProvider.moveSpeed = newSpeed;
    }
    public void SetTurnType(int index)
    {
        if (smoothTurn != null)
            smoothTurn.enabled = (index == 0);

        if (snapTurn != null)
            snapTurn.enabled = (index == 1);

    }

    private void OnDisable()
    {
        movementSlider.onValueChanged.RemoveListener(UpdateSpeed);
    }

    void VignetteOn()
    {

    }
}
