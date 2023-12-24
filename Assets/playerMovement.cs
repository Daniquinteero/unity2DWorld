using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private enum movementState { idle, running, jumping, falling }
    private float dirx;



    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {


        dirx = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (dirx * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 14f);
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        movementState state;

        if (dirx > 0f)
        {
            state = movementState.running;
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state = movementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = movementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = movementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
