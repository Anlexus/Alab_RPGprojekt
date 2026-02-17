using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class NewDialogue : MonoBehaviour
{
    int index = 1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && transform.childCount > 1)
        {
            if (Player.Dialogue)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index += 1;
                if (transform.childCount == index)
                {
                    index = 2;
                    Player.Dialogue = false;
                    
                }
            }
            else
            {
                gameObject.SetActive(false);
                index = 1;
            }
        }
        
    }
}
