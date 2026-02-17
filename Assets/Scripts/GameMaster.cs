using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    int tcount;
    private float screenBorder;
    private Camera _cam;
    int eon = 0;    
    void Start()
    {
        _cam = GetComponent<Camera>();
                   
    }

    public void LoadGame()
    {
        Vector2 ScreenPosition = _cam.WorldToScreenPoint(transform.position);

        Scene scene = SceneManager.GetActiveScene();

        if (scene.buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }        
        else

        {
            eon = 2;
        }
       
        
    }

    void Update()
    {
        if (!Player.Dialogue)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
