using UnityEngine;
using UnityEngine.Events;

public class PlayerTutorialInput : MonoBehaviour
{
    public UnityEvent onMove;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            onMove?.Invoke();
            enabled = false; // desactivar para que no se dispare más veces
        }
    }
}

