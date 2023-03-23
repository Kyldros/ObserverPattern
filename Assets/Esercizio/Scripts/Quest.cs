using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Quest
{
    [SerializeField] public string questName;
    [SerializeField] public string questDescription;
    [SerializeField] public bool complete;
    [SerializeField] public int number;


    public Quest(string questName, string questDescription, bool complete,int number)
    {
        this.questName = questName;
        this.questDescription = questDescription;
        this.complete = complete;
        this.number = number;
    }
}
