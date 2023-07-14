using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float scrollSpeed = 6f; // Adjust the scrolling speed as needed

    private float backgroundHeight;
    private Vector3 startPosition;

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        backgroundHeight = spriteRenderer.bounds.size.y;
        startPosition = transform.position;
    }

    private void Update()
    {
        float newYPosition = Mathf.Repeat(Time.time * scrollSpeed, backgroundHeight);
        transform.position = startPosition + Vector3.down * newYPosition;
    }
}