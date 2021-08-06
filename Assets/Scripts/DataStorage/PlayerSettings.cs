using System;
using UnityEngine;

namespace  IndieWizards.DataStorage
{
    public class PlayerSettings : MonoBehaviour
    {
        public delegate void VolumeChangedCallback();
        public VolumeChangedCallback onVolumeChanged;

        [SerializeField]
        [Tooltip("For debug purposes only. Set to true to force all player settings to get cleared each time the script loads.")]
        private bool clearSettings = false;

        private const string PlayerPrefKeyTotalVolume = "TotalVolume";
        private const int DefaultVolume = 50;

        private int volume;

        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
                onVolumeChanged.Invoke();
            }
        }

        public float VolumeAsDecimal
        {
            get
            {
                return Volume / 100.0f;
            }
        }

        private void Awake()
        {
            if (clearSettings)
            {
                PlayerPrefs.DeleteAll();
            }

            Volume = PlayerPrefs.GetInt(PlayerPrefKeyTotalVolume, DefaultVolume);
        }

        public void Save()
        {
            PlayerPrefs.SetInt(PlayerPrefKeyTotalVolume, Volume);
            PlayerPrefs.Save();
        }
    }
}
