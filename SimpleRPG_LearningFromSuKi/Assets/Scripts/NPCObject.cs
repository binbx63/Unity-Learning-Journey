using UnityEngine;

public class NPCObject : InteractableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Interact()
    {
        print("Interacting with NPC.");
    }
}
