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
            // Leer el input del usuario
            movement = Input.GetAxis("Vertical");
        }
        else
        {
            movement = Input.GetAxis("Mouse Y");
        }
        Vector3 actualPos = GetComponent<Transform>().position;
        /*float newPosY = actualPos.y + (speed * movement * Time.deltaTime);
        if (newPosY <= 7 && newPosY >= -7)
        {
            GetComponent<Transform>().position = new Vector3(
                actualPos.x,
                newPosY,
                actualPos.z
            );*/
        GetComponent<Transform>().position = new Vector3(
            actualPos.x,
            Mathf.Clamp(actualPos.y + (speed * movement * Time.deltaTime), -7f, 7f),
            actualPos.z
        );
    }
}
