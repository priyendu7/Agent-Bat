using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaterHealth : MonoBehaviour
{
    public float maxhealth = 20;
    public float currentHealth;
    public float _healthDecreseFator = 0.05f;
    public bool enter = true;
    //public GameObject healthBar;
    public HealthBar healthBar;
    public GameObject endMenuUI;
    public CameraShake cameraShake;
    public static bool isAlive =true;
    public Canvas can;
    public Scorer scorer;
    public Text highScoreText;
    public Text coinCountText;
    private bool damaging = false;
    private bool damageSoundPlaying = false;
    public GameController gameController;
    public int coin;
    public Button coinReviveButton;
    //public HealthPowerUp healthPowerUp;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
        healthBar.SetMaxHeath(maxhealth);
        isAlive = true;
        FindObjectOfType<AudioManager>().Play("Game");
        FindObjectOfType<AudioManager>().Stop("EndGame");
        coin = PlayerPrefs.GetInt("CoinCount", 0);
        coinCountText.text = coin.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        //player is dead
        if (isAlive==true && currentHealth <0)
        {
            
           
            if (coin > 1000)
            {
                coinReviveButton.interactable = true;
            }
            else coinReviveButton.interactable = false;
            endMenuUI.SetActive(true);
            isAlive = false;
            can.GetComponent<Canvas>().enabled = false;
            setPlayerStats();
            FindObjectOfType<AudioManager>().Stop("Game");
            FindObjectOfType<AudioManager>().Play("EndGame");
            FindObjectOfType<AudioManager>().Stop("Damage");
            Time.timeScale = 0f;
            gameController.PlayerDead();


        }
        if (damaging ==true && damageSoundPlaying ==false)
        {
            FindObjectOfType<AudioManager>().Play("Damage");
            damageSoundPlaying = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TorchLight"))
        {
            Debug.Log("on stay called");
            currentHealth -= _healthDecreseFator;
            healthBar.SetHealth(currentHealth);
            StartCoroutine(cameraShake.Shake(.05f, .05f));
            damaging = true;

        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
        {
            currentHealth -= 0.5f;
            healthBar.SetHealth(currentHealth);
            StartCoroutine(cameraShake.Shake(.05f, .05f));
        }
        if (collision.CompareTag("HealthBoost"))
        {
            
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            HealthPickedUp();
            FindObjectOfType<AudioManager>().Play("Revive");
            collision.gameObject.GetComponent<Animator>().SetInteger("pick", 1);
            //healthPowerUp.HealthPickUp();
            StartCoroutine(DestroyPowerUp(0.5f,collision.gameObject));
        }
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            coin++;
            FindObjectOfType<AudioManager>().Play("CoinCollect");
            coinCountText.text = coin.ToString();
            CoinPickedUp();
            collision.gameObject.GetComponent<Animator>().enabled = true;
            StartCoroutine(DestroyPowerUp(0.2f, collision.gameObject));

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TorchLight"))
        {
            damaging = false;
            damageSoundPlaying = false;
            FindObjectOfType<AudioManager>().Stop("Damage");
        }
    }
    private void setPlayerStats()
    {
        float highscore = PlayerPrefs.GetFloat("HighScore", 0);
        PlayerPrefs.SetFloat("PreviousScore", 0);
        PlayerPrefs.SetFloat("SpeedModifier",0.1f);
        if(scorer.score > highscore)
        {
            PlayerPrefs.SetFloat("HighScore", scorer.score);
        }
        highscore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = highscore.ToString("0");
        PlayerPrefs.SetInt("CoinCount", coin);
    }

    public void ResumeAfterReward()
    {

        //isAlive = true;
        //currentHealth = maxhealth;
        //FindObjectOfType<AudioManager>().Play("Game");
        //FindObjectOfType<AudioManager>().Stop("EndGame");
        //endMenuUI.SetActive(false);
        //can.GetComponent<Canvas>().enabled = false;

    }

    public void HealthPickedUp()
    {
        currentHealth = maxhealth;
        healthBar.SetHealth(currentHealth);
    }

    public void CoinPickedUp()
    {

    }
    IEnumerator DestroyPowerUp(float time,GameObject g)
    {
        yield return new WaitForSeconds(time);
        Destroy(g);
    }


}
