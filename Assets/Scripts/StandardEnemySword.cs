using UnityEngine;

public class StandardEnemySword : MonoBehaviour
{
    public int EnSwordDMG = 1;
    public float cooldown;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");

        if (other.tag == "Player")
        {
            other.GetComponent<Player>().TakingDamage(EnSwordDMG);
            Destroy(gameObject);
        }
    }
}
