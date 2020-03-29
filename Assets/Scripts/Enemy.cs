using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject bullet;
    public float startTime;

    private float spawnTime;

    public GameObject particles;
    private Transform cameraHolder;

    private Slider bossHealthBar;

    private void Start()
    {
        spawnTime = startTime;
        if (gameObject.tag == "Boss")
        {
            bossHealthBar = GameObject.Find("/HUD/BossHealthCanvas/BossHealthBar").GetComponent<Slider>();
            cameraHolder = GameObject.Find("CameraHolder").GetComponent<Transform>();
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);

            if (gameObject.CompareTag("Boss"))
            {
                Time.timeScale = 0;
                GameObject.Find("GameWinCanvas").GetComponent<Canvas>().enabled = true;
            }
        }

        if (spawnTime <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            if (gameObject.CompareTag("Boss"))
            {
                //Instantitating 4 more bullets in case the enemy is boss total of 5 bullets
                Instantiate(bullet, new Vector3(Random.Range(-8.2f, 8.2f), transform.position.y, transform.position.z), Quaternion.identity);

                Instantiate(bullet, new Vector3(Random.Range(-8.2f, 8.2f), transform.position.y, 0), Quaternion.identity);

                //Instantiating 2 bullets rotated at an angle of 45 at z axis
                Instantiate(bullet, new Vector3(-4.12f, transform.position.y, 0), transform.rotation * Quaternion.Euler(0, 0, -20));

                Instantiate(bullet, new Vector3(4.12f, transform.position.y, 0), transform.rotation * Quaternion.Euler(0, 0, 20));
            }
            spawnTime = startTime;
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }

        if (gameObject.CompareTag("Boss") && gameObject.transform.position.y > 5f && cameraHolder != null)
        {
            cameraHolder.transform.localPosition = new Vector2(Random.Range(-1f, 1f) * 0.3f, Random.Range(-1f, 1f) * 0.3f);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 5f), 5 * Time.deltaTime);
        }
        else if (cameraHolder != null)
        {
            cameraHolder.position = new Vector2(0, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Instantiate(particles, collision.transform.position, Quaternion.identity);
            health -= 20;
            if (bossHealthBar != null)
            {
                bossHealthBar.value -= 20;
            }
            Destroy(collision.gameObject);
        }

        else if (collision.CompareTag("Missile"))
        {
            Instantiate(particles, collision.transform.position, Quaternion.identity);
            health -= 100;
            if (bossHealthBar != null)
            {
                bossHealthBar.value -= 100;
            }
            Destroy(collision.gameObject);
            GameObject.Find("ExplosionSound").GetComponent<AudioSource>().Play();
        }
        
    }
}
