using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform target;
    private Rigidbody2D rb;
    private Vector2 normalizedDirection;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        if(target !=null)
        {
            Vector2 direction = target.position - transform.position;
            //a magnitude do vetor direction será maior quanto mais longe estiver do player, fazendo ele se mover mais rapido  quando longe e mais lento quando perto, para evitar isso, basta normalizar o valor
            normalizedDirection = direction.normalized;
        }
        UpdateAnimator();
        FlipSprite();
    }
    void FixedUpdate()
    {
        rb.linearVelocity = normalizedDirection * moveSpeed;
    }
    
    private void UpdateAnimator()
    {
        animator.SetFloat("Speed", normalizedDirection.magnitude);
        //altera a variavel speed dentro do animator com base na magnitude do moveinput, caso o player gere qualquer movimentação no personagem, a magnitude será maior que zero, e dentro do animator, a animação de andar precisa apenas q speed seja maior q 0.1
    }
    private void FlipSprite()
    {
        if(normalizedDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }else if(normalizedDirection.x >0)
        {
            spriteRenderer.flipX=false;
        }
    }
}
