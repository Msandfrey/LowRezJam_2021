using System.Collections;
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
        public AudioClip cutSceneMusic;

        [Header("Sound Effects")]
        public AudioClip acidAttack;
        public AudioClip acidSprayWithLoop;
        public AudioClip healing;
        public AudioClip poison;
        public AudioClip cubeSlurp;
        public AudioClip cubeTakeDamage; 
        public AudioClip cubeAttack;
        public AudioClip cubeDeath;
        public AudioClip enemyShout;
        public AudioClip enemyTakeDamage;
        public AudioClip enemyAttack;
        public AudioClip enemyDeath;

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

        public void PlayCutSceneMusic()
        {
            PlayMusic(cutSceneMusic);
        }

        public void PlayAcidAttack()
        {
            sfxAudioSource.PlayOneShot(acidAttack);
        }

        public void PlayAcidSprayLoop()
        {
            sfxAudioSource.PlayOneShot(acidSprayWithLoop);
        }

        public void PlayHealingSound()
        {
            sfxAudioSource.PlayOneShot(healing);
        }

        public void PlayPoisonSound(AudioClip clip)
        {
            sfxAudioSource.Stop();
            sfxAudioSource.clip = clip;
            sfxAudioSource.loop = true;
            sfxAudioSource.volume = 10f * 10f;
            sfxAudioSource.Play();
            StartCoroutine(WaitForMe());
        }

        private IEnumerator WaitForMe()
        {
            yield return new WaitForSeconds(5);
            sfxAudioSource.Stop();
        }

        public void PlayCubeSlurp()
        {
            sfxAudioSource.PlayOneShot(cubeSlurp);
        }

        public void PlayCubeTakeDamage()
        {
            sfxAudioSource.PlayOneShot(cubeTakeDamage);
        }

        public void PlayCubeAttack()
        {
            sfxAudioSource.PlayOneShot(cubeAttack);
        }

        public void PlayCubeDeath()
        {
            sfxAudioSource.PlayOneShot(cubeDeath);
        }

        public void PlayEnemyAlertSound()
        {
            sfxAudioSource.PlayOneShot(enemyShout);
        }

        public void PlayEnemyDeathSound()
        {
            sfxAudioSource.PlayOneShot(enemyDeath);
        }
        
        public void PlayEnemyTakesDamageSound()
        {
            sfxAudioSource.PlayOneShot(enemyTakeDamage);
        }

        public void PlayEnemyAttackSound()
        {
            sfxAudioSource.PlayOneShot(enemyAttack);
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
