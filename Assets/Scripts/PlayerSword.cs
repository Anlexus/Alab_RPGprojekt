using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    public int SwordDMG = 1;
    public float cooldown;

    void Awake()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit!");
        if (other.tag == "Enemy")
        {
            other.GetComponent<StandardEnemy>().EnTakingDamage(SwordDMG);
            
        }
    }
    
}
