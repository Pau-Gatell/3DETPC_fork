using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public PlayerModel model;
    private PlayerView _view;
    private CharacterController _ctr;
    private PlayerStateMachine _fsm;

    private Vector3 _horizontalMove;
    private Vector3 _verticalMove;
    private bool _grounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _view = transform.parent.GetComponentInChildren<PlayerView>();
        _ctr = transform.parent.GetComponentInChildren<CharacterController>();
        _fsm = transform.parent.GetComponentInChildren<PlayerStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        UpdateView();
    }

    void HandleInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        bool space = Input.GetButtonDown("Jump");

        _horizontalMove = Camera.main.transform.forward * moveY + Camera.main.transform.right * moveX;
        _horizontalMove *= model.speed;

        if (Physics.Raycast(transform.position , -Vector3.up, 0.2f, model.layerMask))
        {
            Debug.Log("Grounded");
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }

        if (_grounded)
        {
            if(space)
            {
                _verticalMove = Vector3.up * 10f;
                Debug.Log("Jump");
            }
            else
            {
                _verticalMove = -Vector3.up * model.gravity;
            }
        }
        else
        {
            _verticalMove = -Vector3.up * model.gravity;
        }

        // Temp
        if(_horizontalMove.magnitude > 0 || _verticalMove.y > 0 )
        {
            if(_verticalMove.y > 0)
            {
                _fsm.ChangeState(PlayerStateMachine.StateType.JUMP);
            }
            else if (_horizontalMove.magnitude > 0)
            {
                _fsm.ChangeState(PlayerStateMachine.StateType.WALK);
            }
        }
        else
        {
            _fsm.ChangeState(PlayerStateMachine.StateType.IDLE);
        }
    }

    void UpdateView()
    {
        _view.UpdateCharacter(_horizontalMove, _verticalMove);
        _view.UpdateTransform();
    }
}
