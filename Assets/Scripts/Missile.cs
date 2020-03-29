using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.Find("Spaceship").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.ray.origin, 7 * Time.deltaTime);

        if (transform.position == player.ray.origin)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)player.ray.origin - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * 200;

    }

}
