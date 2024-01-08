using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public class LevelRange // 레벨 범위
{
    public int startLevel;  // 시작 레벨

    public int endLevel;    // 끝 레벨

    public int experienceCapIncrease;   // 경험치량 
}


public class Exp : MonoBehaviour
{
    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    public List<LevelRange> levelRanges;

    public Slider expSlider;

    public TextMeshProUGUI lvTxt;

    void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease;
        SetCapExp(experienceCap);
    }

    private void Update()
    {
        lvTxt.text = "LV. " + level;
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;
        SetExp(experience);

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
            SetCapExp(experienceCap);
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
