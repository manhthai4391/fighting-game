using UnityEngine;

public class PlayerMovementRB : MonoBehaviour, IMovementBase
{
    public bool CannotMove { get; set; }

    public bool Grounded { get; private set; }

    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float jumpForce = 3f;
    [SerializeField]
    float airBorneSpeed = 2.5f;
    [SerializeField]
    float dashForce = 5f;

    [SerializeField]
    bool canJump = false;

    [SerializeField]
    string groundTag = "Ground";

    float horizontalInput = 0.0f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 input)
    {
        horizontalInput = input.x;
    }

    public void Jump()
    {
        if (!canJump || !CannotMove)
            return;
        rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        Grounded = false;
    }

    public void RightDash() 
    {
        if(!CannotMove)
            rb.AddForce(dashForce * Vector3.right, ForceMode.Impulse);
    }

    public void LeftDash()
    {
        if(!CannotMove)
            rb.AddForce(dashForce * Vector3.left, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if(!Mathf.Approximately(horizontalInput, 0) && !CannotMove)
        {
            float speed = Grounded? moveSpeed : airBorneSpeed;
            rb.MovePosition(horizontalInput * speed * Time.fixedDeltaTime * Vector3.right + transform.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(groundTag))
        {
            Grounded = true;
        }
    }
}
