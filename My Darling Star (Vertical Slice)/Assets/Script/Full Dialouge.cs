using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Assertions;
using Unity.VisualScripting;

public class FullDialouge : MonoBehaviour
{

    [SerializeField] private float _interactionDistance = 2.0f;
    [SerializeField] private DialougeUI _dialogue;
    //[SerializeField] private DialogueNode _dialogueStartNode;
    [SerializeField] private List<DialogueNode> _dialougeDifferntNodeStates;
    [SerializeField] private ScriptMachine _playerMovement;
    private DialogueNode _currentNode;
    private int _currentLine = 0;
    private bool _runningDialogue;
    private bool _waitingForPlayerResponse;
    private bool _spokeToAlready = false;


    private void Start ()
    {
        _currentNode = _dialougeDifferntNodeStates[0];
        
    }

    private void Update ()
    {
        if(PlayerSingleton.Instance == null) return;

        if(Vector3.Distance(transform.position, PlayerSingleton.Instance.transform.position) < _interactionDistance)
        {
            if(!_waitingForPlayerResponse && Input.GetMouseButtonDown(0))
            {
                AdvanceDialogue();
                
            }
        
        }
        else
        {
            EndDialogue();

        }
        
    }

    private void AdvanceDialogue ()
    {
        _runningDialogue = true;
        _playerMovement.enabled = false;

        if(_currentLine < _currentNode._lines.Length)
        {
            // if we still have NPC lines left, keep playing NPC lines 
            _dialogue.ShowDialogue(_currentNode._lines[_currentLine]);
            _currentLine++;
        }
        else if(_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
        {
            // show player dialogue options, if there are any
            _waitingForPlayerResponse = true;
            _dialogue.ShowPlayerOptions(_currentNode._playerReplyOptions);
        }
        else 
        {
            EndDialogue();
            _currentNode = _dialougeDifferntNodeStates[1];

        }
    }

    public void EndDialogue ()
    {
        _runningDialogue = false;
        _waitingForPlayerResponse = false;
        //_currentNode = _dialougeDifferntNodeStates[0];
        _currentLine = 0;
        _dialogue.HideDialogue();

       _playerMovement.enabled = true;

       

    }

    public void SelectedOption(int option)
    {
        _currentLine = 0;
        _waitingForPlayerResponse = false;

        _currentNode = _currentNode._npcReplies[option];
        AdvanceDialogue();
    }
    public void AniGift()
    {
        _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[2];
        
        
    }
    public void GogetIt()
    {
        _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[1];
    }
    
}
