using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTakeContainerScript : MonoBehaviour
{
    MainCharacterScript mainCharacter;

    public void take()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("Character").GetComponent<MainCharacterScript>();
        mainCharacter.isTaking = true;
    }
}
