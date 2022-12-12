
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
            //Posici�n del Player
            Vector3 desiredPosition = target.position + offset;

            //Interpola la posici�n de la c�mara con la del player en una velocidad definida por _smoothSpeed y Time.deltaTime
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
            //Aplica la posici�n calculada
            transform.position = smoothedPosition;

            //La c�mara siempre debe "mirar" al jugador
            transform.LookAt(transform.position);
        }
    }
}
