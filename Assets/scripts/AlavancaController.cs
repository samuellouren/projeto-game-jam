using UnityEngine;

public class AlavancaController : MonoBehaviour
{
    public Sprite AlavancaInativa;
    public Sprite AlavancaAtiva;
    public SpriteRenderer Alavanca;
    public bool isActive = false;
    public AlavancaManeger Manager;
   
    

    public void Activate()
    {
        if (isActive == false)
        {
            isActive = true;
            Alavanca.sprite = AlavancaAtiva;
            Manager.AlavancasAtivas = Manager.AlavancasAtivas + 1;
            Manager.ChecarPortao();
        }
       
    } 

}
