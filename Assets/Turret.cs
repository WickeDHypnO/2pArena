using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Turret : MonoBehaviour {

	public float health;
	public Slider healthSlider;
	float maxHealth;
	public GameObject deathParticle;
	void Start()
	{
		transform.DOMoveY(-0.5f, 1f);
		FindObjectOfType<TurretSpawner>().spawnedTurrets.Add(gameObject);
		maxHealth = health;
	}

	public void Damage (float amount) {
		health -= amount;
		healthSlider.value = health / maxHealth;
		if(health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		FindObjectOfType<TurretSpawner>().spawnedTurrets.Remove(gameObject);
		if(FindObjectOfType<TurretSpawner>().spawnedTurrets.Count < 1)
		{
			FindObjectOfType<TurretSpawner>().SpawnNewWave();
		}
		Destroy(gameObject);
	}
}
