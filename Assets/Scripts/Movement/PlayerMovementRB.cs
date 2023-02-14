using UnityEngine;

public class PlayerMovementRB : MonoBehaviour, IMovementBase
{
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float jumpForce = 3f;
    [SerializeField]
    float airBorneSpeed = 2.5f;
    [SerializeField]
    float dashForce = 5f;

    [SerializeField]
    string groundTag = "Ground";

    float horizontalInput = 0.0f;

    Rigidbody rb;

    public bool Grounded { get; private set; }
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
        rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        Grounded = false;
    }

    public void RightDash() 
    {
        rb.AddForce(dashForce * Vector3.right, ForceMode.Impulse);
    }

    public void LeftDash()
    {
        rb.AddForce(dashForce * Vector3.left, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if(!Mathf.Approximately(horizontalInput, 0))
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
