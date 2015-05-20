using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	protected float rotationSpeed;
    public float distance;
    


	// Use this for initialization
	void Start () {

       

		GameObject castle = GameObject.Find ("Castle");
        GameObject tower = GameObject.Find("Tower");
        distance = Vector3.Distance(castle.transform.position, tower.transform.position);
		if (distance < 10) {
			GetComponent<NavMeshAgent>().destination = castle.transform.position;
				}
        else
        {
            GetComponent<NavMeshAgent>().destination = tower.transform.position;
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (this.GetComponent<Health>().currentHealth < 0)
        {
            Destroy(gameObject);
        }
	
	}

	void OnTriggerEnter(Collider co)
	{
		if (co.name == "Castle") {
			//co.GetComponentInChildren<Health>().decrease();
			Destroy(gameObject);
				}
	}
}
