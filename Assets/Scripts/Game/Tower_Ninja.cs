using System.Collections;
using UnityEngine;

public class Tower_Ninja : Tower
{
    public int damage;
    public GameObject prefab_shootItem;
    public float interval;

    protected void Start()
    {
        StartCoroutine(ShootDelay());
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(interval);
        ShootItem();
        StartCoroutine(ShootDelay());
    }

    void ShootItem()
    {
        GameObject shotItem = Instantiate(prefab_shootItem,transform);
        shotItem.GetComponent<ShootItem>().Init(damage);
    }
}
