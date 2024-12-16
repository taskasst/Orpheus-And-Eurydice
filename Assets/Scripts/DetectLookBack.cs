using UnityEngine;

public class DetectLookBack : MonoBehaviour
{
    [SerializeField] float lookAngle = 80f;
    [SerializeField] Transform behindTransform;
    [SerializeField] Transform xrOriginTransform;
    [SerializeField] Camera xrCamera;

    Vector3 directionBackwards;
    GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (_gameManager.ExitedFirstArea && !_gameManager.GameOver)
        {
            directionBackwards = behindTransform.position - xrOriginTransform.position;

            //xrCamera.fieldOfView
            if (Vector3.Angle(xrCamera.transform.forward, directionBackwards) <= lookAngle)
            {
                //Debug.Log("Looking back");
                _gameManager.GameLose();
            }
        }
    }
}
