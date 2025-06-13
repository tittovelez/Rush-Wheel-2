using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveInput;
    public int maxLives = 3;
    public int currentLives;
    public float accelerationRate = 0.5f;
    public float maxSpeed = 15f;
    public float currentSpeed;
    public bool cantmove;
    public LifeUI lifeUI;
    private bool canAccelerate = false;
    public float jumpForce = 8f;
    private bool isGrounded = true;
    private Rigidbody rb;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (GameData.hasRespawn)
        {
            transform.position = GameData.respawnPosition;
            GameData.hasRespawn = false;
        }
        currentLives = maxLives;
        lifeUI.UpdateLives(currentLives);
        currentSpeed = moveSpeed;
    }

    // Este método detecta cuando el jugador colisiona con un objeto
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartZone"))
        {
            canAccelerate = true;
        }
        if (other.gameObject.CompareTag("Obstaculo")) // Si el jugador toca un objeto con la etiqueta "Obstaculo"
        {
            TakeDamage();  // Reduce las vidas del jugador
            Destroy(other.gameObject);  // Destruye el objeto que tocó el jugador
        }
    }

    void TakeDamage()
    {
        currentLives--;  // Reduce una vida

        lifeUI.UpdateLives(currentLives);  // Actualiza la UI con las vidas restantes

        if (currentLives == 0)  // Si las vidas llegan a 0, el jugador muere
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Game Over");

        // Detener el tiempo (pausa el juego)
        Time.timeScale = 0f;

        // Cambia a la escena de Game Over
        SceneManager.LoadScene("Game Over");  // Asegúrate de que la escena GameOver esté incluida en las Build Settings
    }

    void Update()
    {
        if (cantmove) return;

        moveInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveInput * Time.deltaTime * moveSpeed);

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (canAccelerate)
        {
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += accelerationRate * Time.deltaTime;
                currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
            }
        }
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))   // Asegúrate que el suelo tenga la etiqueta "Ground"
        {
            isGrounded = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
    public void Respawn(Vector3 respawnPosition)
    {
        // Resetear posición y estado
        transform.position = respawnPosition;
        transform.position = GameData.respawnPosition + Vector3.up * 0.5f;

        // Reiniciar variables necesarias
        currentLives = maxLives;
        currentSpeed = moveSpeed;
        cantmove = false;
        canAccelerate = false;

        lifeUI.UpdateLives(currentLives);

        // Reactivar el tiempo si estaba pausado
        Time.timeScale = 1f;
    }

}


