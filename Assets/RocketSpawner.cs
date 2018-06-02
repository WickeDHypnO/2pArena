using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{

    public float delay;
    public GameObject rocket;
    float timer;
    public Transform player1, player2;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        try
        {
            player1 = FindObjectsOfType<PlayerMovement>()[0].transform;
            player2 = FindObjectsOfType<PlayerMovement>()[1].transform;
        }
        catch { };
    }
    void FixedUpdate()
    {
        if (player1 && player2)
        {
            if (Vector3.Distance(player1.position, transform.position) < Vector3.Distance(player2.position, transform.position))
            {
                transform.rotation = Quaternion.LookRotation(player1.position - transform.position);
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(player2.position - transform.position);
            }
        }
        else if (player1)
        {
            transform.rotation = Quaternion.LookRotation(player1.position - transform.position);
        }
        else if (player2)
        {
            transform.rotation = Quaternion.LookRotation(player2.position - transform.position);
        }
        else
        {

        }
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            if (player1 && player2)
            {
                if (Vector3.Distance(player1.position, transform.position) < Vector3.Distance(player2.position, transform.position))
                {
                    Instantiate(rocket, transform.position, Quaternion.LookRotation(player1.position - transform.position));
                }
                else
                {
                    Instantiate(rocket, transform.position, Quaternion.LookRotation(player2.position - transform.position));
                }
            }
            else if (player1)
            {
                Instantiate(rocket, transform.position, Quaternion.LookRotation(player1.position - transform.position));
            }
            else if (player2)
            {
                Instantiate(rocket, transform.position, Quaternion.LookRotation(player2.position - transform.position));
            }
            else
            {

            }
            timer = 0;
        }
    }
}
