using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float velocidadeMovimento = 5.0f;
    public float sensibilidadeMouse = 2.0f;
    public Transform cameraTransform; 

    private float rotacaoVertical = 0.0f;
    public float limiteVertical = 60.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        print("Olá Mundo");
    }

    void Update()
    {
        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoZ = Input.GetAxis("Vertical");

        Vector3 movimento = transform.right * movimentoX + transform.forward * movimentoZ;
        transform.Translate(movimento * velocidadeMovimento * Time.deltaTime, Space.World);

        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        transform.Rotate(Vector3.up * mouseX);

        rotacaoVertical -= mouseY;
        rotacaoVertical = Mathf.Clamp(rotacaoVertical, -limiteVertical, limiteVertical);

        cameraTransform.localRotation = Quaternion.Euler(rotacaoVertical, 0f, 0f);
    }
}
