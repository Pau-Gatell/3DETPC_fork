using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private CharacterController _ctr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _ctr = transform.parent.GetComponentInChildren<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTransform()
    {
        transform.parent.position = _ctr.transform.position;
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
