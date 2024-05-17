using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(1,5)]
    public string[] line;
    public int nextDialogue;
}

[CreateAssetMenu(fileName = "New Dialogue", menuName = "NPC/Dialogue")]
public class DialogueEvent : ScriptableObject
{
    public Dialogue[] dialogue;
}