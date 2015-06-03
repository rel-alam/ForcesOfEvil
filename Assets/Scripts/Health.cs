using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int health = 20;
    public int currentHealth;
   // bool damaged;

	// Use this for initialization
	void Start () {

        currentHealth = health;
	
	}
	
	// Update is called once per frame
	void Update () {
       if(currentHealth <= 0)
       {
           Destroy(gameObject);
       }
    }

    public void TakeDamage (int amount)
    {
        currentHealth -= amount;
    }
}
