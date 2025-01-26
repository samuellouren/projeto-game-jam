using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public string Human_1 = "Player"; // Tag do personagem que a c�mera deve seguir
    public float smoothSpeed = 0.125f; // Suavidade do movimento da c�mera
    public Vector3 offset = new Vector3(0, 1, -10); // Deslocamento padr�o da c�mera em rela��o ao personagem

    private Transform target; // O transform do personagem que a c�mera deve seguir

    private void Start()
    {
        // Tenta encontrar o personagem na cena usando a tag
        target = GameObject.FindGameObjectWithTag(Human_1)?.transform;

        if (target == null)
        {
            Debug.LogError("Nenhum objeto com a tag " + Human_1 + " encontrado. A c�mera n�o seguir� nenhum alvo.");
        }
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Posi��o desejada da c�mera
            Vector3 desiredPosition = target.position + offset;
            // Interpola suavemente a posi��o da c�mera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Atualiza a posi��o da c�mera
            transform.position = smoothedPosition;
        }
    }
}