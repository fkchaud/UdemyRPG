using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rigidbody = default;

    [SerializeField]
    private float moveSpeed = 1f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ) * moveSpeed;
    }
}
