using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{

    public int column;
    public int row;
    public GameObject shootable;
    public List<GameObject> wall = new List<GameObject>();
    public GameObject endGame;
    public GameObject startPanel;
    public Animator anim;
    private PlayerController player;
    
    public bool go;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.enabled = false;
        go = false;
        startPanel.SetActive(true);
        endGame.SetActive(false);
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        for (int i = 0; i < column; i++)
        {
            for (int j = 0; j < row; j++)
            {
                
               GameObject wallParts = Instantiate(shootable, (transform.position  + new Vector3(i, j, 0)), Quaternion.identity);
                wall.Add(wallParts.gameObject);
            }
        }



    }




    // Update is called once per frame
    void Update()
    {
        anim.SetBool("go", go);

        if (wall.Count <= 0)
        {
            go = true;
            player.enabled = false;
            endGame.SetActive(true);
        }

    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        player.enabled = true;
    }

}
