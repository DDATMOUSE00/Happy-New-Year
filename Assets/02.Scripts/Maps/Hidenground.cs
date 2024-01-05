using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidenground : MonoBehaviour
{
    public GameObject hidenGround;

    private void Awake()
    {
        hidenGround.SetActive(false);
    }

    // 보스가 죽었을 때, 이 발판을 true되게

}
