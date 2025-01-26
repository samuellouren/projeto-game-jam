using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public string Human_1 = "Player"; // Tag do personagem que a câmera deve seguir
    public float smoothSpeed = 0.125f; // Suavidade do movimento da câmera
    public Vector3 offset = new Vector3(0, 1, -10); // Deslocamento padrão da câmera em relação ao personagem

    private Transform target; // O transform do personagem que a câmera deve seguir

    private void Start()
    {
        // Tenta encontrar o personagem na cena usando a tag
        target = GameObject.FindGameObjectWithTag(Human_1)?.transform;

        if (target == null)
        {
            Debug.LogError("Nenhum objeto com a tag " + Human_1 + " encontrado. A câmera não seguirá nenhum alvo.");
        }
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Posição desejada da câmera
            Vector3 desiredPosition = target.position + offset;
            // Interpola suavemente a posição da câmera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Atualiza a posição da câmera
            transform.position = smoothedPosition;
        }
    }
}