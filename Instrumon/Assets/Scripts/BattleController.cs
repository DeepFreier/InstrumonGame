using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BattleController : MonoBehaviour
{
    public SpriteRenderer playerSpriteHolder;
    public TextMeshProUGUI playerNameText;
    public Image playerHealthBar;
    private float playerCurrentHealth;
    private float playerTotalHealth;
    public TextMeshProUGUI playerCurrentHealthText;
    public TextMeshProUGUI playerTotalHealthText;

    private System.Random random = new System.Random();

    public SpriteRenderer oppSpriteHolder;
    public TextMeshProUGUI oppNameText;
    public Image oppHealthBar;
    private float oppCurrentHealth;
    private float oppTotalHealth;
    public TextMeshProUGUI oppCurrentHealthText;
    public TextMeshProUGUI oppTotalHealthText;

    public static Instrumon[] playerParty;
    public Instrumon playerCurrentMon = playerParty[0];
    public Sprite playerSprite;
    private String playerName = "Trumpig";
    private int playerCurrentHP = 80;
    private int playerMonHP = 90;
    private int playerMonAtk = 70;
    private int PlayerMonSpd = 5;
    //public Attack playerSelectedAtk;

    public static Instrumon[] oppParty;
    public Instrumon oppCurrentMon = oppParty[0];
    public int oppCurrentIndex = 0;
    public Sprite oppSprite;
    private String oppName = "Cymbalisk";
    private int oppMonHP = 120;
    private int oppMonAtk = 50;
    private int OpponentMonSpd = 4;


    // Start is called before the first frame update
    void Start()
    {
        playerSpriteHolder.sprite = playerSprite;
        playerNameText.text = playerName.ToString();
        playerCurrentHealth = playerCurrentHP;
        playerTotalHealth = playerMonHP;
        takeDamage(0);
        playerTotalHealthText.text = playerMonHP.ToString();

        oppSpriteHolder.sprite = oppSprite;
        oppNameText.text = oppName.ToString();
        oppCurrentHealth = oppMonHP;
        oppTotalHealth = oppMonHP;
        dealDamage(0);
        oppTotalHealthText.text = oppMonHP.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Return))
        {
            takeDamage(calcDamage(playerMonHP, 50, 30));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healDamage(5);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            healOppDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            dealDamage(10);
        }
        */
    }
    /* This will be fully implemented after adjustments to the Instrumon class
    public void oppTurn()
    {
        int randVal = oppCurrentMon.moves.Length;
        Move selMove = oppCurrentMon.moves[random.Next(0, randVal)];
        float dmgVal = calcDamage(oppCurrentMon.MaxHP, oppCurrentMon.Attack, selMove.Power);
        takeDamage(dmgVal);
    }
    */
    public void winBattle()
    {

    }

    public void playerSwitch()
    {

    }
    
    public void playerDeathSwitch()
    {

    }

    public void oppSwitch()
    {
        oppCurrentIndex += 1;
        if (oppCurrentIndex > oppParty.Length - 1)
        {
            winBattle();
        }
        else
        {
            oppCurrentMon = oppParty[oppCurrentIndex];
        }
    }
    
    public void executeTurn()
    {
        if (playerFirst())
        {
            //player deals damage based on move picked
            if (oppCurrentHealth > 0)
            {
                //execute oppTurn()
            }
            else
            {
                oppSwitch();
            }

        }
        else
        {
            //execute oppTurn()
            if (playerCurrentHealth > 0)
            {
                //player deals damage
            }
            else
            {
                playerDeathSwitch();
            }
        }
    }

    public bool playerFirst()
    {
        if (playerCurrentMon.Speed >= oppCurrentMon.Speed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int calcDamage(int totalHP, int atkStat, int atkPow)
    {
        return (int)Math.Ceiling((decimal)(Math.Abs(atkStat + atkPow - totalHP / 2)));
    }

    public void takeDamage(float damage)
    {
        playerCurrentHealth -= damage;
        if (playerCurrentHealth < 0) 
        {
            playerCurrentHealth = 0;
        }
        playerHealthBar.fillAmount = playerCurrentHealth / playerTotalHealth;
        playerCurrentHealthText.text = playerCurrentHealth.ToString();
    }

    public void dealDamage(float damage)
    {
        oppCurrentHealth -= damage;
        if (oppCurrentHealth < 0)
        {
            oppCurrentHealth = 0;
        }
        oppHealthBar.fillAmount = oppCurrentHealth / oppTotalHealth;
        oppCurrentHealthText.text = oppCurrentHealth.ToString();
    }

    public void healDamage(float heal)
    {
        playerCurrentHealth += heal;
        if (playerCurrentHealth > playerTotalHealth)
        {
            playerCurrentHealth = playerTotalHealth;
        }
        playerHealthBar.fillAmount = playerCurrentHealth / playerTotalHealth;
        playerCurrentHealthText.text = playerCurrentHealth.ToString();
    }

    public void healOppDamage(float heal)
    {
        oppCurrentHealth += heal;
        if (oppCurrentHealth > oppTotalHealth)
        {
            oppCurrentHealth = oppTotalHealth;
        }
        oppHealthBar.fillAmount = oppCurrentHealth / oppTotalHealth;
        oppCurrentHealthText.text = oppCurrentHealth.ToString();
    }
    public void OnAttackButton()
    {

    }

    public void OnAttackSelected()
    {
        
    }

    public void OnMonButton()
    {

    }

    public void OnStatButton()
    {

    }

}
