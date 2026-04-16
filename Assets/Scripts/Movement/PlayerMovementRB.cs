using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovementRB : MonoBehaviour, IMovementBase
{
    public bool CannotMove { get; set; }

    public bool Grounded { get; private set; }

    [SerializeField]
    [FormerlySerializedAs("moveSpeed")]
    private float _moveSpeed = 5f;
    [SerializeField]
    [FormerlySerializedAs("jumpForce")]
    private float _jumpForce = 3f;
    [SerializeField]
    [FormerlySerializedAs("airBorneSpeed")]
    private float _airBorneSpeed = 2.5f;
    [SerializeField]
    [FormerlySerializedAs("dashForce")]
    private float _dashForce = 5f;

    [SerializeField]
    private float _dashCooldown = 1f;

    [SerializeField]
    [FormerlySerializedAs("canJump")]
    private bool _canJump = false;

    [SerializeField]
    [FormerlySerializedAs("groundTag")]
    private string _groundTag = "Ground";

    private float _horizontalInput = 0.0f;

    private float _lastDashTime = -Mathf.Infinity;

    private Rigidbody _rb;
    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 input)
    {
        _horizontalInput = input.x;
    }

    public void MoveLeft()
    {
        _horizontalInput = -1;
    }

    public void MoveRight()
    {
        _horizontalInput = 1;
    }

    public void StopMoving()
    {
        _horizontalInput = 0;
    }

    public void Jump()
    {
        if (!_canJump || CannotMove)
            return;
        _rb.AddForce(_jumpForce * Vector3.up, ForceMode.Impulse);
        Grounded = false;
    }

    public void RightDash() 
    {
        if(CannotMove)
            return;

        if(Time.time - _lastDashTime < _dashCooldown)
            return;

        _lastDashTime = Time.time;
        _rb.AddForce(_dashForce * Vector3.right, ForceMode.Impulse);
    }

    public void LeftDash()
    {
        if(CannotMove)
            return;

        if(Time.time - _lastDashTime < _dashCooldown)
            return;

        _lastDashTime = Time.time;
        _rb.AddForce(_dashForce * Vector3.left, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        if(!CannotMove && !Mathf.Approximately(_horizontalInput, 0))
        {
            float speed = Grounded? _moveSpeed : _airBorneSpeed;
            _rb.MovePosition(_horizontalInput * speed * Time.fixedDeltaTime * Vector3.right + transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(_groundTag))
        {
            Grounded = true;
        }
    }
}
