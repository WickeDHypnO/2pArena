using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShotBehavior : MonoBehaviour
{
    public float speed = 1f;
    public float explosionForce = 1f;
    public float explosionRadius = 1f;
    public float damage = 10f;
    public GameObject explpsionEffect;
    public ParticleSystem smoke;
    Rigidbody rigid;
    public bool homing = false;
    public Transform player1, player2;
    public Transform target;
    public float rotationSpeed;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        try
        {
            player1 = FindObjectsOfType<PlayerMovement>()[0].transform;
            player2 = FindObjectsOfType<PlayerMovement>()[1].transform;
        }
        catch { };
        Destroy(gameObject, 40f);
    }

    void FixedUpdate()
    {
        if (!homing)
        {
            rigid.MovePosition(transform.position + transform.forward * speed);
        }
        else
        {
            if (player1 && player2)
            {
                if (Vector3.Distance(transform.position, player1.position) < Vector3.Distance(player2.position, transform.position))
                {
                    target = player1;
                }
                else
                {
                    target = player2;
                }
            }
            else if (player1)
            {
                target = player1;
            }
            else if (player2)
            {
                target = player2;
            }
            else
            {

            }
            rigid.MovePosition(transform.position + transform.forward * speed);
            var q = new Quaternion();
            if(target)
            {
            q = Quaternion.LookRotation(target.position - transform.position);
            }
            
            rigid.rotation = Quaternion.RotateTowards(transform.rotation, q, rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter()
    {
        foreach (Collider c in Physics.OverlapSphere(transform.position, explosionRadius))
        {
            if (!homing)
            {
                if (c.tag == "Turret")
                {
                    c.GetComponent<Turret>().Damage(damage);
                }
                else if (c.tag == "Rocket")
                {
                    Destroy(c.gameObject);
                }
            }
            else
            {
                if (c.tag == "Player")
                {
                    c.GetComponent<PlayerHealth>().TakeDamage(damage);
                }
            }
        }

        Instantiate(explpsionEffect, transform.position, Quaternion.identity);
        smoke.transform.parent = null;
        smoke.Stop();
        Destroy(smoke.gameObject, 2f);
        Destroy(gameObject);
    }
}
