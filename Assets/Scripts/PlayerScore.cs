using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0f;
    private float startZ;

    void Start()
    {
        startZ = transform.position.z;
    }

    void Update()
    {
        score = transform.position.z - startZ;
        if (score < 0f) score = 0f;

        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    // Esto se llama cuando el jugador entra en un trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetZone")) // Asegúrate de que el objeto tiene esta tag
        {
            startZ = transform.position.z; // Reinicia el punto de partida
            score = 0f; // Opcional, se actualizará solo igualmente
        }
    }
}
