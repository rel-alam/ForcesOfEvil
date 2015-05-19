using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	float health;
	float speed;
	float rotationSpeed;
	public GameObject bulletPrefab;
	Sword sword;

//	Sword playerSword = new Sword (5, 10);
	
	// Use this for initialization
	void Start () {

		health = 100.0f;
		speed =  5.0f;
		rotationSpeed = 5.0f;	
		sword = new Sword ();
		sword.damage = 10.0f;
		sword.range = 15.0f;
	}
	
	// Update is called once per frame
	void Update () {
		float speedDt = speed * Time.deltaTime;

		if(Input.GetKey(KeyCode.W))
		   {
			this.transform.position += new Vector3(0, 0, speedDt);
		}
		else if(Input.GetKey(KeyCode.S))
		{
			this.transform.position -= new Vector3(0, 0, speedDt); 
		}

		if (Input.GetKey (KeyCode.A)) {

			this.transform.position -= new Vector3(speedDt, 0, 0);
		}
		else if (Input.GetKey (KeyCode.D)) {
			
			this.transform.position += new Vector3(speedDt, 0, 0);
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.Rotate(0, rotationSpeed, 0);
		}
		else if(Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.Rotate(0, -rotationSpeed, 0);
			print ("Pushed Left Arrow");
		}

	}

	void OnTriggerStay(Collider co)
	{
		if (Input.GetKey (KeyCode.Space)) {
						if (co.GetComponent<Tower> ()) {
								GameObject g = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);	
								g.GetComponent<Bullet> ().target = co.transform;
						}
				}
	}


}
