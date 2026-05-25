using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float screenBorder;

    [SerializeField]
    private Animator animator;

    static public bool Dialogue = false;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 smoothMoveInput;
    private Vector2 moveInputSmoothVelocity;
    private Camera _cam;
    public int playerHealth = 10;
    public int pdmg = 1;
    public int travel;
    public GameObject swordSwing;
    static GameObject playerCharacter;

    public int torch = 0;

    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        //_cam = Camera.main;
        if(_cam == null)
        {
            _cam = FindFirstObjectByType<Camera>();
        }
        
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();

        if (playerCharacter == null)
        {
            playerCharacter = gameObject;

            DontDestroyOnLoad(playerCharacter);
            
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    
    void Update()
    {

        if(_cam == null)
        {
            _cam = Camera.main;
            transform.position = new Vector2(0f, 0f);
        }

        if (!Dialogue) { 
            smoothMoveInput = Vector2.SmoothDamp(
            smoothMoveInput,
            moveInput,
            ref moveInputSmoothVelocity,
            0f);

            rb.linearVelocity = smoothMoveInput * moveSpeed;            
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("WalkingRight", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("WalkingRight", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("WalkingLeft", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("WalkingLeft", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            swordSwing.SetActive(true);
            StartCoroutine(CoolDown());
        }
        NoOffScreen();
        Debug.DrawLine(transform.position, transform.position + transform.right * 10, Color.black);
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(2);
        swordSwing.SetActive(false);
    }

    private void NoOffScreen()
    {
        Vector2 ScreenPosition = _cam.WorldToScreenPoint(transform.position);

        if ((ScreenPosition.x < screenBorder && rb.linearVelocity.x < 0) || (ScreenPosition.x > _cam.pixelWidth - screenBorder && rb.linearVelocity.x > 0))
        {
            travel = 1;
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        if ((ScreenPosition.y < screenBorder && rb.linearVelocity.y < 0) || (ScreenPosition.y > _cam.pixelHeight - screenBorder  && rb.linearVelocity.y > 0))
        {
            travel = 2;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void TakingDamage(int damageTaken = 1)
    {
        playerHealth = playerHealth - damageTaken;

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {       

        if (other.tag == "Torch")
        {
            torch += 1;

        }
    }
}
