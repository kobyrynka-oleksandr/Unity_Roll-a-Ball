using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Slider volumeValueSlider;
    [SerializeField] private TextMeshProUGUI volumeValueLabel;
    [SerializeField] private Slider enemyCountSlider;
    [SerializeField] private TextMeshProUGUI enemyCountLabel;

    private void Start()
    {
        enemyCountSlider.value = GameSettings.EnemyCount;
        UpdateEnemyCountLabel(GameSettings.EnemyCount);

        volumeValueSlider.value = GameSettings.MusicVolume;
        UpdateVolumeValue(GameSettings.MusicVolume);

        enemyCountSlider.onValueChanged.AddListener(OnEnemyCountSliderChanged);
        volumeValueSlider.onValueChanged.AddListener(OnVolumeValueSliderChanged);
    }

    private void OnEnemyCountSliderChanged(float value)
    {
        int count = Mathf.RoundToInt(value);
        GameSettings.EnemyCount = count;
        UpdateEnemyCountLabel(count);
    }

    private void OnVolumeValueSliderChanged(float value)
    {
        GameSettings.MusicVolume = value;
        UpdateVolumeValue(value);

        if (MusicManager.Instance != null)
            MusicManager.Instance.SetVolume(value);
    }

    private void UpdateEnemyCountLabel(int count)
    {
        enemyCountLabel.text = $"Enemies: {count}";
    }

    private void UpdateVolumeValue(float displayValue)
    {
        volumeValueLabel.text = $"Volume: {Mathf.RoundToInt(displayValue * 1000)}";
    }
}
