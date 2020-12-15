using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 1f;
    public void PlayGame()
    {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void OuitGame()
    {
        Application.Quit();
        Debug.Log("quitting game");
    }

    public void Start()
    {
        FindObjectOfType<AudioManager>().Play("StartGame");
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

}
