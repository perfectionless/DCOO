using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshProController : MonoBehaviour
{
    public void UpdateText(string newText)
    {
        // Update the text in the TextMeshPro component
        GetComponent<TextMeshProUGUI>().text = newText;
    }
}
