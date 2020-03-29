using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health = 100;

    public GameObject bullet;
    public Transform gun;

    private float moveX;
    private float tiltX;
    public GameObject particles;
    public Slider healthBar;

    private Rigidbody2D rb;

    [System.NonSerialized] public int missiles;
    public Text missilesText;
    public GameObject missile;

    [System.NonSerialized] public Ray ray;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal") *  speed;
        tiltX = Input.acceleration.x * 25;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.4f, 4.4f), transform.position.y, transform.position.z);

        //Shoot bullets on left click of mouse
        if (Input.GetKeyDown(KeyCode.Space) ^ Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            Instantiate(bullet, gun.position, Quaternion.identity);
        }
        
        //Launch missile on right click of mouse
        if (missiles > 0 && Input.GetMouseButtonDown(1) && Time.timeScale == 1)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Instantiate(missile, new Vector2(transform.position.x + 0.826f, transform.position.y), Quaternion.identity);
            Instantiate(missile, new Vector2(transform.position.x - 0.826f, transform.position.y), Quaternion.identity);
            DecreaseMissiles();
            GameObject.Find("MissileLaunch").GetComponent<AudioSource>().Play();
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX, 0);
        rb.velocity = new Vector2(tiltX, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(particles, collision.transform.position, Quaternion.identity);
            health -= 5;
            healthBar.value -= 5;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "HeavyBullet")
        {
            Instantiate(particles, collision.transform.position, Quaternion.identity);
            health -= 15;
            healthBar.value -= 15;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("BossBullet"))
        {
            Instantiate(particles, collision.transform.position, Quaternion.identity);
            health -= 30;
            healthBar.value -= 30;
            Destroy(collision.gameObject);
        }
    }

    public void IncreaseMissiles()
    {
        missiles++;
        missilesText.text = missiles.ToString();
    }

    public void DecreaseMissiles()
    {
        missiles--;
        missilesText.text = missiles.ToString();
    }

}
