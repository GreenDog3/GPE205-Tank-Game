using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerOneControllerPrefab;
    public GameObject tankPawnPrefab;
    public GameObject noobControllerPrefab;
    public GameObject noobTankPawnPrefab;
    public GameObject leeroyControllerPrefab;
    public GameObject leeroyTankPawnPrefab;
    public GameObject guardControllerPrefab;
    public GameObject guardTankPawnPrefab;
    public GameObject sniperControllerPrefab;
    public GameObject sniperTankPawnPrefab;


    public Transform playerSpawnLocation;
    public Transform enemySpawnLocation;
    public List<Transform> arenaWaypoints;

    public List<PlayerController> players;
    public List<AIController> enemies;
    
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
        SpawnPlayer();
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

    public void SpawnPlayer()
    {
        //Spawn player controller
        GameObject newPlayerObj = Instantiate(playerOneControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn player controllee
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnLocation.position, playerSpawnLocation.rotation) as GameObject;

        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newController.pawn = newPawn;

    }

    public void SpawnNoob()
    {
        //Spawn noob controller
        GameObject newNoobObj = Instantiate(noobControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        //Spawn noob tank
        GameObject newPawnObj = Instantiate(noobTankPawnPrefab, enemySpawnLocation.position, enemySpawnLocation.rotation);
        //Get noob controller and pawn component
        Controller newController = newNoobObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //And now we'll mix until stiff peaks form
        newController.pawn = newPawn;
    }

    public void SpawnLeeroy()
    {
        //Spawn LEEROOOOOOOOOOOOOOOOY controller
        GameObject newLeeroyObj = Instantiate(leeroyControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        //Spawn LEEROOOOOOOOOOOOY tank
        GameObject newPawnObj = Instantiate(leeroyTankPawnPrefab, enemySpawnLocation.position, enemySpawnLocation.rotation);
        //Get LEEROOOOOOOOOOOOOOOOOOOOOOOOOOOOY controller and pawn component
        Controller newController = newLeeroyObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //JENKINNNNNNNNNNNNNNNNNNNS!!!!!! 
        newController.pawn = newPawn;
        //oh my god he just ran in
    }

    public void SpawnGuard()
    {
        //Spawn guard controller
        GameObject newGuardObj = Instantiate(guardControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        //Spawn guard tank
        GameObject newPawnObj = Instantiate(guardTankPawnPrefab, enemySpawnLocation.position, enemySpawnLocation.rotation);
        //Get guard controller and pawn component
        Controller newController = newGuardObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //hook them together and give it its waypoints
        newController.pawn = newPawn;
        newGuardObj.GetComponent<AIController_Guard>().waypoints = arenaWaypoints;
    }

    public void SpawnSniper()
    {
        //Spawn sniper controller
        GameObject newSniperObj = Instantiate(sniperControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        //Spawn sniper tank
        GameObject newPawnObj = Instantiate(sniperTankPawnPrefab, enemySpawnLocation.position, enemySpawnLocation.rotation);
        //Get sniper controller and pawn component
        Controller newController = newSniperObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //it's getting late, but pretend i made a joke about sniper tf2
        newController.pawn = newPawn;
    }
}
