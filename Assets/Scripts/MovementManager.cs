using UnityEngine;

public enum TipoJugador
{
    JUGADOR1, JUGADOR2, CPU
}

public class MovementManager : MonoBehaviour
{
    public float speed;
    private float speedAI = 9.5f;
    public TipoJugador tipo;

    public GameObject ball;
    public Vector2 ballPos;

    private bool dPressed = false;

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
            if (Input.GetKeyDown(KeyCode.D))
            {
                dPressed = true;
            } else if (Input.GetKeyUp(KeyCode.D))
            {
                dPressed = false;
            }
            if (dPressed)
            {
                
            }
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
        
    }

    public void Move()
    {
        ballPos = ball.transform.position; // la posicion

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

    /*public void StartGame()
    {
        if (tipo == TipoJugador.JUGADOR1)
        {
            transform.position = new Vector3(-14f, 0f, 0f);
        }
        else
        {
            transform.position = new Vector3(14f, 0f, 0f);
        }
    }*/


}
