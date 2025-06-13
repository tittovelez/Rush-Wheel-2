using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public TMP_Text instructionText;

    public void ShowInstruction(string instruction)
    {
        instructionText.text = instruction;
    }

    public void NextStep()
    {
        // Lógica para avanzar al siguiente paso si quieres controlar pasos manualmente
        Debug.Log("Avanzando al siguiente paso...");
    }
}



