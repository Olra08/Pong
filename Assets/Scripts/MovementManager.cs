using UnityEngine;

public enum TipoJugador
{
    JUGADOR1, JUGADOR2
}

public class MovementManager : MonoBehaviour
{
    public float speed;
    public TipoJugador tipo;

    private void Update()
    {
        float movement;
        if (tipo == TipoJugador.JUGADOR1)
        {
            movement = Input.GetAxis("Vertical");
        }
        else
        {
            movement = Input.GetAxis("Vertical2");
        }
        Vector3 actualPos = transform.position;
        transform.position = new Vector3(
            actualPos.x,
            Mathf.Clamp(actualPos.y + (speed * movement * Time.deltaTime), -7f, 7f),
            actualPos.z
        );
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
