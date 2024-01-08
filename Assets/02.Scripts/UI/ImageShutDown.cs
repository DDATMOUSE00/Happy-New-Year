using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageShutDown : MonoBehaviour
{
    public GameObject KeyPanel;

    // Start is called before the first frame update
    void Start()
    {
        KeyPanel = GameObject.Find("KeyImage");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && KeyPanel.activeSelf == true) KeyPanel.SetActive(false);
    }
}
