using System.Collections;
using UnityEngine;
using TMPro;

public class Conversation : MonoBehaviour
{
    // Flags to control dialogue and event progress:
    bool lineOver = true; // Whether or not the line finished typing.
    int lineIndex = -1; // Which line the dialogue is at.
    int dialogueIndex = 0; // Which dialogue the conversation is at.

    public GameObject textBox; // The background of the text. A parent box.
    public TextMeshProUGUI textBoxText; // The actual text.
    public float conversationSpeed = 1.0f; // The speed at which the text is typed.

    public DialogueEvent currentDialogue; // The dialogue of the conversation.

    PlayerCharacter pCharacter;

    void Start()
    {
        pCharacter = FindObjectOfType<PlayerCharacter>();
    }
    
    // Proceed to the next line or event.
    public void Proceed()
    {
        // If the player can move, it means the conversation hasn't started. Change that.
        if (!pCharacter.pNav.isConversing)
        {
            pCharacter.pNav.isConversing = true;
            textBox.SetActive(true);
        }

        StopAllCoroutines(); // Finish typing the previous text.

        if (lineOver) // If the line finished typing...
        {
            lineIndex++; // Move forward with the event.

            if (lineIndex == currentDialogue.dialogue[dialogueIndex].line.Length)
            {
                // If the event is over, move on with the next one.

                lineIndex = -1;
                EndConversation(currentDialogue.dialogue[dialogueIndex].nextDialogue);
            }
            else
            {
                // Otherwise, type the next line.

                NextLine();
            }
        }
        else // Otherwise...
        {
            // Skip over the line.
            FastForwardLine(currentDialogue.dialogue[dialogueIndex].line[lineIndex]);
            lineOver = true;
        }
    }

    public void ProceedWithDialogue(int newDialogueIndex)
    {
        dialogueIndex = newDialogueIndex;
        Proceed();
    }

    // Proceed to the next line
    void NextLine()
    {
        lineOver = false;
        StartCoroutine(WriteText(currentDialogue.dialogue[dialogueIndex].line[lineIndex]));
    }

    // Coroutine to gradually write text
    IEnumerator WriteText(string text)
    {
        textBoxText.text = ""; 
        string displayedText = ""; 

        // Type the text out over time.
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