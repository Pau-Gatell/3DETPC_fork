using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField]
    public PlayerModel model;
    private PlayerView _view;
    private CharacterController _ctr;
    private PlayerStateMachine _fsm;

    private DoubleJumpSkill doubleJump;

    private Vector3 _horizontalMove;
    private Vector3 _verticalMove;
    private bool _grounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        doubleJump = new DoubleJumpSkill();

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
        _horizontalMove = _horizontalMove.normalized;
        _horizontalMove *= model.speed;
        _horizontalMove.y = 0;

        if (Physics.Raycast(_view.transform.position , -Vector3.up, 0.3f, model.layerMask))
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
                _verticalMove.y = model.jumpGravity;
                Debug.Log("Jump");
            }
            else
            {
                _verticalMove.y = 0;
            }
        }

        if(doubleJump.Use())
        {
            _verticalMove.y = doubleJump.jumpValue;
        }
        else if (!_grounded)
        {
            _verticalMove.y += -model.gravity * Time.deltaTime;
        }
    }

    void UpdateView()
    {
        _view.UpdateCharacter(_horizontalMove, _verticalMove);
        _view.UpdateTransform();
    }

    public bool IsGrounded()
    {
        return _grounded;
    }
}
