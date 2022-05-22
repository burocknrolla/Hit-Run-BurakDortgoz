using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private PlayerController player;
    Vector3 hitPoint;

    public bulletScriptable bulletType;
    public GameObject partEff;
   
   
    private Color color;
    private float rnd1, rnd2, rnd3;

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
        
        transform.Translate((hitPoint- player.transform.position)* bulletType.bulletSpeed*Time.deltaTime);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shootable"))
        {
            
            rnd1 = Random.Range(0, 2);
            rnd2 = Random.Range(0, 2);
            rnd3 = Random.Range(0, 2);


            color = new Color(rnd1, rnd2, rnd3);


            other.transform.GetComponent<MeshRenderer>().material.color = color;
            other.GetComponent<Shootable>().TakeDamage(bulletType.damage);
            other.GetComponent<Rigidbody>().AddForce(Vector3.forward*bulletType.pushForce);
            Instantiate(partEff, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
