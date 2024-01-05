using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class LevelRange // 레벨 범위
{
    public int startLevel;

    public int endLevel;

    public int experienceCapIncrease;
}


public class Exp : MonoBehaviour
{
    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    public List<LevelRange> levelRanges;

    public Slider expSlider;

    void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;

        LevelUpChecker();
    }


    void LevelUpChecker()
    {
        if(experience >= experienceCap)
        {
            level++;

            experience -= experienceCap;

            int experienceCapIncrease = 0;
            foreach(LevelRange range in levelRanges)
            {
                if(level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }

            experienceCap += experienceCapIncrease;
        }
    }

    public void SetCapExp(int exp)
    {
        expSlider.maxValue = exp;
        expSlider.value = exp;
    }

    public void SetExp(int exp)
    {
        expSlider.value = exp;
    }
}
