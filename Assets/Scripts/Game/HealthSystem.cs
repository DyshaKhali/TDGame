using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Text txt_healthCount;
    public int defaultHealthCount;
    public int healthCount;
    public GameObject deathScreen;

    public void Init()
    {
        healthCount = defaultHealthCount;
        txt_healthCount.text = healthCount.ToString();
    }

    public void LoseHealth()
    {
        if (healthCount < 1)
            return;

        healthCount--;
        txt_healthCount.text = healthCount.ToString();

        CheckHealthCount();
    }

    void CheckHealthCount()
    {
        if(healthCount<1)
        {
            deathScreen.SetActive(true);
        }
    }
}
