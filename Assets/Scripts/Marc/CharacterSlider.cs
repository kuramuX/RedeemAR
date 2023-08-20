using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlider : MonoBehaviour
{
    public GameObject scrollbar;
    public Text textDisplay; // Reference to the UI Text element
    float scroll_pos = 0;
    float[] pos;

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for(int i = 0; i < pos.Length; i++) {
            pos[i] = distance * i;
        }

        if(Input.GetMouseButton(0)) {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        } else {
            for (int i = 0; i < pos.Length; i++) {
                if(scroll_pos < pos[i] + (distance/2) && scroll_pos > pos[i] - (distance/2)) {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++) {
            if(scroll_pos < pos[i] + (distance/2) && scroll_pos > pos[i] - (distance/2)) {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int a = 0; a < pos.Length; a++) {
                    if (a != i) {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
                UpdateTextDisplay(i); // Update the text display based on the selected item
            }
        }
    }

    void UpdateTextDisplay(int itemIndex)
    {
        // You can implement your logic here to change the text based on the selected item index
        // For example:
        string itemText = "Item " + (itemIndex + 1);
        if (itemIndex == 0){
            itemText = "Lalaki";
        } else if (itemIndex == 1){
            itemText = "Babae";
        } else{
            itemText = "Robot";
        }
        
        textDisplay.text = itemText;
    }
}
