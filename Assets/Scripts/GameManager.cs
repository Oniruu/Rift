using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint (new Vector2 (0,0));
        topRight = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, Screen.height));
    }
}
