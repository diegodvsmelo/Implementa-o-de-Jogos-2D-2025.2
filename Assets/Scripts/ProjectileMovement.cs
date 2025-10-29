using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    public int damage = 100;
    public void Setup(Vector2 direction)
    {
        moveDirection = direction;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
