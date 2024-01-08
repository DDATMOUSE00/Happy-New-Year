using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private static CameraController _instance;

    public static CameraController Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Camera");
                go.AddComponent<CameraController>();
                _instance = go.GetComponent<CameraController>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
        set
        {
            if (_instance == null) _instance = value;
        }
    }

    public Transform playerTransform;
    private Vector3 cameraPosition = new Vector3(0, 0, -10);

    public float cameraMoveSpeed = 5f;

    public Vector2 center;
    public Vector2 mapSize;

    private float cameraHeight;
    private float cameraWidth;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (_instance != this) Destroy(this);
            if (SceneManager.GetActiveScene().buildIndex == 0) Destroy(this);
        }
    }

    private void Start()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;

    }

    private void FixedUpdate()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + cameraPosition, Time.deltaTime * cameraMoveSpeed);

        float lx = mapSize.x * 0.5f - cameraWidth;
        float ly = mapSize.y * 0.5f - cameraHeight;

        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize);
    }
}
