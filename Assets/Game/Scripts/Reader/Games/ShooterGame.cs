using System;
using Cinemachine;
using Game.Reader.Games.ShootingGame;
using UnityEngine;

namespace Game.Reader.Games
{
    /// <summary>
    /// Simple shooter mini-game
    /// </summary>
    public class ShooterGame : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private CinemachineVirtualCamera gameCamera;
        [SerializeField] private WitchHealth witchHealth;
        [SerializeField] private WinMenu winMenu;
        [SerializeField] private TouchManager touchManager;
        
        private void OnEnable()
        {
            witchHealth.WitchDefeated += OnWitchDefeated;
        }

        private void OnDisable()
        {
            witchHealth.WitchDefeated -= OnWitchDefeated;
        }

        private void Start()
        {
            Debug.Log("[ShooterGame] Start");
        }

        private void OnWitchDefeated()
        {
            winMenu.ShowWinMenu();
            touchManager.enabled = false;
        }
    }
}
