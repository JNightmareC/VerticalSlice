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
    private bool _gotCube = false;
    private bool _gotTriangle = false;
    private bool _gotRight = false;
    public bool _talking = false;
     



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
        _talking = true;

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
            _talking = false;
            EndDialogue();

            if(_gotCube == true)
            {
                _currentNode = _dialougeDifferntNodeStates[2];
            }
            else if(_gotTriangle == true)
            {
                _currentNode = _dialougeDifferntNodeStates[3];

            }
            /*else if(_gotTriangle && _gotCube)
            {
                
            }
            
            else if (_gotRight)
            {
                
            }
            */
            else
            {
                _currentNode = _dialougeDifferntNodeStates[1];

            }

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
    public void GotCube()
    {
        _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[2];
        _gotCube = true;
        
        
    }
    public void GotTriangle()
    {
       _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[3];
        _gotTriangle = true; 
    }
    public void GotCorrect()
    {
        _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[2];
        _gotRight = true;
    }
    public void GogetIt()
    {
        _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[1];
    }

    
}
