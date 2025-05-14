using System;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public MeshRenderer target;

    [TextArea(3, 10)]
    public string message;

    public static Action<string, bool> OnNoteDiscovered;

    private bool isActive;
    private bool onArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    private void Update()
    {
        if(onArea)
        {
            if(!isActive)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isActive = true;
                    Time.timeScale = 0;
                    NoteController.OnNoteDiscovered.Invoke(message, true);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    isActive = false;
                    Time.timeScale = 1;
                    NoteController.OnNoteDiscovered.Invoke(message, false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        onArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        onArea = false;
    }
}
