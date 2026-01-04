using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isCollide = Physics.Raycast(ray, out RaycastHit hit);
            if (isCollide)
            {
                if (hit.collider.gameObject.tag == "Gound")
                {
                    navMeshAgent.SetDestination(hit.point);
                }
                else if (hit.collider.gameObject.tag == "Interactable")
                {
                    hit.collider.GetComponent<InteractableObject>().OnClick(navMeshAgent); //A parent class. Do interactable object fund.
                }
            }
        }
    }
}
