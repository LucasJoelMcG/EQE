using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] [TextArea] private string[] characterName;
    [SerializeField] private Sprite[] characterImage;
    public string[] Dialogue => dialogue;
    public string[] Name => characterName;
    public Sprite[] Image => characterImage;
}
