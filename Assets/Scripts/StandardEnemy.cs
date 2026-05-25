using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class StandardEnemy : MonoBehaviour
{
    //[SerializeField]
    //private Animator animator;

    public int enemyHealth;
    public int enemySpeed = 1;
    public GameObject enSword;
    private GameObject player;
    private bool hasLineOfSight = false;
    private bool inRange = false;
    public float rotSpeed = 150f;
    public static float dot;
    public float dotProduct;
    public float dotAngle;
    public float dotAngle2;
    public float dotResult;
    private Vector2 targetVector;
    private Vector2 enemyDir;
    private Vector2 enemyDir2;

    private Rigidbody2D body;
    private SpriteRenderer SpriteRenderer;

    public float StartPos;
    public float CurrentPos;
    public float PreviousPos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PreviousPos = transform.position.y;

        body = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
   
    void Update()
    {
        //look for the player or patrolling
        
        //check player range
        //when taking damage you are stunned for 2 seconds        
        targetVector = player.transform.position - transform.position;
        targetVector = targetVector.normalized;
        enemyDir = transform.right;
        enemyDir2 = transform.up;
        dotProduct = Vector2.Dot(enemyDir, targetVector);
        dotAngle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;
        dotResult = Vector2.Dot(enemyDir2, targetVector);
        dotAngle2 = Mathf.Acos(dotResult) * Mathf.Rad2Deg;
      
        Debug.DrawLine(transform.position, transform.position + transform.right * 10,Color.white);
        Debug.DrawLine(transform.position, transform.position + transform.up * 10, Color.white);        
        Debug.Log("Dotangle: " + dotAngle + "\nDotProduct: " + dotProduct);

        
        if (dotAngle < 180)
        {              
            
            if (hasLineOfSight)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
                CurrentPos = StartPos - transform.position.x;
                
                 //if (dotAngle2 < 73)
                 //{
                    //transform.Rotate(transform.forward * rotSpeed * Time.deltaTime);                                        
                //}               
                //else if (dotAngle2 >= 107)
                //{
                  //  transform.Rotate(transform.forward * -rotSpeed * Time.deltaTime);
                //}

                //if(CurrentPos < PreviousPos)
                //{
                //animator.SetBool("WalkingLeft", false);
                //animator.SetBool("WalkingRight", true);
                //}
                //else if (CurrentPos > PreviousPos)
                //{
                //animator.SetBool("WalkingRight", false);
                //animator.SetBool("WalkingLeft", true);
                //}
                //else
                //{
                //animator.SetBool("WalkingRight", false);
                //animator.SetBool("WalkingLeft", false);
                //}
                PreviousPos = CurrentPos;

            }
        }
        else
        {
            hasLineOfSight = false;
        }

        if (inRange == true)
        {
            enSword.SetActive(true);
            StartCoroutine(CoolDownE());
        }        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
           
    }
    IEnumerator CoolDownE()
    {
        yield return new WaitForSeconds(2);
        enSword.SetActive(false);
    }

    public void EnTakingDamage(int damageTaken = 1)
    {
        enemyHealth = enemyHealth - damageTaken;
        hasLineOfSight = false;
        StartCoroutine(CoolDownY());
        
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator CoolDownY()
    {
        yield return new WaitForSeconds(2);
        
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

   
}
