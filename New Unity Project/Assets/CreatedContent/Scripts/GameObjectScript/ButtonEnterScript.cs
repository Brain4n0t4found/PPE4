using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnterScript : MonoBehaviour
{
    MainCharacterScript mainCharacter;

    public void enter()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("Character").GetComponent<MainCharacterScript>();
        mainCharacter.IsMoving = true;
    }
}
