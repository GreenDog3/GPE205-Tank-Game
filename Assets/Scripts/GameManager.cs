using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerOneControllerPrefab;
    public GameObject tankPawnPrefab;
    public Transform playerSpawnLocation;

    public List<PlayerController> players;
    
    private void Awake()
    {
        if (instance == null) //if no gamemanager
        {
            instance = this;//make this the game manager
            DontDestroyOnLoad(gameObject);
        }
        else //if YES gamemanager
        {
            Destroy(gameObject); //long live the gamemanager *throws the extra off a cliff*
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnPlayer();
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
}
