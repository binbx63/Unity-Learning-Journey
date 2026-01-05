using UnityEngine;

public class NPCObject : InteractableObject
{
    public new string name;
    public string[] contentList;


    
    protected override void Interact()
    {
        DialogueUI.Instance.Show(name, contentList);
    }
}
