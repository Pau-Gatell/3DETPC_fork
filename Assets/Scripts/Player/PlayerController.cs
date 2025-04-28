using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField]
    public PlayerModel model;
    private PlayerView _view;
    private CharacterController _ctr;
    private PlayerStateMachine _fsm;
    private Animator _animator;

    private DoubleJumpSkill doubleJump;

    private Vector3 _horizontalMove;
    private Vector3 _verticalMove;
    private bool _grounded;
    private bool _attacking = false;
    private bool _running = false;

    public LayerMask attackMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        doubleJump = new DoubleJumpSkill();

        _animator = transform.parent.GetComponentInChildren<Animator>();
        _view = transform.parent.GetComponentInChildren<PlayerView>();
        _ctr = transform.parent.GetComponentInChildren<CharacterController>();
        _fsm = transform.parent.GetComponentInChildren<PlayerStateMachine>();

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        if (_attacking)
            return;

        UpdateView();
    }

    void HandleInput()
    { 
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        bool space = Input.GetButtonDown("Jump");

        float speed = _running ? model.runSpeed : model.speed;
        _horizontalMove = Camera.main.transform.forward * moveY + Camera.main.transform.right * moveX;
        _horizontalMove = _horizontalMove.normalized;
        _horizontalMove *= speed;
        _horizontalMove.y = 0;
        _animator.SetFloat("Speed", _horizontalMove.magnitude);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Player Attacked");
            _animator.SetBool("Attack", true);
            _attacking = true;
            StartCoroutine(AttackTransition());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _animator.SetBool("Run", true);
            _running = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animator.SetBool("Run", false);
            _running = false;
        }

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
        _view.UpdateRotation(_horizontalMove, model.rotationSpeed);
        _view.UpdateCharacter(_horizontalMove, _verticalMove);
        _view.UpdateTransform();
    }

    public bool IsGrounded()
    {
        return _grounded;
    }

    IEnumerator AttackTransition()
    {
        bool hit = Physics.SphereCast(transform.position + new Vector3(0, 1f, 0), 2f, transform.forward, out RaycastHit hitInfo, 3f, attackMask);

        if (hit)
        {
            AIPatrol patrol = hitInfo.collider.GetComponent<AIPatrol>();
            if(patrol)
            {
                patrol.Kill();
                Debug.Log("Le he dado al enemigo");
            }
            Debug.Log(hitInfo.collider.name);
        }
        else
        {
            Debug.Log("no hit");
        }

        yield return new WaitForSeconds(1f);

        _animator.SetBool("Attack", false);
        _attacking = false;
    }
}
