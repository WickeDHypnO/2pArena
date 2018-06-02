using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{

    public GameObject shotPrefab;
    public float shotDelay = 0.2f;
    bool shot = false;
    float timer = 0f;
    public bool mouseAim;

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer > shotDelay && mouseAim)
        {
            shot = true;
            Instantiate(shotPrefab, transform.position + transform.forward, Quaternion.LookRotation(transform.forward));
            shot = false;
            timer = 0f;
        }
        if (Input.GetButton("Fire1") && !mouseAim && timer > shotDelay)
        {
            shot = true;
            Instantiate(shotPrefab, transform.position + transform.forward, Quaternion.LookRotation(transform.forward));
            shot = false;
            timer = 0f;
        }
    }
}