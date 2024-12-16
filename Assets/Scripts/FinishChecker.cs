using UnityEngine;

public class FinishChecker : MonoBehaviour
{
    GameManager _gameManager;

    void Start()
    {
        _gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_gameManager.GameOver)
        {
            _gameManager.GameWin();
            gameObject.SetActive(false);
        }
    }
}
