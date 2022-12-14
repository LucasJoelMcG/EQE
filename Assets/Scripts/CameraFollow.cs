
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    private float _smoothSpeed = 5f;
    public Vector3 offset;

    void FixedUpdate()
    {
        if (target != null)
        {
            //Posición del Player
            Vector3 desiredPosition = target.position + offset;

            //Interpola la posición de la cámara con la del player en una velocidad definida por _smoothSpeed y Time.deltaTime
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
            //Aplica la posición calculada
            transform.position = smoothedPosition;

            //La cámara siempre debe "mirar" al jugador
            transform.LookAt(transform.position);
        }
    }
}
