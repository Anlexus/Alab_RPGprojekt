using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.VFX;
public class NewDialogue : MonoBehaviour
{
    int index = 0;
    public GameObject currentAgent; //Lagra NPCN vi pratar med
    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && transform.childCount > 1)
        {
            if (Player.Dialogue && index <= 2)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index += 1;
                if (transform.childCount == index)
                {
                    
                    Player.Dialogue = false;
                    
                }
                
            }
            
            else
            {
                Debug.Log("Tobbe");
                Player.Dialogue = false;
                currentAgent.GetComponent<StandardNPC>().EndDialogue();
                index = 0;
                gameObject.SetActive(false);
                

            }
        }
        
    }
}
