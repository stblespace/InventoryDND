using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotHighlighter : MonoBehaviour
{
    private Image slotImage;
    private Color defaultColor;
    void Awake()
    {
        slotImage = GetComponent<Image>();
        defaultColor = slotImage.color;
    }

    public void ResetColor()
    {
        slotImage.color = defaultColor;
    }
}
