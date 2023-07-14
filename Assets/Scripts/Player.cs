using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the movement speed as needed

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Check if the player is at the top or bottom boundary and restrict movement accordingly
        if (transform.position.y >= GameManager.topRight.y && moveVertical > 0)
        {
            moveVertical = 0;
        }
        if (transform.position.y <= GameManager.bottomLeft.y && moveVertical < 0)
        {
            moveVertical = 0;
        }

        // Check if the player is at the left or right boundary and restrict movement accordingly
        if (transform.position.x >= GameManager.topRight.x && moveHorizontal > 0)
        {
            moveHorizontal = 0;
        }
        if (transform.position.x <= GameManager.bottomLeft.x && moveHorizontal < 0)
        {
            moveHorizontal = 0;
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * moveSpeed;

        // Optionally, normalize the movement vector to prevent diagonal movement from being faster
        // movement.Normalize();
        // rb.velocity = movement * moveSpeed;

        bool flipped = movement.x <0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));
    }
}