using UnityEngine;

public class EnemyFace : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    public float StartPos;
    public float CurrentPos;
    public float PreviousPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PreviousPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPos = StartPos - transform.position.x;

        if (CurrentPos < PreviousPos)
        {
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingRight", true);
        }
        else if (CurrentPos > PreviousPos)
        {
            animator.SetBool("WalkingRight", false);
            animator.SetBool("WalkingLeft", true);
        }
        else
        {
            animator.SetBool("WalkingRight", false);
            animator.SetBool("WalkingLeft", false);
        }
        PreviousPos = CurrentPos;

    }
}
