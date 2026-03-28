using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private PickupSpawner pickupSpawner;
    [SerializeField] private RetryPanelManager retryPanelManager;
    [SerializeField] private ParticleSystem pickupEffectPrefab;

    public static GameManager Instance { get; private set; }

    private int count;

    private Vector3 playerStartPosition;
    private Vector3[] enemyStartPositions;
    private Quaternion playerStartRotation;
    private Quaternion[] enemyStartRotations;

    private void Awake()
    {
        playerStartPosition = player.transform.position;
        playerStartRotation = player.transform.rotation;

        enemyStartPositions = new Vector3[enemies.Length];
        enemyStartRotations = new Quaternion[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyStartPositions[i] = enemies[i].transform.position;
            enemyStartRotations[i] = enemies[i].transform.rotation;
        }

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        GameEvents.OnPickupCollected += IncrementCount;
        GameEvents.OnPlayerDied += SetLose;
        GameEvents.OnPickupCollected += pickupSpawner.OnPickupCollected;

        StartGame();
    }

    public void StartGame()
    {
        count = 0;
        countText.gameObject.SetActive(true);
        retryPanelManager.RemovePanel();

        player.SetActive(true);
        int enemiesToSpawn = GameSettings.EnemyCount;
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(i < enemiesToSpawn);
            if (i < enemiesToSpawn)
                enemyStartPositions[i] = enemies[i].transform.position;
        }

        pickupSpawner.SpawnNextPickup();

        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        count = 0;
        countText.gameObject.SetActive(true);
        countText.text = "0";
        retryPanelManager.RemovePanel();

        player.SetActive(true);
        var rollingSound = player.GetComponent<BallRollingSound>();
        if (rollingSound != null)
            rollingSound.EnableSound();

        player.transform.position = playerStartPosition;
        player.transform.rotation = playerStartRotation;
        var rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        int enemiesToSpawn = GameSettings.EnemyCount;
        for (int i = 0; i < enemies.Length; i++)
        {
            bool isActive = i < enemiesToSpawn;
            enemies[i].SetActive(isActive);
            if (isActive)
                enemies[i].transform.position = enemyStartPositions[i];
        }

        pickupSpawner.ResetAndSpawn();

        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        GameEvents.OnPickupCollected -= IncrementCount;
        GameEvents.OnPlayerDied -= SetLose;
        GameEvents.OnPickupCollected -= pickupSpawner.OnPickupCollected;
    }

    private void IncrementCount()
    {
        count++;
        countText.text = $"{count}";
    }

    private void SetLose()
    {
        var rollingSound = player.GetComponent<BallRollingSound>();
        if (rollingSound != null)
            rollingSound.StopSound();

        Time.timeScale = 0f;
        retryPanelManager.GetScore($"{count}");
        retryPanelManager.ShowPanel();

        countText.gameObject.SetActive(false);

    }

    public void SpawnPickupEffect(Vector3 position)
    {
        ParticleSystem effect = Instantiate(pickupEffectPrefab, position, Quaternion.identity);
        Destroy(effect.gameObject, effect.main.duration + 0.5f);
    }
}
