using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour {

    public float speed = 10;
    public Transform target;
    public GameObject owner;
    Health health;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 dir = target.position - transform.position;
            rigidbody.velocity = dir.normalized * speed;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void ExplosionDamage(Vector3 centre, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(centre, radius);

        for(int i = 0; i < hitColliders.Length; i++)
        {

             hitColliders[i].SendMessage("AddDamage", null, SendMessageOptions.DontRequireReceiver);
        }
    }




    void OnTriggerEnter(Collider co)
    {
        if (co.name == "Plane")
        {
            return;
        }
        if (co.name != owner.name)
        {
            health = co.GetComponent<Health>();
            if (owner.name == "Tower")
            {
                health.TakeDamage(owner.GetComponent<Tower>().attackDamage);
                ExplosionDamage(co.transform.position, 5);
                Destroy(gameObject);
            }
            if (owner.name == "Player")
            {
                //print(transform.position);
                
                health.TakeDamage(owner.GetComponent<Player>().attackDamage);
                ExplosionDamage(co.transform.position, 5);
                Destroy(gameObject);
            }
            if (owner.CompareTag("Minion"))
            {
                health.TakeDamage(owner.GetComponent<Enemy>().attackDamage);
                ExplosionDamage(co.transform.position, 5);
                Destroy(gameObject);
            }
        }



    }



}
