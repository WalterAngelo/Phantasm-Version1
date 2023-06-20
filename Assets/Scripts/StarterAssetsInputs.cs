using System.Collections;
using System.Collections.Generic;
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

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		public Flashlight flashlightController;
		public PlayerController playerController;
		public InventoryUI inventoryUIController;
		public EquipItemsController equipItemsController;
		public QuestUIController questUIController;
		public List<EnemyController> enemies = new List<EnemyController>();
		public NotebookModelController notebookModelController;


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

		public void OnFlashlight(InputValue value)
        {
			if(Time.timeScale == 1)
            {
				FlashlightInput(value.isPressed);
			}
        }

		public void OnOpenNotebook(InputValue value)
		{
			if(Time.timeScale == 1)
            {
				OpenNotebookInput(value.isPressed);
			}
		}

		public void OnInteractObject(InputValue value)
		{
			if(Time.timeScale == 1)
            {
				InteractObjectInput(value.isPressed);
			}
		}

		public void OnReload(InputValue value)
		{
			if(Time.timeScale == 1)
            {
				ReloadInput(value.isPressed);
			}
		}

		public void OnInventory(InputValue value)
		{
			if(Time.timeScale == 1)
            {
				InventoryInput(value.isPressed);
			}
		}

		public void OnTurnAround(InputValue value)
		{

		}

		public void OnSave(InputValue value)
        {
			SaveInput(value.isPressed);
        }

		public void OnLoad(InputValue value)
        {
			LoadInput(value.isPressed);
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

		public void FlashlightInput(bool newFlashlightState)
        {
			if(cursorInputForLook && playerController.flashlightReady)
            {
				flashlightController.ToggleFlashlight();
			}
        }

		public void OpenNotebookInput(bool newOpenNotebookState)
		{
			playerController.ToggleNotebook();
		}

		public void InteractObjectInput(bool newInteractObjectState)
		{
			if (playerController.currentHitObject != null)
			{
				if (playerController.currentHitObject.tag == "PickableItem")
				{
					playerController.PickItem(playerController.currentHitObject);
					inventoryUIController.InventoryUIUpdate();
				}
				else if (playerController.currentHitObject.tag == "InteractableItem")
				{
					EquipableObjects currentItem = null;
					if (equipItemsController.currentequippedItem != null)
					{
						currentItem = equipItemsController.currentequippedItem as EquipableObjects;
					}
					playerController.currentHitObject.gameObject.GetComponent<InteractableObjectController>().InteractOnObject(currentItem);
				}
				else if (playerController.currentHitObject.tag == "Clue" && !playerController.currentHitObject.GetComponent<ClueObjectController>().isInteracted)
				{
					questUIController.DiscoveredQuest(playerController.currentHitObject.GetComponent<ClueObjectController>().clue, playerController.currentHitObject);
				}
			}
		}

		public void ReloadInput(bool newReloadState)
		{

        }

		public void InventoryInput(bool newInventoryState)
		{
			if(playerController.inventoryReady)
            {
				playerController.ToggleInventory();
			}
		}

		public void TurnAroundInput(bool newTurnAroundState)
        {

        }

		public void SaveInput(bool newSaveState)
		{

		}

		public void LoadInput(bool newLoadState)
        {
			PlayerData data = MainSaveSystem.LoadPlayer(1);

			playerController.gameObject.GetComponent<CharacterController>().enabled = false;
			Vector3 position;
			position.x = data.position[0];
			position.y = data.position[1];
			position.z = data.position[2];
			playerController.gameObject.transform.position = position;
			playerController.gameObject.GetComponent<CharacterController>().enabled = true;

			EnemyData enemyData = MainSaveSystem.LoadEnemies(1);
			for(int i=0; i<enemies.Count; i++)
            {
                enemies[i].isDead = enemyData.enemyStatus[i];
            }
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		public void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}