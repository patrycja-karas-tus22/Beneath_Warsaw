using UnityEngine;
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

    private void Start()
    {
        movementSlider.value = dynamicMoveProvider.moveSpeed;
        movementSlider.onValueChanged.AddListener(UpdateSpeed);
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
}
