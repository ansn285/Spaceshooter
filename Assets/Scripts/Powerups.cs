using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerups : MonoBehaviour
{
    private Rigidbody2D rb;
    public string power;
    private Canvas missileHelp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        missileHelp = GameObject.Find("MissileHelpCanvas").GetComponent<Canvas>();
    }

    private void Update()
    {
        if (transform.position.y < -19.5f)
        {
            Destroy(gameObject);
        }

    }


    private void FixedUpdate()
    {
        rb.velocity = Vector2.down * 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (power == "health")
            {
                GameObject.Find("Spaceship").GetComponent<PlayerController>().health = 100;
                GameObject.Find("Spaceship").GetComponent<PlayerController>().healthBar.value = 100;
            }
            else
            {
                if (GameObject.Find("GameController").GetComponent<GameController>().showMissileHelp == 1)
                {
                    GameObject.Find("GameController").GetComponent<GameController>().showMissileHelp--;
                    Time.timeScale = 0;
                    missileHelp.enabled = true;
                }
                GameObject.Find("Spaceship").GetComponent<PlayerController>().IncreaseMissiles();
            }
            Destroy(gameObject);
        }
    }

}
