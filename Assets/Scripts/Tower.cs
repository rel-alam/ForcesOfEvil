using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public GameObject bulletPrefab;

	public float rotationSpeed = 35;
    public int attackDamage = 3;
    Health health;


    void Start()
    {
        health = GetComponent<Health>();
    }
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed, Space.World);

        if (health.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
	}
	

	void OnTriggerEnter(Collider co)
	{
		if (co.GetComponent<Player> ()) {
			GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);	
			g.GetComponent<Bullet>().target = co.transform;
			g.GetComponent<Bullet>().owner = this.gameObject;

		}
        if (co.GetComponent<Enemy>())
        {
            GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            g.GetComponent<Bullet>().target = co.transform;
            g.GetComponent<Bullet>().owner = this.gameObject;
        }
	}

}
