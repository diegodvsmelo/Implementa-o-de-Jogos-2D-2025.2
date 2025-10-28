using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private InputActions controls;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controls = new InputActions();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //onEnable e onDisable servem para evitar bugs, otimização e organização do código, evitando inputs indesejados 
    private void OnEnable()
    {
        controls.PlayerControls.Enable();
    }
    private void OnDisable()
    {
        controls.PlayerControls.Disable();
    }
    void Update()
    {
        moveInput = controls.PlayerControls.Move.ReadValue<Vector2>();
        UpdateAnimator();
        FlipSprite();
    }

    private void FlipSprite()
    {
        if(moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }else if(moveInput.x >0)
        {
            spriteRenderer.flipX=false;
        }
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("Speed", moveInput.magnitude);
        //altera a variavel speed dentro do animator com base na magnitude do moveinput, caso o player gere qualquer movimentação no personagem, a magnitude será maior que zero, e dentro do animator, a animação de andar precisa apenas q speed seja maior q 0.1
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
    }
}
