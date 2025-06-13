using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float alturaMinima = 0.5f;
    public float alturaMaxima = 1.5f;
    public float velocidad = 1f;

    private float alturaMedia;
    private float amplitud;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
        alturaMedia = (alturaMinima + alturaMaxima) / 2f;
        amplitud = (alturaMaxima - alturaMinima) / 2f;
    }

    void Update()
    {
        float nuevaY = alturaMedia + Mathf.Sin(Time.time * velocidad) * amplitud;
        transform.position = new Vector3(posicionInicial.x, nuevaY, posicionInicial.z);
    }
}
