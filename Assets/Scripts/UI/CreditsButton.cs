using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    public void OpenCreditsMenu()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateCreditsScreen();
        }
    }
}
