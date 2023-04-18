using UnityEngine;

public class ShootItem : MonoBehaviour
{
    public Transform graphics;
    public int damage;
    public float flySpeed,rotateSpeed;

    public void Init(int dmg)
    {
        damage = dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            Debug.Log("Shot the enemy");
            collision.GetComponent<Enemy>().LoseHealth();
            Destroy(gameObject);
        }
        if (collision.tag == "Out")
        {            
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Rotate();
        FlyForward();
    }
    void Rotate()
    {
        graphics.Rotate(new Vector3(0,0,-rotateSpeed*Time.deltaTime));
    }
    void FlyForward()
    {
        transform.Translate(transform.right * flySpeed * Time.deltaTime);
    }

}
