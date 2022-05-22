using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{

    public float health;
    public GameObject explosion;
    private SpawnWall theWall;

    private void Start()
    {
        theWall = GameObject.FindGameObjectWithTag("TheWall").GetComponent<SpawnWall>();
    }
    private void Update()
    {
       if(health <= 0)
        {
            GameObject boom = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            theWall.wall.Remove(gameObject);
            
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

    }

}
