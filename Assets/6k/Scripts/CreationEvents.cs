using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreationEvents : MonoBehaviour
{
    public TextAsset Aralin1Script;
    private DayAndNightControl dayNightControl;
    private ChangeSunColor changeSunColor;
    public GameObject Moon;
    public GameObject Stars;
    public GameObject Clouds;
    public GameObject Terrain;
    public GameObject GrassTrees;
    public Light directionalLight;
    public GameObject FishBirds;
    public GameObject LandAnimals;
    public GameObject Humans;
    public GameObject Light;
    private Animator animation;
    private bool playScript;
    private void Start()
    {
        playScript = true;
        directionalLight = GetComponent<Light>();
        animation = Light.GetComponent<Animator>();
        dayNightControl = FindObjectOfType<DayAndNightControl>();
        changeSunColor = FindObjectOfType<ChangeSunColor>();
        Clouds.SetActive(false);
        Moon.SetActive(false);
        Stars.SetActive(false);
        Terrain.SetActive(false);
        GrassTrees.SetActive(false);
        FishBirds.SetActive(false);
        LandAnimals.SetActive(false);
        Humans.SetActive(false);
        StartCoroutine(StartDay());
    }

    private void EndScene()
    {
        Debug.Log("LoadScene");
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator StartDay()
    {
        if (playScript)
        {
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(DialougeSystem.GetInstance().EnterDialougeMode(Aralin1Script, "Narrator"));
        }
        else
        {
            EndScene();
        }
    }

    public void AddDay()
    {
        if (playScript)
        {
            int newDay = ((IntValue)DialougeSystem.GetInstance().GetVariableState("newDay")).value;
            dayNightControl.changeToMorning = (newDay != 0);
        }
    }
    public void TriggerEvent()
    {
        
        int eventNumber = ((IntValue)DialougeSystem.GetInstance().GetVariableState("eventNumber")).value;
        switch (eventNumber)
        {
            case 1:
                Debug.Log(eventNumber);
                dayNightControl.changeToMorning = true;
                break;
            case 3:
                Clouds.SetActive(true);
                break;
            case 4:
                Terrain.SetActive(true);
                StartCoroutine(PauseDialogueSystem());
                break;
            case 5:
                GrassTrees.SetActive(true);
                break;
            case 6:
                changeSunColor.SunColor();
                Moon.SetActive(true);
                Stars.SetActive(true);
                break;
            case 7:
                FishBirds.SetActive(true);
                break;
            case 8:
                LandAnimals.SetActive(true);
                break;
            case 9:
                Humans.SetActive(true);
                break;
            case 10:
                animation.SetTrigger("Trigger");
                break;
            case 11:
                playScript = false;
                break;
            default:
                System.Console.WriteLine(eventNumber);
                break;
        }
    }

    private IEnumerator PauseDialogueSystem()
    {
        yield return new WaitForSeconds(4f);
        DialougeSystem.GetInstance().pauseDialogue = 1;
        Debug.Log("Changed Variable" + DialougeSystem.GetInstance().pauseDialogue);
    }
}
