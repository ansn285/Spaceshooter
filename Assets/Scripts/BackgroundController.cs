using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Transform background1;
    public Transform background2;
    public float speed;

    private void Update()
    {
        if (background1.position.y <= -19.2f)
        {
            background1.position = new Vector3(0, 19.2f, 0);
        }
        else if (background2.position.y <= -19.2f)
        {
            background2.position = new Vector3(0, 19.2f, 0);
        }
    }

    public void FixedUpdate()
    {
        background1.transform.position = Vector3.MoveTowards(background1.position, new Vector3(0f, -19.2f, 0), speed * Time.fixedDeltaTime);
        background2.transform.position = Vector3.MoveTowards(background2.position, new Vector3(0f, -19.2f, 0), speed * Time.fixedDeltaTime);
    }
}
