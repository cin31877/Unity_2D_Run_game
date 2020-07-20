using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator AN;
    public Rigidbody2D RB;
    public SpriteRenderer SR;
    public GroundCheck GC;
    public float MoveSpeed=20;
    private bool Grounded;
    public float JumpForce = 200;
    public bool DoubleJump;

    private float MaxSpeed;
    void Start()
    {
        AN = gameObject.GetComponent<Animator>();
        SR = gameObject.GetComponent<SpriteRenderer>();
        RB = gameObject.GetComponent<Rigidbody2D>();
        GC = transform.GetChild(0).GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }
    void Moving()
    {
        RB.velocity = new Vector2(0, RB.velocity.y);
        if(Input.GetButton("Horizontal"))
        {
            if(Input.GetAxisRaw("Horizontal")>0)
            {
                SR.flipX = false;
                AN.SetBool("Run", true);
                RB.velocity=new Vector2(MoveSpeed, RB.velocity.y);
                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    AN.SetBool("Slide", true);
                    StartCoroutine(SlideBack());
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                SR.flipX = true;
                AN.SetBool("Run", true);
                RB.velocity = new Vector2(-MoveSpeed, RB.velocity.y);
                if (Input.GetAxisRaw("Vertical")<0)
                {
                    AN.SetBool("Slide", true);
                    StartCoroutine(SlideBack());
                }
            }
        }
        else if(Input.GetButtonUp("Horizontal"))
        {
            AN.SetBool("Run", false);
        }
        if(Input.GetButtonDown("Jump")&& GC.Grounded)
        {
            AN.SetTrigger("Jump");
            DoubleJump = true;
            RB.AddForce(new Vector2(0, JumpForce),ForceMode2D.Impulse);
        }
        else if(Input.GetButtonDown("Jump") && !GC.Grounded&&DoubleJump)
        {
            AN.SetTrigger("DoubleJump");
            DoubleJump = false;
            RB.velocity = new Vector2(RB.velocity.x, 0);
            RB.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        if(GC.Grounded==true)
        {
            AN.SetBool("Landing", true);
        }
        else
        {
            AN.SetBool("Landing", false);
        }
    }
    IEnumerator SlideBack()
    {
        yield return new WaitForSeconds(0.8f);
        AN.SetBool("Slide", false);
    }
}
