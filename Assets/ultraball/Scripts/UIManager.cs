using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //this here updates UI values 

    GameManager gamemanager;

    [SerializeField]
    TextMeshProUGUI timertext;
    [SerializeField]
    TextMeshProUGUI pickuptext;
    [SerializeField]
    GameObject gameoverscreen;

    private void OnEnable()
    {
        



        GameManager.GameTimerEvent += UpdateGameTimerUI;
        GameManager.GameConditionEvent += UpdateGameConditionUI;
        GameManager.UpdatePickupCountEvent += UpdatePickupObjectiveUI;
        GameManager.GameOverEvent += OnGameover;
    }

    private void OnDisable()
    {
        GameManager.GameTimerEvent -= UpdateGameTimerUI;
        GameManager.GameConditionEvent -= UpdateGameConditionUI;
        GameManager.UpdatePickupCountEvent -= UpdatePickupObjectiveUI;
        GameManager.GameOverEvent -= OnGameover;
    }

 
    void OnGameover(bool isWon) 
    {
        if (isWon) 
        {
            gameoverscreen.SetActive(true);
        }
        else 
        {
            gameoverscreen.SetActive(false);
        }
    }

    void UpdateGameTimerUI(float time) 
    {
        timertext.text = time.ToString();
    }

    void UpdatePickupObjectiveUI(float collectedobjectcount, float objectcount) 
    {
        pickuptext.text = ($"gems: {collectedobjectcount.ToString()}/ {objectcount.ToString()}");
    }

    void UpdateGameConditionUI() 
    {
    
    }
}
