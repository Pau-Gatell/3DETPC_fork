using DG.Tweening;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public enum DoorType { Rotating, Sliding }
    public DoorType doorType = DoorType.Rotating;

    [Header("Doors")]
    public Transform leftDoor;
    public Transform rightDoor;

    [Header("Rotation Settings")]
    public Vector3 leftOpenRotation = new Vector3(0, -90, 0);
    public Vector3 rightOpenRotation = new Vector3(0, 90, 0);

    [Header("Sliding Settings")]
    public Vector3 leftSlideDirection = new Vector3(-1f, 0, 0);
    public Vector3 rightSlideDirection = new Vector3(1f, 0, 0);

    [Header("Tween Settings")]
    public float duration = 1.0f;
    public Ease ease = Ease.InOutQuad;

    private Vector3 leftClosedPosition;
    private Vector3 rightClosedPosition;
    private Vector3 leftOpenPosition;
    private Vector3 rightOpenPosition;

    private Vector3 leftClosedRotation;
    private Vector3 rightClosedRotation;

    private bool isOpen = false;

    void Start()
    {
        // Save original positions and rotations
        leftClosedPosition = leftDoor.position;
        rightClosedPosition = rightDoor.position;

        leftClosedRotation = leftDoor.localEulerAngles;
        rightClosedRotation = rightDoor.localEulerAngles;
    }

    public void ToggleDoors()
    {
        if (doorType == DoorType.Rotating)
        {
            RotateDoors();
        }
        else if (doorType == DoorType.Sliding)
        {
            SlideDoors();
        }

        isOpen = !isOpen;
    }

    private void RotateDoors()
    {
        leftDoor.DOLocalRotate(isOpen ? leftClosedRotation : leftOpenRotation, duration).SetEase(ease);
        rightDoor.DOLocalRotate(isOpen ? rightClosedRotation : rightOpenRotation, duration).SetEase(ease);
    }

    private void SlideDoors()
    {
        // Define your open positions in world space here
        leftOpenPosition = leftClosedPosition + leftSlideDirection;
        rightOpenPosition = rightClosedPosition + rightSlideDirection;

        leftDoor.DOMove(isOpen ? leftClosedPosition : leftOpenPosition, duration).SetEase(ease);
        rightDoor.DOMove(isOpen ? rightClosedPosition : rightOpenPosition, duration).SetEase(ease);
    }
}
