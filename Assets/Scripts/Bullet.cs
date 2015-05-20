using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

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

    void OnTriggerEnter(Collider co)
    {
        if (co.name != owner.name)
        {
          health = co.GetComponent<Health>();
          if(owner.name == "Tower")
          {
              health.TakeDamage(owner.GetComponent<Tower>().attackDamage);
              Destroy(gameObject);
          }
            if(owner.name == "Player")
            {
                health.TakeDamage(owner.GetComponent<Player>().attackDamage);
                Destroy(gameObject);
            }
        }
        


    }
}
