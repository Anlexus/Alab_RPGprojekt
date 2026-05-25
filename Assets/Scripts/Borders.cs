using UnityEngine;

public class Borders : MonoBehaviour
{
    //public GameMaster gameMaster;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.position = new Vector2(-4, 0);
            GameMaster.instance.LoadGame1();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
