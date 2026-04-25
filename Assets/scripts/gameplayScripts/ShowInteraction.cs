using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ShowInteraction : MonoBehaviour
{
    
    public static ShowInteraction instance;
    public Texture2D cursor;

    [SerializeField] private string Owner = null;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
      //  interaction.gameObject.SetActive(false);
    }
    [SerializeField] TMP_Text interaction;
    // Update is called once per frame
    public void interact(string owner, bool b)
    {
        if (b)
        {
            Owner = owner;
            Cursor.visible = true;
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        }
        else if (Owner == owner)
        {
            Cursor.visible = false; 
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
