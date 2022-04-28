using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    float speed = 6f;
    public GameObject ball;

    // inteligencia vertical
    public Vector2 ballPos;

    // Start is called before the first frame update
    void Update()
    {
        Move();
    }

    void Move()
    {
        ballPos = ball.transform.position; // la posicion

        if (transform.position.y > ballPos.y)
        {
            transform.position += new Vector3(0, (-speed * Time.deltaTime), 0);
        }
        if (transform.position.y < ballPos.y)
        {
            transform.position += new Vector3(0, (speed * Time.deltaTime), 0);
        }
        if (transform.position.y >= -7f)
        {
            transform.position += new Vector3(0, (-speed * Time.deltaTime), 0);
        }
        if (transform.position.y <= 7f)
        {
            transform.position += new Vector3(0, (speed * Time.deltaTime), 0);
        }
        // Mathf.Clamp(-speed * Time.deltaTime, -7f, 7f)
    }
}
