using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private TMPro.TMP_Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject unPauseBtn;

    [SerializeField] private GameObject backBtn;
    public int score { get; private set; } = 0;

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
        }
        unPauseBtn.SetActive(false); 
        backBtn.SetActive(false);
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            unPauseBtn.SetActive(true);
            backBtn.SetActive(true);
            Pause();
        }
    }
    private void Start()
    {
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        unPauseBtn.SetActive(false);
        backBtn.SetActive(false);
    }


    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        backBtn.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        backBtn.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
