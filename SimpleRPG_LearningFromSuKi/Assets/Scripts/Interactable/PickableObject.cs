using UnityEngine;

public class PickableObject : InteractableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Interact()
    {
        print("Interacting with pickable item.");
    }
}
