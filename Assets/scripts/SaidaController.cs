using UnityEngine;
using UnityEngine.SceneManagement;

public class SaidaController : MonoBehaviour
{
    public GameObject portao;
    public void AbrirSaida()
    {
        portao.SetActive(false);
    }
    public void Update()
    {
        if (portao.gameObject.activeInHierarchy)
        {
            return;
        }

        if (Vector2.Distance(transform.position, FindFirstObjectByType<PlayerController>().transform.position) < 2)
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
