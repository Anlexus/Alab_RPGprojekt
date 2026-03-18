using UnityEditor.SearchService;
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

    public void LoadGame1()
    {
        if (_cam == null)
        {
            _cam = GetComponent<Camera>();
        }
        Vector2 ScreenPosition = _cam.WorldToScreenPoint(transform.position);

        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();

            if (scene.buildIndex == 0)
            {
                SceneManager.LoadScene(1);
            }
            else if (scene.buildIndex == 1)
            {
                SceneManager.LoadScene(2);
            }
            else if (scene.buildIndex == 2)
            {
                SceneManager.LoadScene(3);
            }
            else if (scene.buildIndex == 3)
            {
                SceneManager.LoadScene(4);
            }
            else if (scene.buildIndex == 4)
            {
                SceneManager.LoadScene(5);
            }
            else if (scene.buildIndex == 5)
            {
                SceneManager.LoadScene(6);
            }
            else if (scene.buildIndex == 6)
            {
                SceneManager.LoadScene(7);
            }
            else if (scene.buildIndex == 7)
            {
                SceneManager.LoadScene(8);
            }
            else if (scene.buildIndex == 8)
            {
                SceneManager.LoadScene(9);
            }
            else if (scene.buildIndex == 9)
            {            
                SceneManager.LoadScene(1);
            }
            else
            {

            }   
    }

    public void LoadGame2()
    {
        if (_cam == null)
        {
            _cam = GetComponent<Camera>();
        }
        Vector2 ScreenPosition = _cam.WorldToScreenPoint(transform.position);

        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();

        if (scene.buildIndex == 0)
        {
            SceneManager.LoadScene(9);
        }
        else if (scene.buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
        else if (scene.buildIndex == 2)
        {
            SceneManager.LoadScene(1);
        }
        else if (scene.buildIndex == 3)
        {
            SceneManager.LoadScene(2);
        }
        else if (scene.buildIndex == 4)
        {
            SceneManager.LoadScene(3);
        }
        else if (scene.buildIndex == 5)
        {
            SceneManager.LoadScene(4);
        }
        else if (scene.buildIndex == 6)
        {
            SceneManager.LoadScene(5);
        }
        else if (scene.buildIndex == 7)
        {
            SceneManager.LoadScene(6);
        }
        else if (scene.buildIndex == 8)
        {
            SceneManager.LoadScene(7);
        }
        else if (scene.buildIndex == 9)
        {
            SceneManager.LoadScene(8);
        }       
        else
        {

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
