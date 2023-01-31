using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void loadMapSelection()
    {
        SceneManager.LoadScene("MapSelection"); //Loads the map selection scene
    }
    public void loadMountain()
    {
        SceneManager.LoadScene("MountainScene"); //Loads the Mountain scene
    }
    public void loadDesert()
    {
        SceneManager.LoadScene("DesertScene"); //Loads the Desert scene
    }
    public void loadGraveyard()
    {
        SceneManager.LoadScene("GraveyardScene"); //Loads the Graveyard scene
    }
    public void loadSnow()
    {
        SceneManager.LoadScene("SnowScene"); //Loads the Snow scene
    }
    public void quitMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); //Loads the MainMenu
    }
    public void loadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Loads the current level for when the player dies and restarts
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
