using UnityEngine;

public class NPCObject : InteractableObject
{
    public new string name;
    public string[] contentList;

    public DialogueUI dialogueUI;

    
    protected override void Interact()
    {
        dialogueUI.Show(name, contentList);
    }
}
