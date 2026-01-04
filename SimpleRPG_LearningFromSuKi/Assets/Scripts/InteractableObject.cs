using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnClick(NavMeshAgent navMeshAgent)
    {
        navMeshAgent.SetDestination(transform.position);

        Interact();
    }

    protected virtual void Interact()
    {
        print("Interacting with Interactable Object.");
    }
}
