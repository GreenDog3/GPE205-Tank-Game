using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Pawn pawn;
    public int lives;
    public int score;

    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void MakeDecisions()
    {

    }

    public virtual void AddToScore(int points)
    {

    }
}
