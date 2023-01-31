using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Balloons : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector3 screenBounds;
    private int rand;
    public int collision;

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenBounds.z = 0.0f;

        rand = UnityEngine.Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[rand];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if ((transform.position.x) + 10 < -screenBounds.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COLLISION");
        // Se o balloon colidir com player
        if (other.gameObject.CompareTag("Player") == true)
        {
            Destroy(this.gameObject);
        }
    }

}
