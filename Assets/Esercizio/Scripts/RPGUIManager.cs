using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RPGUIManager : MonoBehaviour, iRPGObserver
{
    [SerializeField] private RPGPlayer player;
    [SerializeField] private TextMeshProUGUI levelNumber;
    [SerializeField] private TextMeshProUGUI actualExperience;
    [SerializeField] private TextMeshProUGUI nextLevelExpercience;
    [SerializeField] private TextMeshProUGUI questName;
    [SerializeField] private TextMeshProUGUI questDescription;
    [SerializeField] private GameObject questComplete;
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color highlightColor = Color.red;
    [SerializeField] private Color completedQuestColor = Color.green;

    private bool highlightOn = false;
    private float elapsed = 0f;
    [SerializeField] private float highlightDuration = 2f;
    private bool questCompleteOn = false;
    private float questElapsed = 0f;
    [SerializeField] private float questCompleteDuration = 3f;


    public static RPGUIManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        player.AddObserver(this);
        OnPlayerChangeQuest(player.ActiveQuest);
    }


    public void OnPlayerActualExperienceChange(int actualExperience)
    {
        this.actualExperience.text = actualExperience.ToString();
    }

    public void OnPlayerLevelChange(int playerLevel)
    {
        levelNumber.text = playerLevel.ToString();
        EnableHighlight();
    }
    public void OnPlayerNextLevelExperienceChange(int nextLevelExperience)
    {
        this.nextLevelExpercience.text = nextLevelExperience.ToString();
    }

    private void EnableHighlight()
    {
        highlightOn = true;
        elapsed = 0f;
        levelNumber.color = highlightColor;
        actualExperience.color = highlightColor;
        nextLevelExpercience.color = highlightColor;
    }

    private void levelUpHighlight()
    {
        if(elapsed > highlightDuration)
        {
            highlightOn = false;
            levelNumber.color= normalColor;
            actualExperience.color = normalColor;
            nextLevelExpercience.color = normalColor;
        }
        else
        {
            elapsed += Time.deltaTime;
        }
    }

    private void Update()
    {
        if(highlightOn)  
            levelUpHighlight();

        if (questCompleteOn)
            QuestCompleteTextOn();

    }

    private void QuestCompleteTextOn()
    {
        if (questElapsed > questCompleteDuration)
        {
            questCompleteOn = false;
            questComplete.SetActive(false);
        }
        else
        {
            questElapsed += Time.deltaTime;
        }
    }

    public void OnPlayerChangeQuest(Quest activeQuest)
    {
        questName.text = activeQuest.questName;
        questDescription.text = activeQuest.questDescription;
        if (activeQuest.complete)
        {
            questName.color = completedQuestColor;
            questDescription.color = completedQuestColor;
        }
        else
        {
            questName.color = normalColor;
            questDescription.color = normalColor;
        }
    }

    public void OnPlayerCompleteQuest(Quest activeQuest)
    {
        EnableQuestComplete();
    }

    private void EnableQuestComplete()
    {
        questCompleteOn = true;
        questElapsed= 0;
        questComplete.SetActive(true);
    }
}
