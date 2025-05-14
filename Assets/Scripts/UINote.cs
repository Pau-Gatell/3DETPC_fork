using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UINote : MonoBehaviour
{
    public RawImage image;
    public TextMeshProUGUI text;
    public RawImage background;

    private void OnEnable()
    {
        NoteController.OnNoteDiscovered += HandleNote;
    }

    private void OnDisable()
    {
        NoteController.OnNoteDiscovered -= HandleNote;
    }

    private void HandleNote(string message, bool active)
    {
        text.gameObject.SetActive(active);
        image.gameObject.SetActive(active);
        background.gameObject.SetActive(active);

        text.text = message;
    }
}
