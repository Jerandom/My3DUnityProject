using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool aim;
		public bool shoot;
		public bool bInventory;
		public bool openInventory;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
        public void OnAim(InputValue value)
        {
            AimInput(value.isPressed);
        }

        public void OnShoot(InputValue value)
        {
            ShootInput(value.isPressed);
        }

   //     public void bOpenInventory(InputValue value)
   //     {
			//bInventory = !bInventory;
   //     }

        public void OnInventory(InputValue value)
        {
            bInventory = !bInventory;
            if (bInventory)
			{
                InventoryInput(value.isPressed);
            }
        }

        public void OnMouseCursor(InputValue value)
        {
            if (cursorLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                LookInput(new Vector2(0, 0));
                cursorLocked = false;
                cursorInputForLook = false;
            }
            else if (!cursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                cursorLocked = true;
                cursorInputForLook = true;
            }
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
        public void AimInput(bool newAimState)
        {
            aim = newAimState;
        }

        public void ShootInput(bool newShootState)
        {
            shoot = newShootState;
        }

        public void InventoryInput(bool newOpenInventoryState)
        {
            openInventory = newOpenInventoryState;
        }

        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}