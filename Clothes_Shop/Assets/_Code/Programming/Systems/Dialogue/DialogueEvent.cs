using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(1,5)]
    public string[] line; // The lines that a dialogue will be speaking.
    public int nextDialogue; // The index of the next dialogue.
}

[CreateAssetMenu(fileName = "New Dialogue", menuName = "NPC/Dialogue")]
public class DialogueEvent : ScriptableObject
{
    public Dialogue[] dialogue; // A holder for all dialogues.
}