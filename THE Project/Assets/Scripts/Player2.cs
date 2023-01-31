using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    private int speed;
    private Vector2 screenBounds;
    public int health;
    private float playerWidth;
    private float playerHeight;
    public Animator animator;
    public GameObject[] hearts;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject deathPanel;

    private void Awake()
    {
        Time.timeScale = 1; //isto faz com que o jogo comece assim que a cena � carregada,
                            //o que impede o jogo de ficar parado no in�cio do n�vel assim
                            //que se muda de mapa
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        Debug.Log("A correr !");
        animator.SetBool("Alive", true);

        // Calcula limites do ecr�
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // Calcula dimens�es do jogador/sprite
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) // Chama a funcao Dead
            StartCoroutine(ExampleCoroutine());

        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        
        //Movimento na Horizontal
        if (dx != 0)
        {
            transform.Translate(dx * speed * Time.deltaTime, 0, 0);
        }

        //Movimento na Vertical
        if (dy != 0)
        {
            transform.Translate(0, dy * speed * Time.deltaTime, 0);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                pause();
            }else
            {
                resume();
            }
        }

    }

    // Update every frame if possible.
    // Call after all update functions.
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        // Keep the position in the limits of the screen
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + playerWidth, screenBounds.x - playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + playerHeight, screenBounds.y - playerHeight);

        transform.position = viewPos;
    }


    // Is Dead?
    void Dead()
    {
        animator.SetBool("Alive", false);
    }

    IEnumerator ExampleCoroutine()
    {
        Dead();
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        deathPanel.SetActive(true);
        Time.timeScale = 0; //Stops the game
    }


    public int GetHealth()
    {
        return health;
    }
    public void UpdateHealth()
    {
        health--;
        Debug.Log("HP = " + health);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLLISION");
        //If player collides with a balloon
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
            Destroy(hearts[health].gameObject);
            Debug.Log("HP: " + health);
        }
    }


    //PAUSE
    public void pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    //RESUME
    public void resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

}
