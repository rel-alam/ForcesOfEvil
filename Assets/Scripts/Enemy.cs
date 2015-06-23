using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	protected float rotationSpeed;
    public float distance;
    public GameObject bulletPrefab;
    public int attackDamage = 3;
    


	// Use this for initialization
	void Start () {

       

		


	}
	
	// Update is called once per frame
	void Update () {
        GameObject castle = GameObject.Find("Castle");
        GameObject tower = GameObject.Find("Tower");
       // if (tower != null)
       // {
       //     distance = Vector3.Distance(castle.transform.position, tower.transform.position);
       // }
       // else
       // {
       //     distance = 0;
       // }
	   //
       // if (distance < 10)
       // {
       //     GetComponent<NavMeshAgent>().destination = castle.transform.position;
       // }
       // else
       // {
       //     GetComponent<NavMeshAgent>().destination = tower.transform.position;
       // }
	}

	void OnTriggerEnter(Collider co)
	{
		if (co.name == "Castle") 
        {
              GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
              g.GetComponent<Bullet>().target = co.transform;
              g.GetComponent<Bullet>().owner = this.gameObject;
		}
        else if(co.CompareTag("Arrow"))
        {
            GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            g.GetComponent<Bullet>().target = co.transform;
            g.GetComponent<Bullet>().owner = this.gameObject;
        }

        else if (co.CompareTag("Enemy"))
        {
            GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            g.GetComponent<Bullet>().target = co.transform;
            g.GetComponent<Bullet>().owner = this.gameObject;
        }
	}

    void AddDamage()
    {
        GetComponent<Health>().TakeDamage(10);
    }
}
