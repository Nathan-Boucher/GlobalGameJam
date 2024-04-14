using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    public Texture2D cursorArrow;
    public Texture2D overCursor;
    void Start()
    {
        // Cursor.visible = false;
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode. ForceSoftware;)
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(overCursor, Vector2.zero, CursorMode. ForceSoftware;)
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode. ForceSoftware;)
    }
}