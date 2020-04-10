using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MainMenuCamera : MonoBehaviour
{
    public GameObject gameStartedPosition, charcterSelectPosition;
    public Button Start_Button,Create_Button;
    public EventSystem eventsystem;
    public GameObject StartButton,CreateButton;
    public bool reached_GameStartedPosition=false;
    private bool reached_CharacterSelectPosition = true;
    public bool BackToMainMenu;
  
    private void Awake()
    {
        //eventsystem.firstSelectedGameObject = StartButton;
        Start_Button = StartButton.GetComponent<Button>();
        Create_Button = CreateButton.GetComponent<Button>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
        MoveToStartPosition();
        MoveToCharatcerSelectMenu();
        MoveBackToMainMenu();
        if(reached_GameStartedPosition)
        {
            Start_Button.interactable = true;
        }
        if(reached_CharacterSelectPosition)
        {
            Create_Button.interactable = true;
        }
        
    }
    void MoveToStartPosition()
    {
        if(!reached_GameStartedPosition)
        {
            if(Vector3.Distance(transform.position,gameStartedPosition.transform.position)<0.2f) // dist b/w current camera and distance to go if less than 0.2 we can click 
            {
                reached_GameStartedPosition = true;
                eventsystem.SetSelectedGameObject(StartButton);
                //Start_Button.interactable = true;
            }
        }
        if(!reached_GameStartedPosition) // Not reached 
        {
            transform.position = Vector3.Lerp(transform.position, gameStartedPosition.transform.position,1f*Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, gameStartedPosition.transform.rotation, 1f * Time.deltaTime);  // 
        }
    }

    void MoveToCharatcerSelectMenu()
    {
        if(!reached_CharacterSelectPosition)
        {
            transform.position = Vector3.Lerp(transform.position, charcterSelectPosition.transform.position, 1f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation,
                charcterSelectPosition.transform.rotation, 1f * Time.deltaTime);

        }
        if(!reached_CharacterSelectPosition)
        {
            if(Vector3.Distance(transform.position,charcterSelectPosition.transform.position) <0.2f)
            {
                reached_CharacterSelectPosition = true;
                //Start_Button.interactable=ture;
                eventsystem.SetSelectedGameObject(CreateButton);
            }
        }
    }
    void MoveBackToMainMenu()
    {
        if(BackToMainMenu)
        {
            if(Vector3.Distance(transform.position,gameStartedPosition.transform.position)<0.2f)
            {
                reached_GameStartedPosition = true;
                eventsystem.SetSelectedGameObject(StartButton);
                BackToMainMEnu = false;
            }
        }
        if(BackToMainMenu)
        {
            transform.position = Vector3.Lerp(transform.position, gameStartedPosition.transform.position, 1f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, gameStartedPosition.transform.rotation, 1f * Time.deltaTime);
            eventsystem.SetSelectedGameObject(StartButton); 
        }
    }
    public bool ReachedCharacterSelectPosition
    {
        get
        {
            return reached_CharacterSelectPosition;
        }
        set
        {
            reached_CharacterSelectPosition = value;
        }
    }

    public bool BackToMainMEnu
    {
        get
        {
            return BackToMainMenu;
        }
        set
        {
            BackToMainMenu = value;
        }
    }
   
}//class
