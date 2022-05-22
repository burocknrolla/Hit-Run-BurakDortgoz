using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    
    private PlayerController player;
    public bombScriptable bombType;
    Vector3 hitPoint;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }
    // Start is called before the first frame update
    void Start()
    {

        hitPoint = player.hit.point;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate((hitPoint - player.transform.position) * bombType.bombSpeed * Time.deltaTime) ;

    }


    private void OnTriggerEnter(Collider other)
    {
        Boom();
        
    }

    public void Boom()
    {
        Collider[] closeObj = Physics.OverlapSphere(transform.position, bombType.rad);

        foreach (Collider nearObjects in closeObj)
        {
            Rigidbody rb = nearObjects.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(bombType.boomForce, transform.position,bombType.rad);
                nearObjects.GetComponent<Shootable>().TakeDamage(bombType.damage);
            }
        }

        Destroy(gameObject);
    }
}
