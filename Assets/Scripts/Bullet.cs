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
        if(co.name == "Plane")
        {
            return;
        }
        if (co.name != owner.name)
        {
          health = co.GetComponent<Health>();
          if (owner.CompareTag("Enemy") || owner.CompareTag("Arrow"))
          {
              health.TakeDamage(owner.GetComponent<Tower>().attackDamage);
              Destroy(gameObject);
          }
            if(owner.name == "Player")
            {
                print(transform.position);
                health.TakeDamage(owner.GetComponent<Player>().attackDamage);
                Destroy(gameObject);
            }
            if (owner.CompareTag("Minion"))
            {
                health.TakeDamage(owner.GetComponent<Enemy>().attackDamage);
                Destroy(gameObject);
            }
        }
        


    }
}
