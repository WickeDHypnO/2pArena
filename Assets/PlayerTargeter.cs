using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerTargeter : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    Vector3 destination;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        float dist = float.MaxValue;

        foreach (GameObject go in GameManager.players)
        {
            float tempDistance = Vector3.Distance(transform.position, go.transform.position);
            if (tempDistance < dist)
            {
                destination = go.transform.position;
                target = go;
                dist = tempDistance;
            }
        }
        agent.SetDestination(destination);
    }

}
