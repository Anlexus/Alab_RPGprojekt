using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class StandardEnemy : MonoBehaviour
{
    public int enemyHealth;
    public int enemySpeed = 1;
    public GameObject enSword;
    private GameObject player;
    private bool hasLineOfSight = false;
    private bool rotateLeft = false;
    private bool rotateRight = false;
    public float rotSpeed = 150f;
    public static float dot;
    public float dotProduct;
    public float dotAngle;    
    private Vector2 targetVector;
    private Vector2 enemyDir;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
   
    void Update()
    {
        //look for the player or patrolling
        //if seeing player you approach
        //when in range attack
        //when taking damage you are stunned for 2 seconds        
        targetVector = player.transform.position - transform.position;
        targetVector = targetVector.normalized;
        enemyDir = transform.right;
        dotProduct = Vector2.Dot(enemyDir, targetVector);
        dotAngle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;
        
        //Debug.Log(dotProduct);
        //Debug.Log(dotAngle);
        Debug.DrawLine(transform.position, transform.position + transform.right * 10,Color.white);
        //rotateRight = true;

        Debug.Log("Dotangle: " + dotAngle + "\nDotProduct: " + dotProduct);

        rotateLeft = true;
        if (dotAngle < 80)
        {            
            hasLineOfSight = true;
            if (hasLineOfSight)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);

                if (dotAngle < 0 )
                {
                    transform.Rotate(transform.forward * rotSpeed * Time.deltaTime);
                }
                if (rotateLeft == true)
                {
                    transform.Rotate(transform.forward * -rotSpeed * Time.deltaTime);
                }
                
            }            
        }
        else
        {
            hasLineOfSight = false;
        }
        
    }

    private void FixedUpdate()
    {
        
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            hasLineOfSight = ray.collider.CompareTag("Player");
            if (hasLineOfSight == true)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }
    public void Attacking()
    {

    }

    public void EnTakingDamage(int damageTaken = 1)
    {
        enemyHealth = enemyHealth - damageTaken;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
