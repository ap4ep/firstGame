using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorConfig : MonoBehaviour
{
    [SerializeField] private Texture2D _cursor;

    private void Awake()
    {
        Vector2 texturePosition = new Vector2(_cursor.width * 0.5f, _cursor.height * 0.5f);
        Cursor.SetCursor(_cursor, texturePosition, CursorMode.Auto);
    }
}
