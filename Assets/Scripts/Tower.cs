using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public GameObject bulletPrefab;

	public float rotationSpeed = 35;
    public int attackDamage = 3;
    float coolDown = 0.0f;


    void Start()
    {
    }
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
        coolDown -= Time.deltaTime;
	}


    void OnTriggerStay(Collider co)
	{
        if (coolDown <= 0)
        {
            if (co.GetComponent<Player>())
            {
                GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
               // g.GetComponent<Bullet>().target = co.transform;
               // g.GetComponent<Bullet>().owner = this.gameObject;
                g.GetComponent<CannonBall>().target = co.transform;
                g.GetComponent<CannonBall>().owner = this.gameObject;

            }
            if (co.GetComponent<Enemy>())
            {
                GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                //g.GetComponent<Bullet>().target = co.transform;
                //g.GetComponent<Bullet>().owner = this.gameObject;
                g.GetComponent<CannonBall>().target = co.transform;
                g.GetComponent<CannonBall>().owner = this.gameObject;
            }

            coolDown = 3.0f;
        }
	}

}
