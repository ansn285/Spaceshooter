using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.CompareTag("PlayerBullet"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * 15);
            if (transform.position.y > 19.5f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * 15);

            if (transform.rotation.z > 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(6.06f, -19.5f), 15 * Time.deltaTime);
            }
            else if (transform.rotation.z < 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(-6.06f, -19.5f), 15 * Time.deltaTime);
            }
            
            if (transform.position.y < -19.5f)
            {
                Destroy(gameObject);
            }
        }
    }
}
