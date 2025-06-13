using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public Transform respawnPoint; // Asigna el punto deseado desde el editor

    public void RestartGame()
    {
        GameData.respawnPosition = respawnPoint.position;
        GameData.hasRespawn = true;

        SceneManager.LoadScene("SampleScene"); // Usa el nombre exacto
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}