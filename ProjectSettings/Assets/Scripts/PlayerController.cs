using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        moveInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveInput * Time.deltaTime * moveSpeed);
    }
}
