using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Coin : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public float range = 10;
    // Start is called before the first frame update
    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.isStopped = false;
        navAgent.speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        GoRandom();
    }
    void GoRandom()
    {
        Vector3 point;
        if (!navAgent.hasPath && RandomPoint(transform.position, range, out point))
        {
            navAgent.SetDestination(point);
            Debug.DrawRay(point, Vector3.up, Color.blue, 35);
        }
    }










    bool RandomPoint(Vector3 center, float range, out Vector3 resul)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                resul = hit.position;
                return true;
            }



        }
        resul = Vector3.zero;
        return false;
    }

}
