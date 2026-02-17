using UnityEngine;

public class Borders : MonoBehaviour
{
    public GameMaster gameMaster;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameMaster.LoadGame();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
