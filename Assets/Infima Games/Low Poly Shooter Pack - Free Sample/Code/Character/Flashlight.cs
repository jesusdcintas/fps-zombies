// Copyright 2021, Infima Games. All Rights Reserved.

using UnityEngine;
using UnityEngine.InputSystem;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Flashlight Component. Controls the flashlight (torch) light that can be toggled on/off.
    /// </summary>
    public class Flashlight : MonoBehaviour
    {
        #region FIELDS SERIALIZED

        [Header("Light")]
        
        [Tooltip("The light component to toggle on/off.")]
        [SerializeField]
        private Light flashlightLight;

        #endregion

        #region FIELDS

        /// <summary>
        /// True if the flashlight is currently active.
        /// </summary>
        private bool flashlightActive;

        /// <summary>
        /// Player Character reference.
        /// </summary>
        private CharacterBehaviour playerCharacter;

        #endregion

        #region UNITY FUNCTIONS

        /// <summary>
        /// Awake.
        /// </summary>
        private void Awake()
        {
            //Get Player Character.
            playerCharacter = ServiceLocator.Current.Get<IGameModeService>().GetPlayerCharacter();
            
            //If we don't have a light assigned, try to find one in the children.
            if (flashlightLight == null)
                flashlightLight = GetComponentInChildren<Light>();
            
            //Start with the flashlight disabled.
            if (flashlightLight != null)
                flashlightLight.enabled = false;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Toggle the flashlight on/off.
        /// </summary>
        public void OnToggleFlashlight(InputAction.CallbackContext context)
        {
            Debug.Log($"[Flashlight] OnToggleFlashlight llamado. Fase: {context.phase}");
            
            //Block while the cursor is unlocked.
            if (playerCharacter != null && !playerCharacter.IsCursorLocked())
            {
                Debug.Log("[Flashlight] Cursor no está bloqueado. Ignorando.");
                return;
            }

            //Switch.
            switch (context.phase)
            {
                //Performed - Toggle the flashlight.
                case InputActionPhase.Performed:
                    Debug.Log("[Flashlight] Alternando linterna...");
                    ToggleFlashlight();
                    break;
            }
        }

        /// <summary>
        /// Toggles the flashlight on or off.
        /// </summary>
        private void ToggleFlashlight()
        {
            //Make sure we have a light to control.
            if (flashlightLight == null)
            {
                Debug.LogError("[Flashlight] La luz no está asignada!");
                return;
            }

            //Toggle the active state.
            flashlightActive = !flashlightActive;

            //Update the light state.
            flashlightLight.enabled = flashlightActive;
            
            Debug.Log($"[Flashlight] Linterna ahora está: {(flashlightActive ? "ENCENDIDA" : "APAGADA")}");
        }

        #endregion
    }
}
