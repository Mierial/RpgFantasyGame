using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource playerSource;
    [SerializeField] private AudioSource gameSource;

    [SerializeField] private Slider playerVolumeSlider;
    [SerializeField] private Slider gameVolumeSlider; 

    private float playerVolume;
    private float gameVolume;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        playerVolume = PlayerPrefs.GetFloat(Constants.VolumePlayer, 0.5f);
        gameVolume = PlayerPrefs.GetFloat(Constants.VolumeGame, 0.5f);

        InitializeSliders();

        UpdateVolumes();
    }

    private void InitializeSliders()
    {
        if (playerVolumeSlider != null)
        {
            playerVolumeSlider.value = playerVolume;
            playerVolumeSlider.onValueChanged.AddListener(SetPlayerVolume);
        }

        if (gameVolumeSlider != null)
        {
            gameVolumeSlider.value = gameVolume;
            gameVolumeSlider.onValueChanged.AddListener(SetGameVolume);
        }
    }

    public void SetPlayerVolume(float volume)
    {
        playerVolume = volume;
        playerSource.volume = playerVolume;
    }

    public void SetGameVolume(float volume)
    {
        gameVolume = volume;
        gameSource.volume = gameVolume;
    }

    public void SaveVolumes()
    {
        PlayerPrefs.SetFloat(Constants.VolumePlayer, playerVolume);
        PlayerPrefs.SetFloat(Constants.VolumeGame, gameVolume);
    }

    private void UpdateVolumes()
    {
        playerSource.volume = playerVolume;
        gameSource.volume = gameVolume;
    }

    private void OnApplicationQuit()
    {
        SaveVolumes();
    }
}
