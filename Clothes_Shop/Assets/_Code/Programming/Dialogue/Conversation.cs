using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class DialogueEvent
{
    public Dialogue dialogue;
    public UnityEvent endingEvent;
}

public class Conversation : MonoBehaviour
{
    // Flags to control dialogue and event progress
    bool lineOver = true;
    int lineIndex = -1;
    int dialogueIndex = 0;

    // Text display component
    public GameObject textBox;
    public TextMeshProUGUI textBoxText;
    public float conversationSpeed = 1.0f;

    public DialogueEvent[] currentDialogue;

    PlayerCharacter pCharacter;
    void Start()
    {
        pCharacter = FindObjectOfType<PlayerCharacter>();
    }
    
    // Proceed to the next line or event
    public void Proceed()
    {
        if (!pCharacter.pNav.isConversing)
        {
            pCharacter.pNav.isConversing = true;
            textBox.SetActive(true);
        }

        StopAllCoroutines();

        if (lineOver)
        {
            lineIndex++;
            if (lineIndex == currentDialogue[dialogueIndex].dialogue.line.Length)
            {
                currentDialogue[dialogueIndex].endingEvent.Invoke();
                lineIndex = -1;
            }
            else
            {
                NextLine();
            }
        }
        else
        {
            FastForwardLine(currentDialogue[dialogueIndex].dialogue.line[lineIndex]);
            lineOver = true;
        }
    }

    // Proceed to the next line
    void NextLine()
    {
        lineOver = false;
        StartCoroutine(WriteText(currentDialogue[dialogueIndex].dialogue.line[lineIndex]));
    }

    // Coroutine to gradually write text
    IEnumerator WriteText(string text)
    {
        textBoxText.text = ""; 
        string displayedText = ""; 

        for (int i = 0; i < text.Length; i++)
        {
            char currentChar = text[i];
            displayedText += currentChar;

            float delay = 0.2f / conversationSpeed;
            textBoxText.text = displayedText;

            yield return new WaitForSeconds(delay);
        }

        textBoxText.text = text;
        lineOver = true;
    }

    // Fast forward the current line of text
    void FastForwardLine(string text)
    {
        textBoxText.text = text;
    }

    public void EndConversation(int nextDialogue)
    {
        pCharacter.pNav.isConversing = false;
        textBox.SetActive(false);
        textBoxText.text = "";
        dialogueIndex = nextDialogue;
    }
}