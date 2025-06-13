using UnityEngine;

public class TimeReducingObject : MonoBehaviour
{
    public float timePenalty = 10f; // Cantidad de tiempo que se restará

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga el tag "Player"
        {
            TimerController timer = FindObjectOfType<TimerController>();
            if (timer != null)
            {
                timer.SubtractTime(timePenalty);
            }

            // Destruye el objeto una vez recogido
            Destroy(gameObject);
        }
    }
}

