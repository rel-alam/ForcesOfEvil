using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Selected : MonoBehaviour {

	public bool IsTargeted = false;
	public bool IsDestroyed = false;

	public RaycastHit hit = new RaycastHit();
	public Ray ray;
	public int number = 0;
	//public Enemy e = new Enemy();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		selection ();
		if (IsTargeted) {
			Debug.Log("Targeted");
				}
		if (IsDestroyed) {
			Destroy(this);
				}
	
	}


	void selection()
	{
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Input.GetKey (KeyCode.Mouse0)) {
						if (Physics.Raycast (ray, out hit, 200.0f)) {
                            if (hit.transform.tag == "Enemy" || hit.transform.tag == "Arrow")
                            {
										if (IsTargeted) {
												//IsDestroyed = true;
						GameObject [] eArray = GameObject.FindGameObjectsWithTag("Minion");
						int objectCount = eArray.Length;
						for (int i = 0; i < objectCount; i++)
						{
							eArray[i].GetComponent<NavMeshAgent>().destination = hit.transform.position;
						}

						//e.GetComponent<NavMeshAgent>().destination = tower.transform.position;
										}

										if (!IsTargeted) {
												IsTargeted = true;
										}
								}
						}
				}
		}
}
