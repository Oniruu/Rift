using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody2D rb;
    private float screenBottomY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);

        // Calculate the bottom position of the screen in world coordinates
        Vector3 screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
        screenBottomY = screenBottom.y;
    }

    private void Update()
    {
        // Check if the obstacle is below the screen
        if (transform.position.y < screenBottomY)
        {
            Destroy(gameObject);
        }
    }
}