using UnityEngine;
using IndieWizards.DataStorage;
using System;

namespace IndieWizards.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource musicAudioSource;
        public AudioSource sfxAudioSource;

        public AudioClip titleMusic;

        public AudioClip cubeSlurp;
        public AudioClip acidAttack;
        public AudioClip acidSprayWithLoop;

        private PlayerSettings playerSettings;

        private void Awake()
        {
            playerSettings = GameObject.FindObjectOfType<PlayerSettings>();

            if (playerSettings == null)
            {
                Debug.LogError("PlayerSettings could not be found. This is required by the AudioManager to work correctly.");
            }

            playerSettings.onVolumeChanged += HandleVolumeChanged;
        }

        private void Start()
        {
            SetVolumeLevels();
        }

        public void PlayGameMusic()
        {
            Debug.LogError("Not implemented");
        }

        public void PlayMainMenuMusic()
        {
            musicAudioSource.Stop();
            musicAudioSource.clip = titleMusic;
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
