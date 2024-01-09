using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gold : MonoBehaviour
{
    [SerializeField] private int _goldScore;
    public TextMeshProUGUI GoldUI;

    // Start is called before the first frame update
    void Start()
    {
        _goldScore = 0;
        checkGold();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkGold()
    {
        GoldUI.text = "Gold : " + _goldScore;
    }

    public void collectGold(int loot)
    {
        _goldScore += loot;
    }

    public void useGold(int loot)
    {
        if (_goldScore > 0) _goldScore -= loot;
    }
}
