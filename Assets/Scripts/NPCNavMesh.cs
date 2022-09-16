using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCNavMesh : MonoBehaviour
{
    private NavMeshAgent _NPCAgent;

    public Transform target;
    public List<Transform> targets;
    public int currentTarget;
    public float distance = 0.1f;
    // Start is called before the first frame update
    private void Awake()
    {
        _NPCAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //_NPCAgent.destination = target.position;
        SetWayPoint();
    }

    public void SetWayPoint()
    {
        if (targets.Count == 0)
        {
            Debug.Log("No more way points");
            return;
        }
        Debug.Log(Vector3.Distance(targets[currentTarget].position, transform.position));
        if (Vector3.Distance(targets[currentTarget].position,transform.position) < distance)
        {
            
            currentTarget++;
            if (currentTarget >= targets.Count)
            {
                currentTarget = 0;
            }
        }

        _NPCAgent.SetDestination(targets[currentTarget].position);
    }
}
