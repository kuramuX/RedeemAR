using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialougeSystem : MonoBehaviour
{
    [SerializeField] private TextAsset loadGlobalsJSON; // assign load_globals json file
    [SerializeField] private float typingSpeed = 0.04f;
    private Animator animatorChar; // handles npc animations
    private DialougeVariables dialougeVariables;
    private string currentNPC;
    private static DialougeSystem instance;
    private Story currentStory; //loads npc json file
    private Coroutine displayLineCoroutine;
    private bool canContinueToNextLine;
    private bool submitButtonPressedThisFrame;
    private CreationEvents _creationEvent;
    public bool dialougeIsPlaying { get; set; }

    //Inkle Tags
    private const string _speakerTag = "speaker"; // ink tag that stores the speaker name
    private const string _audioTag = "audio"; // ink tag that stores the file name of an audio file
    private string audioClipName;    

    [Header("NPCs in the current list")]
    [SerializeField] private List<GameObject> _characterList;

    [Header("Dialouge UI")]
    [SerializeField] private GameObject parentPlaceHolder;
    [SerializeField] private Image _characterPlaceHolder;
    [SerializeField] private Sprite boySprite;
    [SerializeField] private Sprite girlSprite;
    [SerializeField] private Sprite robotSprite;
    [SerializeField] private GameObject _dialougePanel;
    [SerializeField] private TextMeshProUGUI _dialougeText;
    [SerializeField] private GameObject _continueIcon;
    [SerializeField] private TMP_Text _displayNameText;
    [SerializeField] private GameObject _displayNamePanel;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [HideInInspector]
    public int pauseDialogue { get; set; }
    

    void Start()
    {
        pauseDialogue = 1;
        instance = this;
        // initialize variables
        canContinueToNextLine = false;
        submitButtonPressedThisFrame = false;
        dialougeIsPlaying = false;
        _creationEvent = FindObjectOfType<CreationEvents>();
        //disable dialogue panel
        _dialougePanel.SetActive(false);

        // enable choice ui 
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0; 
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Awake()
    {
        dialougeVariables = new DialougeVariables(loadGlobalsJSON); // load globals json file
                                                                    // check if more instances of this class is enabled
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialouge System");
        }
    }

    public static DialougeSystem GetInstance ()
    {
        return instance; // return the current instance of this class
    }

    private bool IfAudioManagerIsAvailable()
    {
        return GameObject.Find("AudioManager") != null;
    }

    public IEnumerator EnterDialougeMode(TextAsset inkJSON, string speakerName)
    {
        _displayNameText.text = speakerName;
        yield return new WaitForSeconds(0.1f);
        audioClipName = null; // reset variable
        currentStory = new Story(inkJSON.text); // set the story to passed npc json file
        dialougeIsPlaying = true;
        submitButtonPressedThisFrame = false;
        _dialougePanel.SetActive(true); // enable dialogue panel 
        dialougeVariables.StartListening(currentStory); // call npc json file
        ContinueStory();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue) // check if json story script has next line
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            HandleTags(currentStory.currentTags); // calls this method to check ink tags
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
        }
        else
        {
            _creationEvent.AddDay();
            StartCoroutine(_creationEvent.StartDay());
            StartCoroutine(ExitDialougeMode());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseDialogue != 0)
        {
            if (dialougeIsPlaying)
            {
                HandleTags(currentStory.currentTags);
                /*
                foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("NPC"))
                {
                    Renderer renderer = gameObject.GetComponent<Renderer>();
                    if (!renderer.isVisible && renderer.name == currentNPC)
                    {
                        StartCoroutine(ExitDialougeMode());
                    }
                }
                */
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
                {
                    submitButtonPressedThisFrame = true;
                }
                if (!dialougeIsPlaying)
                {
                    return;
                }

                if (canContinueToNextLine && currentStory.currentChoices.Count == 0 && submitButtonPressedThisFrame)
                {
                    if (IfAudioManagerIsAvailable()) FindObjectOfType<AudioManager>().Stop();
                    DisableTalkingAnimation();
                    submitButtonPressedThisFrame = false;
                    ContinueStory();
                }
            }
            else
            {
                DisableTalkingAnimation();
            }
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        _dialougeText.text = line;
        _dialougeText.maxVisibleCharacters = 0;
        _continueIcon.SetActive(false);
        canContinueToNextLine = false;
        HideChoices();
        _creationEvent.TriggerEvent();
        pauseDialogue = ((IntValue)DialougeSystem.GetInstance().GetVariableState("pauseDialogue")).value;
        yield return new WaitForSeconds(0.1f);

        // check if audio tag is available in the paragraph (ink script)
        if (audioClipName != null)
        {
            if (IfAudioManagerIsAvailable()) FindObjectOfType<AudioManager>().Play(audioClipName);
        }

        
        // ENABLE SPEAKER TALKING ANIMATION
        for (int i = 0; i < _characterList.Count; i++) // loop through npc list
        {
            if (currentNPC == _characterList[i].name) // check if element equals to current speaker
                                                      // if possible recommend to use dictionary/hash set
            {
                if (_characterList[i].GetComponent<Animator>() != null) // check if speaker has animator component
                {
                    // if yes then play talking animation
                    animatorChar = _characterList[i].GetComponent<Animator>();
                    animatorChar.SetBool("Trigger", true); // all NPC should use a bool variable named
                                                           // Trigger to enable talking animation
                    break;
                }
            }
        }

        // DISPLAY THE CURRENT PARAGRAPH LETTER BY LETTER
        foreach (char letter in line.ToCharArray())
        {
            // if user pressed early, instantly show all text
            if (submitButtonPressedThisFrame)
            {
                submitButtonPressedThisFrame = false;
                _dialougeText.maxVisibleCharacters = line.Length;
                Debug.Log("test");
                break;
            }

            _dialougeText.maxVisibleCharacters++; // return a letter from a word/paragraph
            yield return new WaitForSeconds(typingSpeed); // value to wait before iterating the next loop
        }

        canContinueToNextLine = true;
        DisplayChoices(); // show choices if available
        _continueIcon.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }


    // DISABLE/REVERT ALL NPCs animation in the current scene
    public void DisableTalkingAnimation()
    {
        for (int i = 0; i < _characterList.Count; i++)
        {
            if (_characterList[i].GetComponent<Animator>() != null)
            {
                animatorChar = _characterList[i].GetComponent<Animator>();
                animatorChar.SetBool("Trigger", false);
            }
        }
    }

    public IEnumerator ExitDialougeMode()
    {
        currentNPC = null;
        yield return new WaitForSeconds(0.2f);
        if (IfAudioManagerIsAvailable()) FindObjectOfType<AudioManager>().Stop();
        audioClipName = null;
        DisableTalkingAnimation();
        dialougeVariables.StartListening(currentStory);
        dialougeIsPlaying = false;
        _dialougePanel.SetActive(false);
        _dialougeText.text = "";
    }


    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // if choices in ink json is greater than ui choices
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More Choices" + currentChoices.Count);
        }
        int index = 0;

        // if available, display choices ui
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    // HANDLE INK TAGS AND SET VARIABLES
    private void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropirately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey) 
            {
                case _speakerTag:
                    if (tagValue != "Character")
                    {
                        _displayNamePanel.SetActive(true);
                        parentPlaceHolder.SetActive(false);
                        currentNPC = tagValue; // set current speaker name
                        _displayNameText.text = currentNPC; // set current speaker name in text ui
                    }
                    else
                    {
                        _displayNamePanel.SetActive(false);
                        parentPlaceHolder.SetActive(true);
                        string sprite = PlayerPrefs.GetString("Character");

                        switch (sprite)
                        {
                            case "boy":
                                _characterPlaceHolder.sprite = boySprite;
                                break;
                            case "girl":
                                _characterPlaceHolder.sprite = girlSprite;
                                break;
                            case "robot":
                                _characterPlaceHolder.sprite = robotSprite;
                                break;
                            default:
                                Debug.LogWarning(sprite);
                                break;
                        }

                    }
                    break;
                case _audioTag:
                    audioClipName = tagValue; // set audio file name
                    break;
                default:
                    Debug.LogWarning("no tag");
                    break;
            }
        }
    }


    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            if (IfAudioManagerIsAvailable())  FindObjectOfType<AudioManager>().Stop();
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
    }

    // GET VARIABLE VALUE IN GLOBALS JSON
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialougeVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }

    // SET VARIABLE VALUE IN GLOBALS JSON
    public void SetVariableState(string variableName, Ink.Runtime.Object variableValue)
    {
        if (dialougeVariables.variables.ContainsKey(variableName))
        {
            dialougeVariables.variables.Remove(variableName);
            dialougeVariables.variables.Add(variableName, variableValue);
        }
        else
        {
            Debug.LogWarning("Tried to update variable that wasn't initialized by globals.ink: " + variableName);
        }
    }
}
