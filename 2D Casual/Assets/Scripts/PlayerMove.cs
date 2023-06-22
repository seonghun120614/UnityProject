using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float maxSpeed = 1f;
    private float jumpPower = 5f;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            rigidBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
            spriteRenderer.flipX = true;
        else if (Input.GetAxisRaw("Horizontal") > 0)
            spriteRenderer.flipX = false;

        if (Mathf.Abs(rigidBody.velocity.x) < 0.3)
            animator.SetBool("isWalking", false);
        else
            animator.SetBool("isWalking", true);

    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonUp("Horizontal"))
            rigidBody.velocity = new Vector2(rigidBody.velocity.normalized.x * 0.5f, rigidBody.velocity.y);

        rigidBody.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigidBody.velocity.x > maxSpeed)
            rigidBody.velocity = new Vector2(maxSpeed, rigidBody.velocity.y);
        else if (rigidBody.velocity.x < -maxSpeed)
            rigidBody.velocity = new Vector2(-maxSpeed, rigidBody.velocity.y);
    }
}
