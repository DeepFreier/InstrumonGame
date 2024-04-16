using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BattleController : MonoBehaviour
{
    //player visual variables
    public SpriteRenderer playerSpriteHolder;
    public TextMeshProUGUI playerNameText;
    public Image playerHealthBar;
    private float playerCurrentHealth;
    private float playerTotalHealth;
    public TextMeshProUGUI playerCurrentHealthText;
    public TextMeshProUGUI playerTotalHealthText;

    private System.Random random = new System.Random();

    //cpu visual variables
    public SpriteRenderer oppSpriteHolder;
    public TextMeshProUGUI oppNameText;
    public Image oppHealthBar;
    private float oppCurrentHealth;
    private float oppTotalHealth;
    public TextMeshProUGUI oppCurrentHealthText;
    public TextMeshProUGUI oppTotalHealthText;

    //player variables
    public static Instrumon[] playerParty;
    public static Instrumon playerCurrentMon; // = playerParty[0];
    public Sprite playerSprite = playerCurrentMon.Base.FrontSprite;
    private String playerName = "Trumpig";
    private int playerCurrentHP = 80;
    private int playerMonHP = 90;
    private int playerMonAtk = 70;
    private int PlayerMonSpd = 5;
    //public Move playerSelectedAtk;
    
    //cpu variables
    public static Instrumon[] oppParty;
    public static Instrumon oppCurrentMon; // = oppParty[0];
    public int oppCurrentIndex = 0;
    public Sprite oppSprite = oppCurrentMon.Base.FrontSprite;
    private String oppName = "Cymbalisk";
    private int oppMonHP = 120;
    private int oppMonAtk = 50;
    private int OpponentMonSpd = 4;

    //button variables


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

    }

    public void winBattle()
    {

    }

    public void playerSwitch(int monIndex)
    {

    }
    
    public void playerDeathSwitch()
    {
        
    }

    public void oppTurn()
    {
        int randVal = oppCurrentMon.Moves.Count;
        Move selMove = oppCurrentMon.Moves[random.Next(0, randVal)];
        float dmgVal = calcDamage(oppCurrentMon.MaxHP, oppCurrentMon.Attack, selMove.Base.Power);
        takeDamage(dmgVal);
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
    
    
    public void executeTurn(int attackIndex)
    {
        if (playerFirst())
        {
            //float dmgVal = calcDamage(oppCurrentMon.MaxHP, playerCurrentMon.Attack, playerCurrentMon.Moves[attackIndex];
            //dealDamage(dmgVal);

            if (oppCurrentHealth > 0)
            {
                oppTurn();
            }
            else
            {
                oppSwitch();
            }

        }
        else
        {
            oppTurn();

            if (playerCurrentHealth > 0)
            {
                //float dmgVal = calcDamage(oppCurrentMon.MaxHP, playerCurrentMon.Attack, playerCurrentMon.Moves[attackIndex];
                //dealDamage(dmgVal);
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

    public void OnAttack1()
    {
        executeTurn(0);
    }

    public void OnAttack2()
    {
        executeTurn(1);
    }

    public void OnAttack3()
    {
        executeTurn(2);
    }

    public void OnAttack4()
    {
        executeTurn(3);
    }

    public void OnMon1()
    {
        playerSwitch(0);
    }

    public void OnMon2()
    {
        playerSwitch(1);
    }

    public void OnMon3()
    {
        playerSwitch(2);
    }

    public void OnMon4()
    {
        playerSwitch(3);
    }

    public void OnAttackButton()
    {

    }

    public void OnMonButton()
    {

    }

    public void OnStatButton()
    {

    }

}
