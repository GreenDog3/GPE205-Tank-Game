using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    [Header("Controls")]
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        GameManager.instance.players.Add(this); //adds itself to the player list
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        ProcessInputs();
        GameManager.instance.DisplayScore(score);
        GameManager.instance.DisplayLives(lives);
    }

    public void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }
        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }
        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }
        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
        if (Input.GetKey(shootKey))
        {
            pawn.Shoot();
        }
    }

    public override void AddToScore(int points)
    {
        score += points;
    }

    public void OnDestroy()
    {
        GameManager.instance.players.Remove(this);
    }
}
