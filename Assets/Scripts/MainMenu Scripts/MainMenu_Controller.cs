using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu_Controller : MonoBehaviour
{
    [HideInInspector]
    public GameObject buttonPanel, CharacterSelectPanel,CreateCharacterPanel,start_button,main_menu,createbutton,cancelButton,AcceptButton,optionPanel,optionPanel_Button,close_button,LowButton;
    private Image Start_Button;
    private MainMenuCamera mainMenuCamera;
    public EventSystem eventsystem;

    private void Awake()
    {
        mainMenuCamera = Camera.main.GetComponent<MainMenuCamera>();
        Start_Button = start_button.GetComponent<Image>();
        
    }

    public void PlayGame()
    {
        if (mainMenuCamera.reached_GameStartedPosition)
        {
            buttonPanel.SetActive(false);
            start_button.transform.localScale = new Vector3(0.758013f, 0.9398496f, 1);
            Start_Button.color = new Color(255, 255, 255, 255);
            CharacterSelectPanel.SetActive(true);
            mainMenuCamera.ReachedCharacterSelectPosition = false;
            mainMenuCamera.Start_Button.interactable = false;
            mainMenuCamera.reached_GameStartedPosition = false;
        }   
       
    }
    public void BackToMainMenu()
    {
        mainMenuCamera.BackToMainMenu = true;
        buttonPanel.SetActive(true);
        CharacterSelectPanel.SetActive(false);
        main_menu.transform.localScale = new Vector3(0.9114692f, 1f, 1f);
        main_menu.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }

    public void StartGame()
    {
       SceneLoader.instance.LoadScreen("Village");
    }
    public void CreateCharacter()
    {
        eventsystem.SetSelectedGameObject(cancelButton);
        CharacterSelectPanel.SetActive(false);
        CreateCharacterPanel.SetActive(true);
        createbutton.transform.localScale = new Vector3(0.9114692f, 1f, 1f);
        createbutton.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }
    public void Cancel()
    {
        eventsystem.SetSelectedGameObject(mainMenuCamera.CreateButton);
        CharacterSelectPanel.SetActive(true);
        CreateCharacterPanel.SetActive(false);
        cancelButton.transform.localScale = new Vector3(0.9114692f, 1f, 1f);
        cancelButton.GetComponent<Image>().color = new Color(255, 255, 255, 255);

    }
    public void Accept()
    {
        eventsystem.SetSelectedGameObject(mainMenuCamera.CreateButton);
        CharacterSelectPanel.SetActive(true);
        CreateCharacterPanel.SetActive(false);
        AcceptButton.transform.localScale = new Vector3(0.9114692f, 1f, 1f);
        AcceptButton.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }
    public void OpenOptionPanel()
    {
        optionPanel.SetActive(true);
        buttonPanel.SetActive(false);
        eventsystem.SetSelectedGameObject(LowButton);
        optionPanel_Button.transform.localScale = new Vector3(0.758013f, 0.9398496f, 1);
        optionPanel_Button.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }
    public void CloseOptionPanel()
    {
        eventsystem.SetSelectedGameObject(mainMenuCamera.StartButton);
        optionPanel.SetActive(false);
        buttonPanel.SetActive(true);
        close_button.transform.localScale = new Vector3(0.3828393f, 1.256336f, 1.386693f);
        close_button.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }
    public void SetQuality()
    {
        ChangeQualityLevel();
    }
    public void SetResolution()
    {
        ChangeResolution();
    }
    void ChangeQualityLevel()
    {
        string level = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        switch (level)
        {
            case "Low":
                QualitySettings.SetQualityLevel(0);
                break;
            case "Normal":
                QualitySettings.SetQualityLevel(1);
                break;
            case "High":
                QualitySettings.SetQualityLevel(2);
                break;
            case "Ultra":
                QualitySettings.SetQualityLevel(3);
                break;
            case "No Shadow":
                if (QualitySettings.shadows == ShadowQuality.All)
                    QualitySettings.shadows = ShadowQuality.Disable;
                else
                    QualitySettings.shadows = ShadowQuality.All;
                break;
        }
    }
    void ChangeResolution()
    {
        string index = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        switch(index)
        {
            case "1":
                Screen.SetResolution(1152, 648, true);
                break;
            case "2":
                Screen.SetResolution(1280, 720, true);
                break;
            case "3":
                Screen.SetResolution(1360, 768, true);
                break;
            case "4":
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }


}//class
