using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float range;
	public float damage;

	public virtual void Attack() {}
}


public class Sword : Weapon{



	public override void Attack()
	{

	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.transform.tag == "Enemy")
		{
			GetComponent<Enemy>().TakeDamage(damage);
			print ("Weapon function hit!");
		}
	}
}

