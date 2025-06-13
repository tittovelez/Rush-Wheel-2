using System.Collections;
using UnityEngine;
using TMPro;
public class TutorialStep : MonoBehaviour
{
    public TMP_Text text;           // El TextMeshProUGUI
    public GameObject textPanel;    // El Panel que contiene el texto

    public string instruction;
    public bool waitForAction = true; // Si espera acción para continuar

    private bool completed = false;
    private TutorialManager manager;

    public KeyCode key;

    // Detectar cuando el jugador entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !completed)
        {
            text.text = instruction;
            textPanel.SetActive(true); // Mostrar el panel

            PlayerController playerMovement = other.GetComponent<PlayerController>();
            if (playerMovement != null)
            {
                playerMovement.cantmove = true;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(key) && !completed)
        {
            text.text = "";
            textPanel.SetActive(false); // Ocultar el panel
            completed = true;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PlayerController pm = player.GetComponent<PlayerController>();
                if (pm != null) pm.cantmove = false;
            }
        }
    }
}



