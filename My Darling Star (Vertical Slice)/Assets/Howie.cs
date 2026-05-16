using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

/*
public class Howie : FullDialouge
{    
    

    void Start()
    {
        Debug.Log("hi");
    }

    public override void AdvanceDialogue ()
    {
        _runningDialogue = true;
        _playerMovement.enabled = false;
        _talking = true;

        if(_currentLine < _currentNode._lines.Length)
        {
            _dialogue.ShowDialogue(_currentNode._lines[_currentLine]);
            _currentLine++;
        }
        else if(_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
        {
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
            else if (_gotCorrect == true)
            {
                _currentNode = _dialougeDifferntNodeStates[4];
            }
            else if (_gotCorrectAndMultiple == true)
            {
                _currentNode = _dialougeDifferntNodeStates[5];
            }
            else if (_gotSecret == true)
            {
                _currentNode = _dialougeDifferntNodeStates[6];

            }  
            else if(_gotMultiple)
            {
                _currentNode = _dialougeDifferntNodeStates[7];
            }
            
            
            
            else
            {
                _currentNode = _dialougeDifferntNodeStates[1];

            }

        }
    }

    public override void GotCube()
    {
        _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[2];
        _gotCube = true;
        
        
    }
    public override void GotTriangle()
    {
       _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[3];
        _gotTriangle = true; 
    }
    
    public override void GotSecret()
    {
        _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[6];
        _gotSecret = true;
    }
    public override void GotCorrect()
    {
        _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[4];
        _gotCorrect = true;
    }
    public override void GotMultiple()
    {
        _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[7];
        _gotMultiple = true;
    }
    public override void GotMultipleAndCorrect()
    {
        _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[5];
        _gotCorrectAndMultiple = true;
    }
    

    public override void GogetIt()
    {
        _waitingForPlayerResponse = false;
        _currentNode = _dialougeDifferntNodeStates[1];
    }
}
*/