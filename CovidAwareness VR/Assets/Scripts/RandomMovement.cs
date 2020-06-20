using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    NavMeshPath path;
    public float timerForNewPath;
    bool inCoRoutine;
    Vector3 target;


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!inCoRoutine)
            StartCoroutine(DoSomething());

    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 0, z);

        return pos;
    }

    IEnumerator DoSomething()
    {
        inCoRoutine = true;

        yield return new WaitForSeconds(timerForNewPath);

        GetNewPath();

        
        inCoRoutine = false;
    }

    void GetNewPath()
    {
        target = getNewRandomPosition();
        navMeshAgent.SetDestination(target);
    }
}
