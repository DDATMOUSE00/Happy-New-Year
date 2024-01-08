using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;

public class Exp : MonoBehaviour
{
    private int experience = 0;
    private int level = 1;
    private int MaxExperience = 10;

    public Slider expSlider;
    public TextMeshProUGUI lvTxt;


    private void Update()
    {
        UpdateExp();
        lvTxt.text = "LV. " + level;
    }

    public void GetExp(int amount)
    {
        experience += amount;
        ExpSetting();
    }

    private void ExpSetting()
    {
        if(experience >= MaxExperience)
        {
            level++;
            experience -= MaxExperience;
            MaxExperience += 5;
            LevelUpPlayer();
        }
    }
    private void LevelUpPlayer()
    {
        //플레이어 공격력, 체력 상승
    }

    public void UpdateExp()
    {
        expSlider.value = experience;
        expSlider.maxValue = MaxExperience;
    }
}
