using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
 
public class TalkToNPC : MonoBehaviour
{
    [Header("NPC Script")]
    [SerializeField] private List<TextAsset> _npcInkJSON;

    private void Start()
    {
    }

    void Update()
    {
        if (!DialougeSystem.GetInstance().dialougeIsPlaying) // check if variable from dialogue system is false
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) // check if screen is touched
            {
                Debug.Log("hit");
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position); // set touch position
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) // if collided with collider component 
                {
                    if (hit.transform.tag == "NPC") // if touch hit a tag with the NPC tag
                    {
                        string npcName = hit.transform.name; // declare and initialize
                        PlayScript(npcName);
                    }
                }
            }
        }
    }


    public void PlayScript(string characterName)
    {
        foreach (TextAsset textAsset in _npcInkJSON) // loops through each json file
                                                     // better if used hashset/dictionary
        {
            if (textAsset.name == characterName) // checks if json name and character name is equal
                                                 // make sure that the npc and its json script has the same name
            {
                StartCoroutine(DialougeSystem.GetInstance().EnterDialougeMode(textAsset, characterName)); // enter dialogue with the passed json file
                break;
            } 
        }
    }
}