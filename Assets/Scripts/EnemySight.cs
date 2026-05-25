using Unity.VisualScripting;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public int enemyHealth;
    public int enemySpeed = 1;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PreviousPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        targetVector = player.transform.position - transform.position;
        targetVector = targetVector.normalized;
        enemyDir = transform.right;
        enemyDir2 = transform.up;
        dotProduct = Vector2.Dot(enemyDir, targetVector);
        dotAngle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;
        dotResult = Vector2.Dot(enemyDir2, targetVector);
        dotAngle2 = Mathf.Acos(dotResult) * Mathf.Rad2Deg;

        Debug.DrawLine(transform.position, transform.position + transform.right * 10, Color.white);
        Debug.DrawLine(transform.position, transform.position + transform.up * 10, Color.white);
        Debug.Log("Dotangle: " + dotAngle + "\nDotProduct: " + dotProduct);

        if (dotAngle < 80)
        {
            if (hasLineOfSight)
            {
                transform.parent.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
                CurrentPos = StartPos - transform.position.x;

                if (dotAngle2 < 73)
                {
                    transform.Rotate(transform.forward * rotSpeed * Time.deltaTime);

                    body.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                    SpriteRenderer.flipX = body.linearVelocity.x < 0f;

                }
                else if (dotAngle2 >= 107)
                {
                    transform.Rotate(transform.forward * -rotSpeed * Time.deltaTime);
                }

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
    }
}
