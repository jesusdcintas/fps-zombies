// Copyright 2021, Infima Games. All Rights Reserved.

using UnityEngine;
using UnityEngine.InputSystem;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Input Manager Component. Handles all input action callbacks and event subscriptions.
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        #region FIELDS SERIALIZED

        [Tooltip("The player input component that manages input actions.")]
        [SerializeField]
        private PlayerInput playerInput;

        #endregion

        #region FIELDS

        /// <summary>
        /// Reference to the flashlight component.
        /// </summary>
        private Flashlight flashlight;

        #endregion

        #region UNITY FUNCTIONS

        /// <summary>
        /// Start - Subscribe to input actions.
        /// </summary>
        private void Start()
        {
            //Get PlayerInput if not assigned.
            if (playerInput == null)
                playerInput = GetComponent<PlayerInput>();

            //Get Flashlight component from children or parent.
            if (flashlight == null)
                flashlight = GetComponentInChildren<Flashlight>();

            //Debug info
            Debug.Log("[InputManager] Inicializando...");
            Debug.Log($"[InputManager] PlayerInput encontrado: {(playerInput != null)}");
            Debug.Log($"[InputManager] Flashlight encontrado: {(flashlight != null)}");

            //Subscribe to the Flashlight action if available.
            if (playerInput != null && playerInput.actions != null)
            {
                //Get the Flashlight action.
                var flashlightAction = playerInput.actions.FindAction("Flashlight");
                Debug.Log($"[InputManager] Acción Flashlight encontrada: {(flashlightAction != null)}");
                
                if (flashlightAction != null && flashlight != null)
                {
                    //Subscribe the callback.
                    flashlightAction.performed += flashlight.OnToggleFlashlight;
                    Debug.Log("[InputManager] Callback de Flashlight conectado exitosamente");
                }
                else
                {
                    Debug.LogError("[InputManager] No se pudo conectar el callback de Flashlight");
                }
            }
            else
            {
                Debug.LogError("[InputManager] PlayerInput o Actions son null");
            }
        }

        /// <summary>
        /// OnDestroy - Unsubscribe from input actions.
        /// </summary>
        private void OnDestroy()
        {
            //Unsubscribe to avoid memory leaks.
            if (playerInput != null && playerInput.actions != null)
            {
                //Get the Flashlight action.
                var flashlightAction = playerInput.actions.FindAction("Flashlight");
                if (flashlightAction != null && flashlight != null)
                {
                    //Unsubscribe the callback.
                    flashlightAction.performed -= flashlight.OnToggleFlashlight;
                }
            }
        }

        #endregion
    }
}
