using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StandardNPC : MonoBehaviour
{
    bool playerDetection = false;
    public GameObject d_template;
    public GameObject canva;

    List<GameObject> template_clone = new List<GameObject>();

    void Update()
    {        
        if (playerDetection && Input.GetKeyDown(KeyCode.E) && !Player.Dialogue)
        {
            
            canva.SetActive(true);
            canva.GetComponent<NewDialogue>().currentAgent = gameObject;
            Player.Dialogue = true;
            NewDialogue("Hello Guy");
            NewDialogue("Welcome to Torchquest");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }       
        
    }

    void NewDialogue(string text)
    {
        GameObject template_instance = Instantiate(d_template, d_template.transform);
        template_instance.transform.parent = canva.transform;
        template_instance.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        template_clone.Add(template_instance);
    }

    public void EndDialogue()
    {
        foreach(GameObject template in template_clone)
        {
            Destroy(template);
        }

        canva.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {            
            playerDetection = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerDetection = false;       
    }
}
