using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

public class Score : MonoBehaviour
{

    public int score; //number of enemies destroyed = score
    public Text scText;


    // Update is called once per frame
    void Update()
    {
        scText.text = "Score: " + score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLLISION");
        //If player collides with a balloon
        if (collision.gameObject.CompareTag("Enemy"))
        {
            score += 10;
            Debug.Log("Score: " + score);
        }
    }
}
