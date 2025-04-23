using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private CharacterController _ctr;
    private PlayerController _pctr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _ctr = transform.parent.GetComponentInChildren<CharacterController>();
        _pctr = transform.parent.GetComponentInChildren<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTransform()
    {
        transform.position = _ctr.transform.position;
        _pctr.transform.position = _ctr.transform.position;
    }

    public void UpdateRotation(Vector3 horizontal, float speed)
    {
        if (horizontal.magnitude > 0.1f) // Rotate only when moving
        {
            float targetAngle = Mathf.Atan2(horizontal.x, horizontal.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);

            transform.rotation = Quaternion.Slerp(
            transform.rotation, targetRotation, Time.deltaTime * speed);
        }
    }

    public void UpdateCharacter(Vector3 horizontalMove, Vector3 verticalMove)
    {
        // TO-DO 
        // Updates player position and rotation
        _ctr.Move((horizontalMove + verticalMove) * Time.deltaTime);
    }

    public void UpdateRender()
    {
        // TO-DO 
        // Updates player rendering
    }
}
