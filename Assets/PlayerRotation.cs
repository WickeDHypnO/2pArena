using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    Rigidbody rigid;
    public bool mouseAim;
    public string XAxisName, YAxisName;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (mouseAim)
        {
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float hitdist = 0.0f;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                rigid.MoveRotation(targetRotation);
            }
        }
        else
        {
            Vector3 rotation = Vector3.right * Input.GetAxis(XAxisName) + Vector3.forward * -Input.GetAxis(YAxisName);
            Quaternion targetRotation = Quaternion.LookRotation(rotation);
            rigid.MoveRotation(targetRotation);
        }
    }
}
