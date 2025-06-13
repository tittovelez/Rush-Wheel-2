using UnityEngine;
using UnityEngine.Events;

public class TutorialPickup : MonoBehaviour
{
    public UnityEvent onPickup;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPickup?.Invoke();
            Destroy(gameObject); // elimina el objeto al recogerlo
        }
    }
}

