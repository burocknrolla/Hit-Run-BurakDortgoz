using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public GameObject bullet;
    
    public GameObject bomb;
    public LayerMask layerMask;
    
    
    public  RaycastHit hit;
    public float fireRate;
    private float nextFire = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            if(Time.time >= nextFire)
            {
                nextFire = Time.time + 1 / fireRate;
                ShootBullet();
            }


        }


        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + 1 / fireRate;
                ShootBomb();
            }

        }

    }

    private void ShootBullet()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.tag == "Shootable")
            {
                
                Debug.Log(hit.transform.name);

                GameObject bull = Instantiate(bullet, transform.position, Quaternion.identity);


            }



        }
    }
    private void ShootBomb()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.tag == "Shootable")
            {

                Debug.Log(hit.transform.name);

                GameObject boom = Instantiate(bomb, transform.position, Quaternion.identity);


            }



        }
    }
}
