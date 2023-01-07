using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerO2 : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	public GameObject player;
	private Vector3 lastPosition;

	public HealthBar healthBar;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		lastPosition = player.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		float damage = (player.transform.position - lastPosition).magnitude;
		if(damage != 0)
        {
			TakeDamage(1);
		}
		//TakeDamage(damage);
		lastPosition = player.transform.position;
		/*if (Input.GetAxis("Vertical")>0)
        {
            TakeDamage(1);
        }*/
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}