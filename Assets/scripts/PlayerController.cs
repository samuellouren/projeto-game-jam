using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public Animator playerAnimator;
    float input_x = 0;
    float input_y = 0;
    public float speed = 2.5f;
    bool isWalking = false;

    Rigidbody2D rb2D;
    Vector2 movement = Vector2.zero;

    void Start()
    {
        isWalking = false ;
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        isWalking = (input_x != 0 || input_y != 0);
        movement = new Vector2(input_x, input_y);

        if (isWalking )
        {
            playerAnimator.SetFloat("input_x", input_x);
            playerAnimator.SetFloat("input_y", input_y);
        }

        playerAnimator.SetBool("isWalking", isWalking);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckBubble())
            {
                TransformHuman();
            }
            else
            {
                TransformBubble();
            }
        }

        
    }
    private bool isBubble;
    public GameObject Human;
    public GameObject Bubble;
    private bool CheckBubble()
    {
        Debug.Log(isBubble);
        return isBubble;
    }
    private void TransformHuman()
    {
        isBubble = false;
        Human.SetActive(true);
        playerAnimator = Human.GetComponent<Animator>();
        Bubble.SetActive(false);
        foreach (var item in FindObjectsByType<DoorController>(FindObjectsSortMode.None))
        {
            item.CloseDoor();
        }
    }
    private void TransformBubble()
    {
        isBubble = true;
        playerAnimator = Bubble.GetComponent<Animator>(); 
        Bubble.SetActive(true);
        Human.SetActive(false);
        foreach (var item in FindObjectsByType<DoorController>(FindObjectsSortMode.None))
        {
            item.OpenDoor();
        }
    }
    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position +  movement * speed * Time.fixedDeltaTime);
    }
}
  