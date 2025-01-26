using UnityEngine;

public class DoorController : MonoBehaviour
{
    public void OpenDoor()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    public void CloseDoor()
    {
        GetComponent<Collider2D>().isTrigger = false; 
    }
}
