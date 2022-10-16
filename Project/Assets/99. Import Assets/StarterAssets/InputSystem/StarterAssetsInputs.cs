using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
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
		public bool aiming;
		public bool attack;
		public bool dodge;
		public bool ultimate;
		public bool skill;
		public bool interaction;
		public bool pause;
		public bool status;
		public bool item01;
		public bool item02;
		public bool item03;
		public bool weapon;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
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
		public void OnAiming(InputValue value)
        {
			AimingInput(value.isPressed);
		}
		public void OnAttack(InputValue value)
		{
			AttackInput(value.isPressed);
		}
		public void OnDodge(InputValue value)
        {
			DodgeInput(value.isPressed);
        }
		public void OnUltimate(InputValue value)
        {
			UltimateInput(value.isPressed);
		}
		public void OnSkill(InputValue value)
		{
			SkillInput(value.isPressed);
		}
		public void OnPause(InputValue value)
		{
			PauseInput(value.isPressed);
		}
		public void OnStatus(InputValue value)
		{
			StatusInput(value.isPressed);
		}
		public void OnInteraction(InputValue value)
		{
			InteractionInput(value.isPressed);
		}
		public void OnItem01(InputValue value)
		{
			Item01Input(value.isPressed);
		}
		public void OnItem02(InputValue value)
		{
			Item02Input(value.isPressed);
		}
		public void OnItem03(InputValue value)
		{
			Item03Input(value.isPressed);
		}
		public void OnWeapon(InputValue value)
        {
			WeaponInput(value.isPressed);
        }



#endif



		public void WeaponInput(bool newWeaponState)
        {
			weapon = newWeaponState;
        }
		public void UltimateInput(bool newUltimateState)
		{
			ultimate = newUltimateState;
		}
		public void SkillInput(bool newSkillState)
		{
			skill = newSkillState;
		}
		public void PauseInput(bool newPauseState)
		{
			pause = newPauseState;
		}
		public void InteractionInput(bool newInteractionState)
		{
			interaction = newInteractionState;
		}
		public void StatusInput(bool newStatusState)
		{
			status = newStatusState;
		}
		public void Item01Input(bool newItem01State)
		{
			item01 = newItem01State;
		}
		public void Item02Input(bool newItem02State)
        {
			item02 = newItem02State;
		}
		public void Item03Input(bool newItem03State)
		{
			item03 = newItem03State;
		}
		public void DodgeInput(bool newDodgeState)
        {
			dodge = newDodgeState;
        }
		public void AimingInput(bool newAimingState)
        {
			aiming = newAimingState;
        }
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
		public void AttackInput(bool newAttackState)
		{
			attack = newAttackState;
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