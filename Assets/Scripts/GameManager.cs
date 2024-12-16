using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool ExitedFirstArea = false;
    public bool GameOver = false;

    [SerializeField] AudioSource gaspAudioSource;
    [SerializeField] AudioSource reliefAudioSource;

    [SerializeField] GameObject eurydiceParticleSystem;
    [SerializeField] Transform xrOrigin;
    [SerializeField] float distFromPlayer = 5f;
    [SerializeField] float heightOfParticles = 1.0f;

    [SerializeField] float timeWaitLoad = 2f;
    [SerializeField] string loseSceneName;
    [SerializeField] string winSceneName;

    SceneLoader _sceneLoader;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager is NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _sceneLoader = SceneLoader.Instance;
    }

    void UpdateEurydicePosition()
    {
        Vector3 newPos = new Vector3(0, xrOrigin.position.y + heightOfParticles, xrOrigin.position.z + distFromPlayer);
        eurydiceParticleSystem.transform.position = newPos;
    }

    public void GameLose()
    {
        GameOver = true;
        gaspAudioSource.Play();
        UpdateEurydicePosition();
        eurydiceParticleSystem.GetComponent<ParticleSystem>().Play();

        StartCoroutine(WaitToLoadScene(loseSceneName));
    }

    IEnumerator WaitToLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(timeWaitLoad);

        _sceneLoader.LoadScene(sceneName);
    }

    public void GameWin()
    {
        GameOver = true;
        reliefAudioSource.Play();

        StartCoroutine(WaitToLoadScene(winSceneName));
    }
}
