using UnityEngine;

namespace Scythe.Accessibility
{
    public class PlayerInputManager : MonoBehaviour
    {
        private void Awake()
        {
            PlayerInputMapping.LoadBindings();
        }

        private void Update()
        {
            CheckInput(PlayerAction.Forward);
            CheckInput(PlayerAction.Backwards);
            CheckInput(PlayerAction.StrafeLeft);
            CheckInput(PlayerAction.StrafeRight);
            CheckInput(PlayerAction.Jump);
            CheckInput(PlayerAction.Crouch);
            CheckInput(PlayerAction.Sprint);
            CheckInput(PlayerAction.Interact);
            // Add other actions here...
        }

        private void CheckInput(PlayerAction action)
        {
            var binding = PlayerInputMapping.keyBindings[action];
            bool isActionTriggered = false;

            if (binding.pressType == KeyPressType.Single)
            {
                isActionTriggered = Input.GetKeyDown(binding.key);
            }
            else if (binding.pressType == KeyPressType.Continuous)
            {
                isActionTriggered = Input.GetKey(binding.key);
            }

            if (isActionTriggered)
            {
                ExecuteAction(action);
            }
        }

        private void ExecuteAction(PlayerAction action)
        {
            // Handle the logic for each action
            switch (action)
            {
                case PlayerAction.Forward:
                    // Logic for moving forward
                    break;

                case PlayerAction.Backwards:
                    // Logic for moving backwards
                    break;

                case PlayerAction.StrafeLeft:
                    // Logic for strafing left
                    break;

                case PlayerAction.StrafeRight:
                    // Logic for strafing right
                    break;

                case PlayerAction.Jump:
                    // Logic for jumping
                    break;

                case PlayerAction.Crouch:
                    // Logic for crouching
                    break;

                case PlayerAction.Sprint:
                    // Logic for sprinting
                    break;

                case PlayerAction.Interact:
                    // Logic for interacting
                    break;
            }
        }
    }
}