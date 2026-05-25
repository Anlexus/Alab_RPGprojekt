using TMPro;
using UnityEngine;

public class Village_Smith_Script : MonoBehaviour
{   
    bool playerDetection = false;
    public GameObject d_template;
    public GameObject canva;    

    void Update()
    {
        if (playerDetection && Input.GetKeyDown(KeyCode.E) && !Player.Dialogue)
        {
            canva.SetActive(true);
            Player.Dialogue = true;
            NewDialogue("Not now! Im busy");
            NewDialogue("Bandits lurk out in the woods");
            //NewDialogue("Too much to do, too little time");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }

    }

    void NewDialogue(string text)
    {

        GameObject template_clone = Instantiate(d_template, d_template.transform);

        template_clone.transform.parent = canva.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
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
