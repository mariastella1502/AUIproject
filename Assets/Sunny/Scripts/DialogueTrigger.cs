using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//assign this script to a GameObject with you wanna start a dialogue
public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;


    public void TriggerDialogue()
    {
        Debug.Log("[TriggerDialogue method running]");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
