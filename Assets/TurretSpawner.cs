using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TurretSpawner : MonoBehaviour
{
    public List<Transform> points;
    public GameObject turret;
    public int waveNumber;
    public List<GameObject> spawnedTurrets;
	public GameObject player1, player2;
	public GameObject waveText;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		//SpawnNewWave();
	}
    public void SpawnNewWave()
    {
		waveText.GetComponent<Text>().text = "Wave\n" + (waveNumber-1);
		waveText.GetComponent<CanvasGroup>().alpha = 1;
		waveText.GetComponent<CanvasGroup>().DOFade(0, 1f);
		if(FindObjectsOfType<PlayerMovement>().Length < 2)
		{
			if(FindObjectsOfType<PlayerMovement>().Length < 1)
			{
				Instantiate(player1, Vector3.zero, Quaternion.identity);
				Instantiate(player2, new Vector3(1,0,1), Quaternion.identity);
			}
			else
			{
				if(FindObjectsOfType<PlayerMovement>()[0].secondPlayer)
				{
					Instantiate(player1, Vector3.zero, Quaternion.identity);
				}
				else
				{
					Instantiate(player2, new Vector3(1,0,1), Quaternion.identity);
				}
			}
		}
        waveNumber++;
        List<Transform> unusedPoints = new List<Transform>(points);
        for (int i = 0; i < waveNumber; i++)
        {
			int index = Random.Range(0, unusedPoints.Count);
			Instantiate(turret, unusedPoints[index].position, Quaternion.identity);
			unusedPoints.RemoveAt(index);
        }
    }

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
