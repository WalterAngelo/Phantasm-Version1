using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public StarterAssets.StarterAssetsInputs inputsController;
    public PlayerController playerController;
    public Flashlight flashlightController;
    public InventoryUI inventoryUIController;
    public Transform inventoryUITransform;
    public ItemDescriptionController itemDescriptionController;
    public EquipItemsController equipItemsController;
    public InventoryTextsController inventoryTextsController;
    public QuestUIController questUIController;
    public NotebookModelController notebookModelController;
    public InstructionPanelController instructionPanelController;
    public MonologueUIController monologueUIController;
    public LightSwitchController lightSwitchController;
    public InventoryInstructionsController inventoryInstructionsController;
    public FirstEnemySpawnController firstEnemySpawnController;
    public FirstEnemySpawnMonologue firstEnemySpawnMonologue;
    public RaycastNewClues raycastNewClues;

    public GameObject inventoryGUI;
    public GameObject enemyPrefab;

    public int poolCount;
    //public ItemPickupController itemPickupController;

    public List<GameObject> poolOfEnemies = new List<GameObject>();
    public List<GameObject> textOnScreenUI = new List<GameObject>();
    public List<GameObject> pickableObjects = new List<GameObject>();
    public List<GameObject> interactableObjects = new List<GameObject>();
    public List<GameObject> barriers = new List<GameObject>();
    public List<WritingController> writingControllers = new List<WritingController>();
    public List<RaycastMonologue> raycastMonologues = new List<RaycastMonologue>();
    public List<SpawnerController> spawnerControllers = new List<SpawnerController>();

    public List<ClueObjects> clueScriptableObjects = new List<ClueObjects>();
    public List<QuestionObjects> questionScriptableObjects = new List<QuestionObjects>();

    public List<Button> inventoryTextsButtonsList = new List<Button>();

    public Texture2D cursorTexture;
    public int currentFloorNumber = 1;

    private void Awake()
    {
        //add instantiated enemies to the object pool
        for (int i = 0; i < poolCount; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            poolOfEnemies.Add(obj);
        }

        //interactableObjects initialization
        for (int i = 0; i<interactableObjects.Count; i++)
        {
            interactableObjects[i].GetComponent<InteractableObjectController>().isLockedUI = textOnScreenUI[0];
            interactableObjects[i].GetComponent<InteractableObjectController>().wrongItemUI = textOnScreenUI[1];
            interactableObjects[i].GetComponent<InteractableObjectController>().playerController = playerController;
        }

        //playerController
        playerController.inputsController = inputsController;
        playerController.instructionPanelController = instructionPanelController;
        playerController.monologueUIController = monologueUIController;

        //flashlightController initialization
        flashlightController.playerController = playerController;

        //InstructionPanel Controller initialization
        instructionPanelController.playerController = playerController;

        //inventoryTextsController initialization
        inventoryTextsController.equipTextButtonUI = inventoryTextsButtonsList[0];
        inventoryTextsController.backTextButtonUI = inventoryTextsButtonsList[1];

        //inventoryUI initialization
        inventoryGUI.SetActive(true);
        inventoryUIController.inventory = playerController.inventory;
        inventoryUIController.itemDescriptionController = itemDescriptionController;
        inventoryUIController.equipItemsController = equipItemsController;
        inventoryUIController.inventoryTextsController = inventoryTextsController;
        inventoryGUI.SetActive(false);

        //equipItemsController initialization
        equipItemsController.inventoryUIController = inventoryUIController;
        equipItemsController.playerController = playerController;

        //inventorySlot Controller initialization
        for(int i=0; i<inventoryUITransform.childCount; i++)
        {
            inventoryUITransform.GetChild(i).GetComponent<InventorySlotController>().inventoryUIController = inventoryUIController;
        }

        //starter inputs initialization
        inputsController.playerController = playerController;
        inputsController.flashlightController = flashlightController;
        inputsController.inventoryUIController = inventoryUIController;
        inputsController.equipItemsController = equipItemsController;
        inputsController.questUIController = questUIController;
        inputsController.notebookModelController = notebookModelController;

        //questUIController initialization
        questUIController.playerController = playerController;
        questUIController.currentFloorNumber = currentFloorNumber;
        questUIController.clues = clueScriptableObjects;
        questUIController.barriers = barriers;
        questUIController.mainController = gameObject.GetComponent<MainController>();
        questUIController.notebookModelController = notebookModelController;
        questUIController.AddClues();

        //notebook model controller initialization
        notebookModelController.gameObject.SetActive(true);
        notebookModelController.currentFloorNumber = currentFloorNumber;
        notebookModelController.questions = questionScriptableObjects;
        notebookModelController.AddQuestions();
        notebookModelController.gameObject.SetActive(false);

        //writing controller initialization
        foreach(WritingController writing in writingControllers)
        {
            writing.notebookModelController = notebookModelController;
            writing.cursorTexture = cursorTexture;
            writing.questUIController = questUIController;
        }

        //raycast controller initialization
        foreach(RaycastMonologue raycastControl in raycastMonologues)
        {
            raycastControl.playerController = playerController;
            raycastControl.flashlightController = flashlightController;
            raycastControl.questUIController = questUIController;
        }

        //lightswitch controller initialization
        lightSwitchController.playerController = playerController;

        //inventoryInstructions controller initialization
        inventoryInstructionsController.playerController = playerController;

        //spawner controller initialization
        foreach(SpawnerController spawnerController in spawnerControllers)
        {
            spawnerController.poolOfEnemies = poolOfEnemies;
            spawnerController.player = playerController.gameObject;
            spawnerController.ChangeSpawnDelay(currentFloorNumber);
        }

        //firstEnemySpawn monologue initialization
        firstEnemySpawnMonologue.firstEnemySpawnController = firstEnemySpawnController;

        //raycast new clues initialization
        raycastNewClues.mainController = gameObject.GetComponent<MainController>();
        raycastNewClues.questUIController = questUIController;
        raycastNewClues.notebookModelController = notebookModelController;
    }

    public void SaveFile()
    {
        MainSaveSystem.SaveAllSceneData(playerController,
                        pickableObjects,
                        interactableObjects,
                        flashlightController,
                        raycastMonologues,
                        clueScriptableObjects, 
                        1);
    }
}
