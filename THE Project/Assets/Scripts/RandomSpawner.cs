using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class RandomSpawner : MonoBehaviour
{
    public GameObject Obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;
    public  int count; //number of enemies destroyed

    int[] Difficulty = { 20, 40, 60, 80, 100 }; //number of balloons destroyed

    //public Text scoreText;

    private void Start()
    {
        secondsBetweenSpawn = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        //spawnTime = Time.time + TimeBetweenSpawn;
        elapsedTime += Time.deltaTime;
        IncreaseDif();
        //scoreText.text = "Score: " + count.ToString();
    }

    void Spawn()
    {
        float X = Random.Range(minX, maxX);
        float Y = Random.Range(minY, maxY);

        //Instantiate(Obstacle, transform.position + new Vector3(X, Y, 0), transform.rotation);

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            GameObject newEnemy = (GameObject)Instantiate(Obstacle, new Vector3(X, Y, 0), Quaternion.Euler(0, 0, 0));
            count++;
        }
    }
    void IncreaseDif()
    {
        if (count == 20)
            secondsBetweenSpawn = 2.5f;
        if (count == 40)
            secondsBetweenSpawn = 2.25f;
        if (count == 60)
            secondsBetweenSpawn = 2.0f;
        if (count == 80)
            secondsBetweenSpawn = 1.75f;
        if (count == 100)
            secondsBetweenSpawn = 1.5f;
        if (count == 120)
            secondsBetweenSpawn = 1.0f;
        if (count == 666)
            secondsBetweenSpawn = 0.5f;

    }
}
