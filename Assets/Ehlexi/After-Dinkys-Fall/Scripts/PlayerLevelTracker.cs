using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerLevelTracker : MonoBehaviour 
{[Header("Experience Variables")] 
    public float swordsXP = 0f;
    public float axesXP = 0f;
    public float fistsXP = 0f;
    public float foragingXP = 0f; 
    public float fishingXP = 0f;
    public float agilityXP = 0f;
    public float vigorXP = 0f;
    public float staminaXP = 0f;
    public float processingXP = 0f;
    [Header("Level Progress")] 
    public int swordsLevel = 1;
    public int axesLevel = 1; 
    public int fistsLevel = 1; 
    public int foragingLevel = 1;
    public int fishingLevel = 1;
    public int agilityLevel = 1;
    public int vigorLevel = 1;
    public int staminaLevel = 1;
    public int processingLevel = 1;
    public int currentLevel;
    [Header("Experience Requirements per Level")]
    public float swordsXPPerLevel = 100f;
    public float axesXPPerLevel = 100f;
    public float fistsXPPerLevel = 100f;
    public float foragingXPPerLevel = 100f;
    public float fishingXPPerLevel = 100f;
    public float agilityXPPerLevel = 100f;
    public float vigorXPPerLevel = 100f;
    public float staminaXPPerLevel = 100f;
    public float processingXPPerLevel = 100f;

    public void OnLevelUp(int level, string skill)
    {
        Debug.Log("Congratulations, you reached level " + level + " in " + skill + "!");
        // Add any additional logic you want to happen when a player levels up here.
    }
    public string GetCurrentLevelName()
    {
        switch (currentLevel)
        {
            case 1:
                return "Novice";
            case 2:
                return "Apprentice";
            case 3:
                return "Journeyman";
            case 4:
                return "Expert";
            case 5:
                return "Master";
            default:
                return "Unknown";
        }
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
    private void Update() { CheckLevelProgress();
    } 
    public void AddXP(float swords, float axes, float fists, float foraging, float fishing, float agility, float vigor, float stamina, float processing) { swordsXP += swords; axesXP += axes; fistsXP += fists; foragingXP += foraging; fishingXP += fishing; agilityXP += agility; vigorXP += vigor; staminaXP += stamina; processingXP += processing; } private void CheckLevelProgress() { swordsLevel = Mathf.Clamp(GetLevelFromXP(swordsXP, swordsXPPerLevel), 1, 30); axesLevel = Mathf.Clamp(GetLevelFromXP(axesXP, axesXPPerLevel), 1, 30); fistsLevel = Mathf.Clamp(GetLevelFromXP(fistsXP, fistsXPPerLevel), 1, 30); foragingLevel = Mathf.Clamp(GetLevelFromXP(foragingXP, foragingXPPerLevel), 1, 30); fishingLevel = Mathf.Clamp(GetLevelFromXP(fishingXP, fishingXPPerLevel), 1, 30); agilityLevel = Mathf.Clamp(GetLevelFromXP(agilityXP, agilityXPPerLevel), 1, 30); vigorLevel = Mathf.Clamp(GetLevelFromXP(vigorXP, vigorXPPerLevel), 1, 30); staminaLevel = Mathf.Clamp(GetLevelFromXP(staminaXP, staminaXPPerLevel), 1, 30); processingLevel = Mathf.Clamp(GetLevelFromXP(processingXP, processingXPPerLevel), 1, 30); } private int GetLevelFromXP(float xp, float xpPerLevel) { return Mathf.FloorToInt(xp / xpPerLevel) + 1; } }
