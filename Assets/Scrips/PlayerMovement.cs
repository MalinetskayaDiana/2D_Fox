using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*public CharacterController2D controller;*/
    public Animator animator;

    private Rigidbody2D rb;
    float horizontalMove = 0f;
    /*bool jump = false;
    bool crouch = false;*/
    private bool FacingRight = true;
    public float forceJump = 8f;
    [Header("Player Movement Settings")]
    [Range(0, 10f)] public float runSpeed = 1f;
    [Space]
    [Header("Check Settings")]
    public bool isGround = false;
    public bool crouch;
    public Transform CeilCheck;
    public LayerMask whatIsGround;
    private bool isCeiling = false;
    [Range(-5f, 5f)] public float checkGroundOffSetY = -1.8f;
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;
    [Space]
    [Header("Sound Settings")]
    public AudioSource Jimping;
    public AudioSource Death;
    public AudioSource Money;
    public AudioSource Kill;
    public AudioSource Heal;
    float sX, sY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sX = transform.position.x;
        sY = transform.position.y;
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        
        if (horizontalMove < 0 && FacingRight)
        {
            Flip();
        } else if (horizontalMove > 0 && !FacingRight)
        {
            Flip();
        }

        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * forceJump, ForceMode2D.Impulse);
            Jimping.Play();
        }
        
        if (isGround == false)
        {
            animator.SetBool("IsJump", true);
        } else
        {
            animator.SetBool("IsJump", false);
        }

        Crouch();

        /*if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }*/
    }

    private void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 tScale = transform.localScale;
        tScale.x *= -1;
        transform.localScale = tScale;
    }

    private void Crouch()
    {
        if ((Input.GetKey(KeyCode.LeftShift) || isCeiling == true) && isGround == true)
        {
            crouch = true;
            animator.SetBool("IsCrouch", true);
            runSpeed = 0.05f;
        }
        else
        {
            crouch = false;
            animator.SetBool("IsCrouch", false);
            runSpeed = 0.2f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "DeadZone")
        {
            Death.Play();
            transform.position = new Vector3(sX, sY, transform.position.z);
        }

        if (collision.gameObject.name == "NextLevel")
        {
            SceneManager.LoadScene("Level2");
        }

        if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = collision.transform;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Death.Play();
            Destroy(gameObject);
        } 

        if (collision.gameObject.tag == "Cherry")
        {
            Heal.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = null;
        }
    }

    /*public void OnLanding()
    {
        animator.SetBool("IsJump", false);
    }

    public void OnCrouching(bool isCrouch)
    {
        animator.SetBool("IsCrouch", crouch);
    }*/

    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(horizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;
        CheckGround();

        /*isCeiling = Physics2D.OverlapCircle(CeilCheck.position, checkGroundRadius, whatIsGround);

        /* controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
         jump = false;*/
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffSetY), checkGroundRadius);
        if (collider.Length > 1)
        {
            isGround = true;
        } else
        {
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gem")
        {
            Money.Play();
            Gems.TheGem += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Kill.Play();
            Destroy(collision.gameObject);
        }
    }
}
