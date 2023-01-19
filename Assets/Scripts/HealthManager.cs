using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public int maxHealth; //NoOFhearts

    public Image[] hearts;

    public Sprite fullHeart;

    public Sprite emptyHeart;

    private int i=0;

    public int currentHealth;

    public float invisibilityLength;

    private float invisibilityCounter;

    public Renderer playerRender;

    public PlayerController thePlayer;

    public float flashlength=0.1f;

    private float flashCounter;

    private bool isrespawning;

    private Vector3 respawnPoint;

    public float respawnLength;

    public GameObject mainSound;

    public GameObject gameOverSound;

    public GameObject gameOvermenu;

    public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth=maxHealth;
        //thePlayer=FindObjectOfType<PlayerController>();
        respawnPoint=thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(invisibilityCounter>0)
        {
            invisibilityCounter-=Time.deltaTime;
            flashCounter-=Time.deltaTime;
            if(flashCounter<=0)
            {
                playerRender.enabled=!playerRender.enabled;
                flashCounter=flashlength;
            }
        }
        if(invisibilityCounter<=0)
        {
            playerRender.enabled=true;
        }
        
    }
    public void hurtPlayer(int damage,Vector3 direction)
    {
        if(invisibilityCounter<=0)
        {

            currentHealth-=damage;
            
            hearts[i].sprite=emptyHeart;
            i++;

            if(currentHealth<=0 )
            {
                
                mainSound.gameObject.SetActive(false);
                thePlayer.gameObject.SetActive(false);
                Instantiate(deathEffect,thePlayer.transform.position,thePlayer.transform.rotation); 
                gameOverSound.gameObject.SetActive(true);
                Invoke("wait",2);

            }else
            {
                thePlayer.knockBack(direction);
                invisibilityCounter=invisibilityLength;

                playerRender.enabled=false;

                flashCounter=flashlength;
            }
        }
    }

    /*public void respawn()
    {
        //thePlayer.transform.position=respawnPoint;
        //currentHealth=maxHealth;
        if(!isrespawning)
        {
            StartCoroutine("respawnCo");
        }
    }
    public IEnumerator respawnCo()
    {

        isrespawning=true;
        thePlayer.gameObject.SetActive(false);
        Instantiate(deathEffect,thePlayer.transform.position,thePlayer.transform.rotation);
        yield return new WaitForSeconds(respawnLength);
        isrespawning=false;
        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.position=respawnPoint;
        currentHealth=maxHealth;
        invisibilityCounter=invisibilityLength;
        playerRender.enabled=false;
        flashCounter=flashlength;
        for(int i=0;i<5;i++)
            hearts[i].sprite=fullHeart;
        i=0;
    }*/
    public void healPlayer(int healAmount)
    {
        currentHealth+=healAmount;
        if (currentHealth>maxHealth)
        {
            currentHealth=maxHealth;
        }
    }
    public void wait()
    {
        gameOvermenu.gameObject.SetActive(true);

    }
}
