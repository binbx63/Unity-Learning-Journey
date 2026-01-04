using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private bool haveInteracted = false;
    public void OnClick(NavMeshAgent navMeshAgent)
    {
        this.navMeshAgent = navMeshAgent;
        navMeshAgent.stoppingDistance = 2;
        navMeshAgent.SetDestination(transform.position);
        haveInteracted = false;


    }

    private void Update()
    {
        if(navMeshAgent != null && !haveInteracted && navMeshAgent.pathPending == false) //如果还在计算路径，则剩余距离判断可能有误
        {
            if(navMeshAgent.remainingDistance <= 2)
            {
                Interact();
                haveInteracted = true;
            }
        }
    }

    protected virtual void Interact()
    {
        print("Interacting with Interactable Object.");
    }
}
