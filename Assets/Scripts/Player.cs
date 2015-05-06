using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	float health;
	float speed;
	float rotationSpeed;

//	Sword playerSword = new Sword (5, 10);
	
	// Use this for initialization
	void Start () {

		health = 100.0f;
		speed =  5.0f;
		rotationSpeed = 5.0f;	
	}
	
	// Update is called once per frame
	void Update () {
		float speedDt = speed * Time.deltaTime;

		if(Input.GetKey(KeyCode.W))
		   {
			this.transform.position += Camera.main.transform.forward * speedDt;
		}
		else if(Input.GetKey(KeyCode.S))
		{
			this.transform.position -=  Camera.main.transform.forward * speedDt; 
		}

		if (Input.GetKey (KeyCode.A)) {

			this.transform.position -=  Camera.main.transform.right * speedDt;
		}
		else if (Input.GetKey (KeyCode.D)) {
			
			this.transform.position +=  Camera.main.transform.right * speedDt;
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

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Enemy"))
		   {
			if(Input.GetKey(KeyCode.Space))
			{
				print ("hit enemy");
			}
		}
	}


}
