using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueLine", menuName = "ScriptableObjects/DialogueLine", order = 1)]
public class DialogueNode : ScriptableObject
{
    public string _NPCName;
    public string[] _lines;
    //public Sprite characterPortrate;
    public string[] _playerReplyOptions;
    public DialogueNode[] _npcReplies;
    //public DialogueNode[] _differentObjectHeldNodes;
}