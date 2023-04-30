using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] gridPrefabs;
    public int rows;
    public int cols;
    public int mapSeed;
    public float roomWidth = 50.0f;
    public float roomHeight = 50.0f;
    private Room[,] grid;
    public enum MapType { Random, MapOfTheDay, Seed };
    public MapType type;

    public GameObject RandomRoomPrefab()
    {
        return gridPrefabs[Random.Range(0, gridPrefabs.Length)];
    }
    public void GenerateMap()
    {
        //Seed the rng based on the type chosen
        if (type == MapType.Random)
        {
            //Seed randomly based on the universal variable. Time
            System.DateTime time;
            time = System.DateTime.Now;
            Random.InitState((int)time.Ticks);
        }
        else if (type == MapType.Seed)
        {
            //Seed based on a chosen number.
            Random.InitState(mapSeed);

        }
        else
        {
            //Seed based on today's date
            Random.InitState((int)System.DateTime.Today.Ticks);
        }
        grid = new Room[cols, rows];
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                //Find the locations we need to spawn rooms
                float xPosition = roomWidth * currentCol;
                float zPosition = roomHeight * currentRow;
                Vector3 newPosition = new Vector3 (xPosition, 0.0f, zPosition);
                //Spawn the rooms in the locations
                GameObject tempRoomObj = Instantiate (RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;
                //Set its parent
                tempRoomObj.transform.parent = this.transform;
                //Give it a name like a build-a-bear
                //man i was obsessed with build-a-bear as a kid. idk why
                //I had a stuffed dog named Ritz and i took him everywhere.
                //I left him back in Iowa though.
                //I'd have brought him here but I'm not about to lose him to the desert
                //Back to gaming
                Room tempRoom = tempRoomObj.GetComponent<Room>();
                //put it in the array
                //is it weird that i want to eat the concept of arrays right now
                //it's 3 am and i am extremely hungry so don't answer that
                //it would taste like seafood though
                grid[currentCol, currentRow] = tempRoom;

                //open the doors
                //except i made them the walls because i think it looks more connected when it's open
                if (currentRow == 0)
                {   //Row 0 is the bottom, so if we're there open the north door
                    tempRoom.doorNorth.SetActive(false);
                }
                else if (currentRow == rows - 1)
                {
                    //If we're at the top, open the south door
                    tempRoom.doorSouth.SetActive(false);
                }
                else
                {
                    //If we're neither, then open both
                    tempRoom.doorNorth.SetActive(false);
                    tempRoom.doorSouth.SetActive(false);
                }

                
                if (currentCol == 0)
                {   //If we're on the left, open to the right
                    tempRoom.doorEast.SetActive(false);
                }
                else if (currentCol == cols - 1)
                {
                    //If we're on the right, open to the left
                    tempRoom.doorWest.SetActive(false);
                }
                else
                {
                    //CRIS CROSS!
                    //CRIS CROSS!
                    //EVERYBODY CLAP YOUR HANDS!
                    tempRoom.doorEast.SetActive(false);
                    tempRoom.doorWest.SetActive(false);
                }
            }
        }
    }

    void Awake()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
