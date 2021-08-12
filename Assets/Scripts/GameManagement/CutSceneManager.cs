using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Audio;

namespace IndieWizards.GameManagement
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SceneLoader))]
    public class CutSceneManager : MonoBehaviour
    {
        private SceneLoader sceneLoader;
        private Animator animator;
        [SerializeField] private AudioManager audioManager;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            sceneLoader = GetComponent<SceneLoader>();
        }

        private void Start()
        {
            animator.enabled = true;
            audioManager.PlayCutSceneMusic();
        }

        public void CutSceneCompleted()
        {
            animator.enabled = false;
            sceneLoader.LoadGameScene();  
        }
    }
}
