using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextSceneName;
    public Vector3 nextScenePlayerPosition;

    public Vector2 nextSceneCameraCenter;
    public Vector2 nextSceneCameraMapSize;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
            other.transform.position = nextScenePlayerPosition;
            CameraController.Instance.center = nextSceneCameraCenter;
            CameraController.Instance.mapSize = nextSceneCameraMapSize;
        }
    }
}
