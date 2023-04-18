using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health,attackPower;
    public float moveSpeed;
    public Animator animator;
    public float attackInterval;
    Coroutine attackOrder;
    Tower detectedTower;

    void Update()
    {
        if(!detectedTower)
        {
            Move();
        }        
    }

    IEnumerator Attack()
    {
        animator.Play("Attack",0,0);
        yield return new WaitForSeconds(attackInterval);
        attackOrder = StartCoroutine(Attack());
    }

    void Move()
    {
        animator.Play("Move");
        transform.Translate(-transform.right*moveSpeed*Time.deltaTime);
    }

    public void InflictDamage()
    {
        bool towerDied = detectedTower.LoseHealth(attackPower);

        if (towerDied)
        {
            detectedTower = null;
            StopCoroutine(attackOrder);
        }
    }

    public void LoseHealth()
    {
        health--;
        StartCoroutine(BlinkRed());
        if(health<=0)
            Destroy(gameObject);
    }

    IEnumerator BlinkRed()
    {
        GetComponent<SpriteRenderer>().color=Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color=Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (detectedTower)
            return;

        if(collision.tag == "Tower")
        {
            detectedTower = collision.GetComponent<Tower>();
            attackOrder = StartCoroutine(Attack());
        } else if (collision.tag == "EnemyWin")
        {
            GameManager.instance.health.LoseHealth();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EnemyWin")
        {
            Destroy(gameObject);
        }
    }
}
