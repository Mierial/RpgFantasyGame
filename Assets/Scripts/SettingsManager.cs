using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Slider playerMusicSlider;
    [SerializeField] private Slider gameMusicSlider;

    private void Start()
    {
        playerMusicSlider.value = PlayerPrefs.GetFloat(Constants.VolumePlayer, 0.5f);
        gameMusicSlider.value = PlayerPrefs.GetFloat(Constants.VolumeGame, 0.5f);

        playerMusicSlider.onValueChanged.AddListener(value => AudioManager.Instance.SetPlayerVolume(value));
        gameMusicSlider.onValueChanged.AddListener(value => AudioManager.Instance.SetGameVolume(value));
    }

    private void OnDisable()
    {
        AudioManager.Instance.SaveVolumes();
    }
}
