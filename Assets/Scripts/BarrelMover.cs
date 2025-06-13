using UnityEngine;

public class BarrelMover : MonoBehaviour
{
    public float velocidad = 2f;
    public float distanciaMaxima = 10f;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Mover hacia adelante
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        // Verificar la distancia recorrida
        float distanciaRecorrida = Vector3.Distance(posicionInicial, transform.position);
        if (distanciaRecorrida >= distanciaMaxima)
        {
            // Reiniciar a la posición inicial
            transform.position = posicionInicial;
        }
    }
}

