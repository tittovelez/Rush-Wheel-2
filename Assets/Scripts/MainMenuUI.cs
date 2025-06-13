using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject optionsMenuUI;

    public void OpenOptions()
    {
        mainMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}


