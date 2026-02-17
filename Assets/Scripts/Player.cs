using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float screenBorder;

    static public bool Dialogue = false;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 smoothMoveInput;
    private Vector2 moveInputSmoothVelocity;
    private Camera _cam;

    int travel = 0;
    static GameObject playerCharacter;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;

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

    void OnSceneLoaded()
    {

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
            0.1f);

            rb.linearVelocity = smoothMoveInput * moveSpeed;

            
        }
        NoOffScreen();
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
}
