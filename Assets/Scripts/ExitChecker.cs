using UnityEngine;

public class ExitChecker : MonoBehaviour
{
    GameManager _gameManager;

    void Start()
    {
        _gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _gameManager.ExitedFirstArea = true;
            gameObject.SetActive(false);
        }
    }
}
