using UnityEngine;

public class Tower : MonoBehaviour
{
    public int health;
    public int cost;
    private Vector3Int cellPosition;

    public virtual void Init(Vector3Int cellPos)
    {
        cellPosition = cellPos;
    }

    public virtual bool LoseHealth(int amount)
    {
        health-= amount;

        if (health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    protected virtual void Die()
    {
        Debug.Log("Tower is dead");
        FindObjectOfType<Spawner>().RevertCellState(cellPosition);
        Destroy(gameObject);
    }
}
