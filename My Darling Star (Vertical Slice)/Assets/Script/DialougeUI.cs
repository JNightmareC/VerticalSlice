using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialougeUI : MonoBehaviour
{
   [SerializeField] private TMP_Text _npcText;
    [SerializeField] private GameObject _npcDialogue;
    [SerializeField] private GameObject _playerDialougeChoicesHowie;
    [SerializeField] private GameObject _playerDialougeChoicesCreature;
    [SerializeField] private GameObject _playerDialougeChoicesSunny;

    [SerializeField] private TMP_Text _option1;
    [SerializeField] private TMP_Text _option2;
    [SerializeField] private TMP_Text _option3;

    public void ShowDialogue(string NPCTalk)
    {
        gameObject.SetActive(true);

        _npcDialogue.SetActive(true);
        
        _playerDialougeChoicesHowie.SetActive(false);
        _playerDialougeChoicesCreature.SetActive(false);
        _playerDialougeChoicesSunny.SetActive(false);

        _npcText.text = NPCTalk;
    }

    public void ShowPlayerOptions()
    {
        gameObject.SetActive(true);
        _npcDialogue.SetActive(false);

        _playerDialougeChoicesHowie.SetActive(false);
        _playerDialougeChoicesCreature.SetActive(false);
        _playerDialougeChoicesSunny.SetActive(false);
    }

    public void ShowPlayerOptions(string[] options)
    {
        gameObject.SetActive(true);
        _npcDialogue.SetActive(false);
        
        if (gameObject.name == "Howie")
        {
            _playerDialougeChoicesHowie.SetActive(true);
        }
        else if (gameObject.name == "Creature")
        {
            _playerDialougeChoicesCreature.SetActive(true);
        }
        else if (gameObject.name == "Sunny")
        {
            _playerDialougeChoicesSunny.SetActive(true);
        }

        _option1.text = options[0];

        if(options.Length >= 2)
        {
            _option2.transform.parent.gameObject.SetActive(true);
            _option2.text = options[1];
        }
        else 
        {
            _option2.transform.parent.gameObject.SetActive(false);
        }

        if(options.Length >= 3)
        {
            _option3.transform.parent.gameObject.SetActive(true);
            _option3.text = options[2];
        }
        else 
        {
            _option3.transform.parent.gameObject.SetActive(false);
        }
    }

    public void HideDialogue()
    {
        _npcDialogue.SetActive(false);
        gameObject.SetActive(false);
    }
}
