using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public GameObject obstacle;
    public float TimeToSpawn = 1;
    public float SpawnTime;


    [SerializeField]  private Vector2 yAxis;
    [SerializeField]  private Vector2 xAxis;

   public void Spawnner()
    {
        if (!gameOver)
        {
            SpawnTime -= Time.deltaTime;
            float Y =- Random.Range(yAxis.x, yAxis.y);
            float X =- Random.Range(xAxis.x, xAxis.y);
            if(SpawnTime<= 0) {
            SpawnTime= TimeToSpawn;
                Instantiate(obstacle, new Vector2(X, Y), Quaternion.identity).transform.parent = transform;

            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        Spawnner();
    }
}
