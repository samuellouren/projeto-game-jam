using System.Collections.Generic;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    public string _tagTargetDetection = "human";
    public List<Collider2D> detectedObjs = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_tagTargetDetection))
        {
            detectedObjs.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_tagTargetDetection))
        {
            detectedObjs.Remove(collision);
        }
    }
}