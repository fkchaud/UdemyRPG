using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rigidbody = default;
    private Animator animator = default;

    private static PlayerController instance;

    [SerializeField]
    private float moveSpeed = 1f;

    void Start()
    {
        if (instance == null) InitializeStaticInstance();
        else Destroy(gameObject);
    }

    private void InitializeStaticInstance()
    {
        instance = this;

        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        rigidbody.velocity = new Vector2(horizontalAxis, verticalAxis) * moveSpeed;

        animator.SetFloat("moveX", horizontalAxis);
        animator.SetFloat("moveY", verticalAxis);

        if (horizontalAxis == 1 || horizontalAxis == -1 || verticalAxis == 1 || verticalAxis == -1)
        {
            animator.SetFloat("lastMoveX", horizontalAxis);
            animator.SetFloat("lastMoveY", verticalAxis);
        }
    }
}
