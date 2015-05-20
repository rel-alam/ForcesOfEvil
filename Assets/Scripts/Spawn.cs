using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject monsterPrefab;

	public float interval = 3;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnNext", interval, interval);
	
	}
	void SpawnNext()
	{
		Instantiate (monsterPrefab, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
