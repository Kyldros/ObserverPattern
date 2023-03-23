using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RPGPlayer : MonoBehaviour, iRPGObservable
{
    private int _actualExperience;
    private int _nextLevelExperience;
    private int _playerLevel;
    [SerializeField] private int increaseExperienceValue = 500;
    private List<iRPGObserver> observers = new List<iRPGObserver>();

    [SerializeField] private List<Quest> quests = new List<Quest>();
    private Quest _activeQuest;
    private int questNumber = 0;

    private int ActualExperience
    {
        get { return _actualExperience; }
        set
        {
            _actualExperience = value;

            foreach (iRPGObserver observer in observers)
            {
                observer.OnPlayerActualExperienceChange(_actualExperience);
            }
        }

    }
    private int Level
    {
        get { return _playerLevel; }
        set
        {
            _playerLevel = value;

            foreach (iRPGObserver observer in observers)
            {
                observer.OnPlayerLevelChange(_playerLevel);
            }
        }

    }
    private int NextLevelExperience
    {
        get { return _nextLevelExperience; }
        set
        {
            _nextLevelExperience = value;

            foreach (iRPGObserver observer in observers)
            {
                observer.OnPlayerNextLevelExperienceChange(_nextLevelExperience);
            }
        }

    }

    public Quest ActiveQuest
    {
        get => _activeQuest;
        private set
        {
            _activeQuest = value;
            foreach (iRPGObserver observer in observers)
            {
                observer.OnPlayerChangeQuest(_activeQuest);
            }
        }
    }

    void Start()
    {
        Level = 0;
        ActualExperience = 0;
        NextLevelExperience = 1000;

        GenerateInitialQuests();
        ActiveQuest = quests[0];
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            IncreaseExperience(increaseExperienceValue);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CompleteQuest();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PreviousQuest();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            NextQuest();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            RandomQuest();
        }

        if (_actualExperience >= _nextLevelExperience)
        {
            IncreaseLevel();
        }
    }

    private void IncreaseExperience(int  value)
    {
        ActualExperience += value;
    }

    private void CompleteQuest()
    {
        if (!ActiveQuest.complete)
        {
            CompleteQuestListReplacement();
            foreach (iRPGObserver observer in observers)
            {
                observer.OnPlayerCompleteQuest(_activeQuest);
            }
            NextQuest();
        }
    }

    private void CompleteQuestListReplacement()
    {
        quests[ActiveQuest.number - 1] = new Quest(ActiveQuest.questName, ActiveQuest.questDescription, true, ActiveQuest.number);
    }

    private void PreviousQuest()
    {
        if (ActiveQuest.number - 2 < 0)
            ActiveQuest = quests[quests.Count - 1];
        else
            ActiveQuest = quests[ActiveQuest.number - 2];
    }

    private void NextQuest()
    {
        if (ActiveQuest.number > quests.Count - 1)
            ActiveQuest = quests[0];
        else
            ActiveQuest = quests[ActiveQuest.number];
    }

    private void IncreaseLevel()
    {
       Level++;
       NextLevelExperience += _playerLevel * 1000;
    }
    public void AddObserver(iRPGObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(iRPGObserver observer)
    {
        observers.Remove(observer);
    }

    public void AggiungiQuest(string description)
    {
        questNumber++;
        quests.Add(new Quest("Quest " + questNumber, description, false, questNumber));
    }

    public void RandomQuest()
    {
        AggiungiQuest(UnityEngine.Random.Range(100000, 999999).ToString());
    }

    private void GenerateInitialQuests()
    {
        AggiungiQuest("Premi il tasto P per guadagnare esperienza e il tasto C per completare questa Quest");
        AggiungiQuest("Premendo il tasto C si completa qualsiasi Quest attiva in questo momento");
        AggiungiQuest("Con i tasti Q ed E è possibile scorrere l'elenco delle quest");
        AggiungiQuest("Con il tasto G è possibile aggiure una nuova quest  all'elenco con un numero random come descrizione");
    }


}
