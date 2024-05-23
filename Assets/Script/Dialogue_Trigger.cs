using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool isInRange;
    private Text interacUI;

    private void Awake()
    {
        interacUI = GameObject.FindGameObjectWithTag("InteracUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interacUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interacUI.enabled = false;
            Dialogue_Manager.instance.EndDialogue();
        }
    }

    void TriggerDialogue()
    {
        Dialogue_Manager.instance.StartDialogue(dialogue);
    }
}
