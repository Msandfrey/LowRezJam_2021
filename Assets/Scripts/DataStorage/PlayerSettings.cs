using UnityEngine;

namespace  IndieWizards.DataStorage
{
    public class PlayerSettings : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("For debug purposes only. Set to true to force all player settings to get cleared each time the script loads.")]
        private bool clearSettings = false;

        private const string PlayerPrefKeyTotalVolume = "TotalVolume";
        private const string PlayerPrefKeyMusicVolume = "MusicVolume";
        private const string PlayerPrefKeySoundEffectsVolume = "SoundEffectsVolume";

        private const float DefaultVolume = 0.5f;

        public float TotalVolume { get; set; }
        public float MusicVolume { get; set; }
        public float SoundEffectsVolume { get; set; }

        private void Start()
        {
            if (clearSettings)
            {
                PlayerPrefs.DeleteAll();
            }

            MusicVolume = PlayerPrefs.GetFloat(PlayerPrefKeyMusicVolume, DefaultVolume);
            TotalVolume = PlayerPrefs.GetFloat(PlayerPrefKeyTotalVolume, DefaultVolume);
            SoundEffectsVolume = PlayerPrefs.GetFloat(PlayerPrefKeySoundEffectsVolume, DefaultVolume);
        }

        public void Save()
        {
            PlayerPrefs.SetFloat(PlayerPrefKeyMusicVolume, MusicVolume);
            PlayerPrefs.SetFloat(PlayerPrefKeySoundEffectsVolume, SoundEffectsVolume);
            PlayerPrefs.SetFloat(PlayerPrefKeyTotalVolume, TotalVolume);
        }
    }
}
