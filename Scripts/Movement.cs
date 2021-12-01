using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 targetVelocity;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 1;

    
    [SerializeField]
    private Sprite front;
    [SerializeField]
    private Sprite back;
    [SerializeField]
    private Sprite left;
    [SerializeField]
    private Sprite right;
    

    [SerializeField]
    private Animator animator;

    public bool canMove = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (targetVelocity.x == 0 && targetVelocity.y == 0)
            {
                animator.SetBool("isMoving", false);
            }
            else
            {
                animator.SetBool("isMoving", true);
            }
            rb.velocity = targetVelocity * speed;

            if (targetVelocity == Vector2.up)
            {
                spriteRenderer.sprite = back;
            }
            else if (targetVelocity == Vector2.left)
            {
                spriteRenderer.sprite = left;
            }
            else if (targetVelocity == Vector2.down)
            {
                spriteRenderer.sprite = front;
            }
            else if(targetVelocity==Vector2.right)
            {
                spriteRenderer.sprite = right;
            }
        }
    }
}
