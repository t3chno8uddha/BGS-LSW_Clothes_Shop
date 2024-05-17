using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "NPC/Dialogue")]
public class Dialogue : StoryEvent
{
    [TextArea(1,5)]
    public string[] dialogue;
}