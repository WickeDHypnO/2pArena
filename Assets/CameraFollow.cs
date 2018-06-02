using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CameraFollow : MonoBehaviour
{

    public Transform target1;
    public Transform target2;
    public float offsetX;
    public float offsetZ;
    public GameObject gameOverScreen;

    void Update()
    {
        if (target1 && target2)
        {
            transform.position =
            (new Vector3(target1.position.x + offsetX, transform.position.y, target1.position.z + offsetZ)
            + new Vector3(target2.position.x + offsetX, transform.position.y, target2.position.z + offsetZ)) / 2;
        }
        else if (target1)
        {
            transform.position =
                    new Vector3(target1.position.x + offsetX, transform.position.y, target1.position.z + offsetZ);
        }
        else if (target2)
        {
            transform.position =
                   new Vector3(target2.position.x + offsetX, transform.position.y, target2.position.z + offsetZ);
        }
        else
        {
            gameOverScreen.SetActive(true);
            gameOverScreen.GetComponentInChildren<Text>().text = "You died on wave " + (FindObjectOfType<TurretSpawner>().waveNumber - 2);
        }
    }
}
