using UnityEngine;

public class AlavancaManeger : MonoBehaviour
{
    public int AlavancasAtivas;
    public SaidaController portao;
    public void ChecarPortao()
    {
        if (AlavancasAtivas == 2)
        {
            portao.AbrirSaida();
        }
    }

}
