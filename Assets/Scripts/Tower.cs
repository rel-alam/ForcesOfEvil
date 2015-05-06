using UnityEngine;
using System.Collections;

public class Tower : Enemy {

	// Use this for initialization
	void Start () {
		health = 100.0f;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (health < 0) {
			print("Object Destroyed");
			Destroy(this.gameObject);
		}
	
	}
}
