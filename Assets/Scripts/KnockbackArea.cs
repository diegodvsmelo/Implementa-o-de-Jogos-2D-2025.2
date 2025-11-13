using UnityEngine;

public class KnockbackArea : MonoBehaviour
{
    public float knockbackForce;
    [SerializeField] private float effectTime;

    void Start()
    {
        Destroy(this.gameObject, effectTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();

        if (collision.CompareTag("Enemy"))
        {
            EnemyAI enemyAI = collision.GetComponent<EnemyAI>();
            if(enemyAI != null)
            {
                Vector2 direction = (collision.transform.position - transform.position);

                enemyAI.ApplyKnockback(direction, knockbackForce);
            }
        }
    }
}
