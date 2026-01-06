using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        NormalState,
        FightingState,
        MovingState,
        RestingState,
    }

    private EnemyState state = EnemyState.NormalState;
    private EnemyState childState = EnemyState.RestingState;
    private NavMeshAgent enemyAgent;

    public float restTime = 2;
    private float restTimer = 0;

    public int HP = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.NormalState)
        {
            if (childState == EnemyState.RestingState)
            {
                restTimer += Time.deltaTime;
                if (restTimer > restTime)
                {
                    Vector3 randomPosition = FindRandomPosition();
                    enemyAgent.SetDestination(randomPosition);
                    childState = EnemyState.MovingState;
                }
            }
            else if (childState == EnemyState.MovingState)
            {
                if (enemyAgent.remainingDistance <= 0)
                {
                    restTimer = 0;
                    childState = EnemyState.RestingState;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(30);
        }
    }

    /*IEnumerator NoramalState()
    {
        while (true)
        {
            Vector3 randomPosition = FindRandomPosition();
            enemyAgent.SetDestination(randomPosition);
            while()
        }
    }*/

    Vector3 FindRandomPosition()
    {
        Vector3 randomDir = new Vector3(UnityEngine.Random.Range(-1, 1f), 0, UnityEngine.Random.Range(-1, 1f));
        return transform.position + randomDir.normalized * UnityEngine.Random.Range(2, 5);
    }
    
    public void TakeDamage(int damage)
    {
        HP -= damage;
        
        if(HP <= 0)
        {
            GetComponent<Collider>().enabled = false;
            int count = 4; //UnityEngine.Random.Range(0, 4);
            for (int i = 0; i < count; i++)
            {
                ItemSO item = ItemDBManager.Instance.GetRandomItem();

                GameObject go = GameObject.Instantiate(item.prefab, transform.position, quaternion.identity);
                go.tag = Tag.INTERACTABLE;
                Animator anim = go.GetComponent<Animator>();
                if (anim != false)
                {
                    anim.enabled = false;
                }
                PickableObject po = go.AddComponent<PickableObject>();
                po.itemSO = item;

            }     
            Destroy(this.gameObject);  
        }
    }
}
