using System;
using UnityEngine;

namespace  IndieWizards.DataStorage
{
    public class PlayerSettings : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("For debug purposes only. Set to true to force all player settings to get cleared each time the script loads.")]
        private bool clearSettings = false;

        private const string PlayerPrefKeyTotalVolume = "TotalVolume";
        private const int DefaultVolume = 50;

        public int Volume { get; set; }
        public float VolumeAsPercent { get { return Volume / 100.0f; } }

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
