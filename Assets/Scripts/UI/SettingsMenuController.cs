using UnityEngine;
using TMPro;
using IndieWizards.DataStorage;

namespace IndieWizards.UI
{
    public class SettingsMenuController : MonoBehaviour
    {
        private const int MaxVolumePercent = 100;
        private const int MinVolumePercent = 0;

        [SerializeField]
        private TextMeshProUGUI volumePercentText;

        [SerializeField]
        private int volumeIncrement = 10;

        [SerializeField]
        private PlayerSettings playerSettings;
        public int volumePercent;
        
        private void Start()
        {
            volumePercent = playerSettings.Volume;
            UpdateVolume(volumePercent);
        }

        public void IncreaseVolume()
        {
            volumePercent = Mathf.Min(volumePercent + volumeIncrement, MaxVolumePercent);
            UpdateVolume(volumePercent);
        }

        public void DecreaseVolume()
        {
            volumePercent = Mathf.Max(volumePercent - volumeIncrement, MinVolumePercent);
            UpdateVolume(volumePercent);
        }

        public void Save()
        {
            playerSettings.Save();
        }

        private void UpdateVolume(int volumePercent)
        {
            volumePercentText.text = volumePercent + "%";
            playerSettings.Volume = volumePercent;
        }
    }
}