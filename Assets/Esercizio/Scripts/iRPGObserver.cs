using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iRPGObserver
{
    void OnPlayerActualExperienceChange(int actualExperience);
    void OnPlayerChangeQuest(Quest activeQuest);
    void OnPlayerCompleteQuest(Quest activeQuest);
    void OnPlayerLevelChange(int playerLevel);
    void OnPlayerNextLevelExperienceChange(int nextLevelExperience);
}