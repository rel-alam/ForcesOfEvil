using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	float speed;
	float rotationSpeed;
	public GameObject bulletPrefab;
    public float coolDown;
    public int attackDamage = 3;

    bool melee = false;

	
	// Use this for initialization
	void Start () {

		speed =  5.0f;
		rotationSpeed = 5.0f;	
        coolDown = 3.0f;

	}
	
	// Update is called once per frame
	void Update () {
		float speedDt = speed * Time.deltaTime;
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

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

		//if(Input.GetKey(KeyCode.RightArrow))
		//{
		//	this.transform.Rotate(0, rotationSpeed, 0);
		//}
		//else if(Input.GetKey(KeyCode.LeftArrow))
		//{
		//	this.transform.Rotate(0, -rotationSpeed, 0);
		//	print ("Pushed Left Arrow");
		//}

        if (Input.GetKeyDown(KeyCode.LeftShift) && melee != true)
        {
            melee = true;
            print("Melee is On");
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            melee = false;
            print("Melee is off -- Now ranging");
        }



        

	}

	void OnTriggerStay(Collider co)
	{
		if (Input.GetKey (KeyCode.Space) && coolDown <= 0) 
        {
			if (co.GetComponent<Tower> () && melee == false) 
            {
				GameObject g = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);	
				g.GetComponent<Bullet>().target = co.transform;
				g.GetComponent<Bullet>().owner = this.gameObject;

                
            }
            else if(co.GetComponent<Tower>() && melee == true && Vector3.Distance (this.transform.position, co.transform.position) < 5)
            {
                co.GetComponent<Tower>().GetComponent<Health>().TakeDamage(100);
            }

            coolDown = 3.0f;
        }
	}


    void AddDamage()
    {
        GetComponent<Health>().TakeDamage(10);
    }


}
