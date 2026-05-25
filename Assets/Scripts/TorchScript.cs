using UnityEngine;

public class TorchScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "Player")
        {
            Debug.Log("Torch aqcuired!");
            GameMaster.instance.Addpoint();
            Destroy(gameObject);

        }
    }
}
