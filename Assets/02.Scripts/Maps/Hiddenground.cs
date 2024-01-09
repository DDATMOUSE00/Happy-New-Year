using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiddenground : MonoBehaviour
{
    public GameObject hiddenGround;

    private void Awake()
    {
        hiddenGround.SetActive(false);
    }

    // 보스가 죽었을 때, 이 발판을 true되게

}
