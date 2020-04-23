using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
	private Rigidbody2D rb;
	public float speed;
	public float jumpForce;
	private float moveInput;

	private bool isGrounded;
	public Transform feetPos;
	public float checkRadius;
	public LayerMask whatIsGround;

	private float jumpTimeCounter;
	public float jumpTime;
	private bool isJumping;
	//private int extraJumps;
	public int extraJumpsValue;

    //Dash
    private bool wallJumped;
    public float dashSpeed;

    //Particles
    public ParticleSystem groundTouch;


	// Start is called before the first frame update
	void Start(){
        isGrounded = true;
		//extraJumps = extraJumpsValue;
		rb = GetComponent<Rigidbody2D>();
	}

	//Physics reelated component
	private void FixedUpdate(){
        //Movement 
        moveInput = Input.GetAxisRaw("Horizontal");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");

        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);
		//flipping character
		if (moveInput > 0){
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		else if (moveInput < 0){
			transform.eulerAngles = new Vector3(0, 180, 0);
		}

        if(Input.GetKeyDown(KeyCode.X))
        {
            Dash(xRaw, yRaw);
        }

    }

	// Update is called once per frame
	void Update(){
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

     
        if((Input.GetKeyDown(KeyCode.Space)&& isGrounded)){
            groundTouch.Play();
			rb.velocity = Vector2.up * jumpForce;
		}
	}

    private void Walk(Vector2 dir){
        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));
    }

    private void Dash(float x, float y)
    {
     //   rb.drag *= 5;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x, y);
        rb.velocity += dir.normalized * dashSpeed;

    }
}
