using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I pass this class to dialogue manager whenever i wanna start a new dialogue: 
//it contains all informations about a single dialogue
[System.Serializable]
public class Dialogue
{

    public string name; //name of the NPC

    [TextArea(3,10)]
    public string[] sentences; //sentences to be load in the queue

   
}
