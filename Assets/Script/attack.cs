using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Legume"))
            {
                Destroy(enemy.gameObject);
            }
          
        }
    }
}