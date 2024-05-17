using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "NPC/Dialogue")]
public class Dialogue : ScriptableObject
{
    [TextArea(1,5)]
    public string[] line;
}