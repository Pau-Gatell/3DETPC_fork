using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class LeverController : MonoBehaviour
{
    [Header("Lever Settings")]
    public Transform leverHandle;
    public Vector3 onRotation = new Vector3(-45f, 0f, 0f);
    public Vector3 offRotation = new Vector3(45f, 0f, 0f);

    [Header("Tween Settings")]
    public float duration = 0.5f;
    public Ease ease = Ease.OutBack;

    [Header("Events")]
    public UnityEvent onLeverOn;
    public UnityEvent onLeverOff;

    private bool isOn = false;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleLever();
        }
    }

    public void ToggleLever()
    {
        if (leverHandle == null) return;

        Debug.Log("Toggled door");
        leverHandle.DOLocalRotate(isOn ? offRotation : onRotation, duration).SetEase(ease);

        if (isOn)
            onLeverOff.Invoke();
        else
            onLeverOn.Invoke();

        isOn = !isOn;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTERED door " + other.tag);

        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}