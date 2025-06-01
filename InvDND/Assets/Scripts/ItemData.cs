using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemData : MonoBehaviour
{
    public int ItemID;
    public int ItemCount = 1;
    public Transform originalParent;
    public TMP_Text count_text;
    
    public void UpdateCount(int count)
    {
        count_text = transform.Find("CountText").GetComponent<TMP_Text>();
        ItemCount = count;
        if (count_text != null)
        {
            count_text.text = count.ToString();
        }
    }
}
