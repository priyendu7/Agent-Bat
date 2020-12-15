using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool gameHasEnded = false;
    public GameObject pauseMenuUI;
    public Scorer scorer;
    public CameraMovement cameraMovement;
    public Canvas can;
    public GameController gameController;
    public CharaterHealth charaterHealth;
    public Movement movement;
   
 

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void PauseGame()
    {
        gameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        cameraMovement.CameraSpeedReset();
        can.GetComponent<Canvas>().enabled = true;
        PlayerPrefs.SetFloat("PreviousScore", 0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }
    public void WatchAd()
    {
        gameController.WatchAd();
    }
    public void ResumeAfterReward()
    {
        PlayerPrefs.SetFloat("PreviousScore",scorer.score);
        PlayerPrefs.SetFloat("SpeedModifier", movement._speedModifier);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  
    
}
