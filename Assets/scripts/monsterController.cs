using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class SlimeController : MonoBehaviour
{
    public Animator monsterAnimator;
    public float _moveSpeedSlime = 3.5f;
    private Vector2 _slimeDirection;
    private Rigidbody2D _slimeRB2D;
    public DetectionController _detectionArea;

    void Start()
    {
        _slimeRB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_detectionArea.detectedObjs.Count > 0)
        {
            _slimeDirection = (_detectionArea.detectedObjs[0].transform.position - transform.position);
            _slimeDirection.Normalize();  // Normaliza a dire��o para garantir que o vetor tenha magnitude 1

            // Mover o Slime na dire��o detectada
            _slimeRB2D.linearVelocity = _slimeDirection * _moveSpeedSlime;
            monsterAnimator.SetBool("isWalking", true);
            monsterAnimator.SetFloat("input_x", _detectionArea.detectedObjs[0].transform.position.x -transform.position.x);
            monsterAnimator.SetFloat("input_y", _detectionArea.detectedObjs[0].transform.position.y - transform.position.y);
        }
        else
        {
            // Parar o Slime se n�o houver nenhum objeto detectado
            _slimeRB2D.linearVelocity = Vector2.zero;
            monsterAnimator.SetBool("isWalking", false);

        }

        if (_detectionArea.detectedObjs.Count > 0 && 
            Vector3.Distance(_detectionArea.detectedObjs[0].transform.position, transform.position) < 3)
        {
            SceneManager.LoadScene(0);
        }
    }
}