using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    public float minX = -38f;
    public float maxX = 38f;
    public float minY = -21f;
    public float maxY = 22f;

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        //ref velocity permite a função ler e modificar a variável, é a ''memória'' q a função usa para criar o movimento suave
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        //trava (Clamp) os valores X e Y dessa nova posição para nao fugir do limite do mapa
        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX, maxX);
        smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minY, maxY);

        //define a posição final da câmera
        transform.position = smoothedPosition;
    }
}
