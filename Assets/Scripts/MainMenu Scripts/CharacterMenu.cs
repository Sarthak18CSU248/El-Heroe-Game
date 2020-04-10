using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject charPosition;

    private int Knight_Warrior_Index = 0;
    private int King_Warrior_Index = 1;
    private int CatGirl_Warrior_Index = 2;

    // Start is called before the first frame update
    void Start()
    {
        characters[Knight_Warrior_Index].SetActive(true);
        characters[Knight_Warrior_Index].transform.position= charPosition.transform.position;
    }


    public void SelectCharacter()
    {
        int index =int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name); // convert string into int 
        turn_OFF_CharFuncton();  // reset to turn off previous character
        characters[index].SetActive(true);
        characters[index].transform.position = charPosition.transform.position;
    }


    void turn_OFF_CharFuncton()
    {
        for(int i=0;i<characters.Length;i++)
        {
            characters[i].SetActive(false);
        }
    }

} //class
