using UnityEngine;

public enum TipoJugador
{
    JUGADOR1, JUGADOR2, CPU
}

public class MovementManager : MonoBehaviour
{
    public float speed;
    private float speedAI = 20f;
    public TipoJugador tipo;

    public GameObject ball;
    public Vector2 ballPos;

    private bool dPressed = false;
    private bool rightPressed = false;

    private bool aPressed = false;
    private bool leftPressed = false;

    private void Update()
    {
        float movement;
        if (tipo == TipoJugador.JUGADOR1)
        {
            movement = Input.GetAxis("Vertical");
            Vector3 actualPos = transform.position;
            transform.position = new Vector3(
                actualPos.x,
                Mathf.Clamp(actualPos.y + (speed * movement * Time.deltaTime), -7f, 7f),
                actualPos.z
            );
        }
        if (tipo == TipoJugador.JUGADOR2)
        {
            movement = Input.GetAxis("Vertical2");
            Vector3 actualPos = transform.position;
            transform.position = new Vector3(
                actualPos.x,
                Mathf.Clamp(actualPos.y + (speed * movement * Time.deltaTime), -7f, 7f),
                actualPos.z
            );
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                tipo = TipoJugador.CPU;
                ResetPosition();
            }
        }
        if (tipo == TipoJugador.CPU)
        {
            Move();
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                tipo = TipoJugador.JUGADOR2;
            }
        }
        RotateRight();
        RotateLeft();
        ResetPaddle();
    }

    public void Move()
    {
        ballPos = ball.transform.position;

        if (transform.position.y > ballPos.y)
        {
            transform.position += new Vector3(0, (-speedAI * Time.deltaTime), 0);
        }
        if (transform.position.y < ballPos.y)
        {
            transform.position += new Vector3(0, (speedAI * Time.deltaTime), 0);
        }
        if (transform.position.y >= -7f)
        {
            transform.position += new Vector3(0, (-speedAI * Time.deltaTime), 0);
        }
        if (transform.position.y <= 7f)
        {
            transform.position += new Vector3(0, (speedAI * Time.deltaTime), 0);
        }
    }

    public void RotateRight()
    {
        if (tipo == TipoJugador.JUGADOR1)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                dPressed = true;
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                dPressed = false;
                ResetPosition();
            }
            if (dPressed)
            {
                transform.Rotate(new Vector3(0, 0, 3));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rightPressed = true;
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                rightPressed = false;
                ResetPosition();
            }
            if (rightPressed)
            {
                transform.Rotate(new Vector3(0, 0, 3));
            }
        }
        
    }

    public void RotateLeft()
    {
        if (tipo == TipoJugador.JUGADOR1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                aPressed = true;
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                aPressed = false;
                ResetPosition();
            }
            if (aPressed)
            {
                transform.Rotate(new Vector3(0, 0, -3));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                leftPressed = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                leftPressed = false;
                ResetPosition();
            }
            if (leftPressed)
            {
                transform.Rotate(new Vector3(0, 0, -3));
            }
        }
        
    }

    public void ResetPosition()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void ResetPaddle()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tipo == TipoJugador.JUGADOR1)
            {
                transform.position = new Vector3(-14f, 0f, 0f);
            }
            else
            {
                transform.position = new Vector3(14f, 0f, 0f);
            }
        }
    }

}
