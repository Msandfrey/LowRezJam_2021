using UnityEngine;
using IndieWizards.DataStorage;

namespace IndieWizards.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Sources")]
        public AudioSource musicAudioSource;
        public AudioSource sfxAudioSource;

        [Header("Music Tracks")]
        public AudioClip titleMusic;
        public AudioClip gameMusic;

        [Header("Sound Effects")]
        public AudioClip cubeSlurp;
        public AudioClip acidAttack;
        public AudioClip acidSprayWithLoop;

        private PlayerSettings playerSettings;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            playerSettings = GameObject.FindObjectOfType<PlayerSettings>();

            if (playerSettings == null)
            {
                Debug.LogError("PlayerSettings could not be found. This is required by the AudioManager to work correctly.");
            }

            playerSettings.onVolumeChanged += HandleVolumeChanged;

            SetVolumeLevels();
        }

        public void PlayGameMusic()
        {
            PlayMusic(gameMusic);
        }

        public void PlayMainMenuMusic()
        {
            PlayMusic(titleMusic);
        }

        public void PlayCubeSlurp()
        {
            sfxAudioSource.PlayOneShot(cubeSlurp);
        }

        private void PlayMusic(AudioClip clip)
        {
            musicAudioSource.Stop();
            musicAudioSource.clip = clip;
            musicAudioSource.loop = true;
            musicAudioSource.Play();
        }

        private void HandleVolumeChanged()
        {
            SetVolumeLevels();
        }

        private void SetVolumeLevels()
        {
            Debug.Log("Setting volume => " + playerSettings.VolumeAsDecimal);

            musicAudioSource.volume = playerSettings.VolumeAsDecimal;
            sfxAudioSource.volume = playerSettings.VolumeAsDecimal;
        }
    }
}
