using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Player Prefabs")]
    public GameObject playerOneControllerPrefab;
    public GameObject tankPawnPrefab;
    [Header("AI Prefabs")]
    public GameObject noobControllerPrefab;
    public GameObject noobTankPawnPrefab;

    public GameObject leeroyControllerPrefab;
    public GameObject leeroyTankPawnPrefab;

    public GameObject guardControllerPrefab;
    public GameObject guardTankPawnPrefab;

    public GameObject sniperControllerPrefab;
    public GameObject sniperTankPawnPrefab;

    [Header("Waypoints")]
    public List<Transform> arenaWaypoints;
    public GameObject mapGeneratorPrefab;
    public AudioSource source;

    [Header("Lists")]
    public List<PlayerController> players;
    public List<AIController> enemies;
    [Header("UI Prefabs")]
    public GameObject titleScreenStateObject;
    public GameObject mainMenuStateObject;
    public GameObject optionsStateObject;
    public GameObject creditsStateObject;
    public GameObject gameplayStateObject;
    public GameObject gameOverStateObject;
    public int typeOfMap;
    public int mapSeed;
    public TextMeshProUGUI playerOneScore;
    public TextMeshProUGUI playerOneLives;
    public TextMeshProUGUI gameOverText;

    private void Awake()
    {
        if (instance == null) //if no gamemanager
        {
            instance = this;//make this the game manager
            DontDestroyOnLoad(gameObject);
        }
        else //if YES gamemanager
        {
            Destroy(gameObject); //long live the gamemanager *throws the extra off a cliff like Mufasa*
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        DeactivateAllStates();
        ActivateTitleScreen();
    }

    void Update()
    {   //debug commands
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnPlayer();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            SpawnNoob();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SpawnLeeroy();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnGuard();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnSniper();
        }
    }

    public void SpawnMap()
    {
        
        GameObject newMapGenerator = Instantiate(mapGeneratorPrefab, Vector3.zero, Quaternion.identity);
    }
    public void SpawnPlayer()
    {
        PlayerSpawn[] playerSpawns = FindObjectsOfType<PlayerSpawn>();
        int randomIndex = Random.Range(0, playerSpawns.Length);

        GameObject newPlayerObj = Instantiate(playerOneControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn player controllee
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawns[randomIndex].transform.position, playerSpawns[randomIndex].transform.rotation) as GameObject;

        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newController.pawn = newPawn;
        newPawn.controller = newController;

    }

    public void RespawnPlayer(Controller oldController)
    {
        PlayerSpawn[] playerSpawns = FindObjectsOfType<PlayerSpawn>();
        int randomIndex = Random.Range(0, playerSpawns.Length);

        //Spawn player controllee
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawns[randomIndex].transform.position, playerSpawns[randomIndex].transform.rotation) as GameObject;
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        oldController.pawn = newPawn;
        newPawn.controller = oldController;
    }

    public void SpawnNoob()
    {
        EnemySpawner[] enemySpawns = FindObjectsOfType<EnemySpawner>();
        int randomIndex = Random.Range(0, enemySpawns.Length);
        //Spawn noob controller
        GameObject newNoobObj = Instantiate(noobControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        //Spawn noob tank
        GameObject newPawnObj = Instantiate(noobTankPawnPrefab, enemySpawns[randomIndex].transform.position, enemySpawns[randomIndex].transform.rotation);
        //Get noob controller and pawn component
        Controller newController = newNoobObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //And now we'll mix until stiff peaks form
        newController.pawn = newPawn;
        newPawn.controller = newController;
    }

    public void SpawnLeeroy()
    {
        EnemySpawner[] enemySpawns = FindObjectsOfType<EnemySpawner>();
        int randomIndex = Random.Range(0, enemySpawns.Length);
        //Spawn LEEROOOOOOOOOOOOOOOOY controller
        GameObject newLeeroyObj = Instantiate(leeroyControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        //Spawn LEEROOOOOOOOOOOOY tank
        GameObject newPawnObj = Instantiate(leeroyTankPawnPrefab, enemySpawns[randomIndex].transform.position, enemySpawns[randomIndex].transform.rotation);
        //Get LEEROOOOOOOOOOOOOOOOOOOOOOOOOOOOY controller and pawn component
        Controller newController = newLeeroyObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //JENKINNNNNNNNNNNNNNNNNNNS!!!!!! 
        newController.pawn = newPawn;
        newPawn.controller = newController;
        //oh my god he just ran in
    }

    public void SpawnGuard()
    {
        EnemySpawner[] enemySpawns = FindObjectsOfType<EnemySpawner>();
        int randomIndex = Random.Range(0, enemySpawns.Length);
        //Spawn guard controller
        GameObject newGuardObj = Instantiate(guardControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        //Spawn guard tank
        GameObject newPawnObj = Instantiate(guardTankPawnPrefab, enemySpawns[randomIndex].transform.position, enemySpawns[randomIndex].transform.rotation);
        //Get guard controller and pawn component
        Controller newController = newGuardObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //hook them together and give it its waypoints
        newController.pawn = newPawn;
        newPawn.controller = newController;
        newGuardObj.GetComponent<AIController_Guard>().waypoints = arenaWaypoints;
    }

    public void SpawnSniper()
    {
        EnemySpawner[] enemySpawns = FindObjectsOfType<EnemySpawner>();
        int randomIndex = Random.Range(0, enemySpawns.Length);
        //Spawn sniper controller
        GameObject newSniperObj = Instantiate(sniperControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        //Spawn sniper tank
        GameObject newPawnObj = Instantiate(sniperTankPawnPrefab, enemySpawns[randomIndex].transform.position, enemySpawns[randomIndex].transform.rotation);
        //Get sniper controller and pawn component
        Controller newController = newSniperObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //it's getting late, but pretend i made a joke about sniper tf2
        newController.pawn = newPawn;
        newPawn.controller = newController; 
    }

    private void DeactivateAllStates()
    {
        //turns off all the states
        titleScreenStateObject.SetActive(false);
        mainMenuStateObject.SetActive(false);
        optionsStateObject.SetActive(false);
        creditsStateObject.SetActive(false);
        gameplayStateObject.SetActive(false);
        gameOverStateObject.SetActive(false);
    }
    
    public void ActivateTitleScreen()
    {
        DeactivateAllStates();
        //Activate the Title Screen!
        titleScreenStateObject.SetActive(true);
    }

    public void ActivateMainMenuScreen()
    {
        DeactivateAllStates();
        //Activate the Main Menu!
        mainMenuStateObject.SetActive(true);
    }

    public void ActivateOptionsScreen()
    {
        DeactivateAllStates();
        //Activate the Options menu!
        optionsStateObject.SetActive(true);
    }

    public void ActivateCreditsScreen()
    {
        DeactivateAllStates();
        //Activate the credits screen so i can point at it if i show the game to a friend!
        creditsStateObject.SetActive(true);
    }

    public void ActivateGameplayScreen()
    {
        //Deactivate other states
        DeactivateAllStates();
        //Reset level
        Room[] existingMap = FindObjectsOfType<Room>();
        MapGenerator[] existingGenerator = FindObjectsOfType<MapGenerator>();
        for (int i = 0; i < existingMap.Length;)
        {
            Destroy(existingMap[i]);
        }
        for (int i = 0; i < existingMap.Length;)
        {
            Destroy(existingGenerator[i]);
        }
        //Generate map
        SpawnMap();
        //clear the controller lists
        players.Clear();
        enemies.Clear();
        //Spawn player and enemies
        SpawnPlayer();
        SpawnNoob();
        SpawnGuard();
        SpawnLeeroy();
        SpawnSniper();
        //Activate the Gameplay screen!
        gameplayStateObject.SetActive(true);
        //Start game
        
        
    }

    public void ActivateGameOverScreen(bool victory)
    {
        DeactivateAllStates();
        //Either point and laugh at the player for losing or congratulate them on winning! We'll figure that out later!!
        gameOverStateObject.SetActive(true);
        if (victory == true)
        {
            gameOverText.text = "You win!";
        }
        else
        {
            gameOverText.text = "You lose...";
        }
    }

    public void DisplayScore(int score)
    {
        playerOneScore.text = "Score: " + score;
    }
    public void DisplayLives(int lives)
    {
        playerOneLives.text = "Lives: " + lives;
    }

    public void TryGameOver()
    {
        bool isGameOver = true;
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].lives > 0)
            {   //If player has lives, the game is not over
                isGameOver = false;
            }
        }

        if (isGameOver == true)
        {
            ActivateGameOverScreen(false);
        }

        if (enemies.Count == 0)
        {
            isGameOver = true;
        }

        if (isGameOver == true)
        {
            ActivateGameOverScreen(true);
        }
    }
}
