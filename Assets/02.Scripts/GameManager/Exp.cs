using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    void Update()
    {
        
    }
}
