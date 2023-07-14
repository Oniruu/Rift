using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployAsteroids : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    private float screenTopY;

    // Use this for initialization
    void Start()
    {
        Vector3 screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.transform.position.z));
        screenTopY = screenTop.y;

        StartCoroutine(asteroidWave());
    }

    private void spawnEnemy()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float randomX = Random.Range(-screenBounds.x, screenBounds.x);
        GameObject a = Instantiate(asteroidPrefab, new Vector2(randomX, screenTopY), Quaternion.identity);
        Rigidbody2D rb = a.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -1); // Adjust the downward velocity as needed
    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}