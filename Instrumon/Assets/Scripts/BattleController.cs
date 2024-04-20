using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class BattleController : MonoBehaviour
{
    private System.Random random = new System.Random();
    public TextMeshProUGUI descriptionText;

    //player visual variables
    public SpriteRenderer playerSpriteHolder;
    public TextMeshProUGUI playerNameText;
    public Image playerHealthBar;
    private float playerCurrentHealth;
    private float playerTotalHealth;
    public TextMeshProUGUI playerCurrentHealthText;
    public TextMeshProUGUI playerTotalHealthText;

    //cpu visual variables
    public SpriteRenderer oppSpriteHolder;
    public TextMeshProUGUI oppNameText;
    public Image oppHealthBar;
    private float oppCurrentHealth;
    private float oppTotalHealth;
    public TextMeshProUGUI oppCurrentHealthText;
    public TextMeshProUGUI oppTotalHealthText;

    //player variables
    public static List<Instrumon> playerParty = ProgressFlags.returnPlyrPrty();
    public static Instrumon playerCurrentMon = playerParty[0];
    public Sprite playerSprite = playerCurrentMon.Base.FrontSprite;
    private String playerName = playerCurrentMon.Base.Name;
    
    //cpu variables
    public static List<Instrumon> oppParty = ProgressFlags.returnOppPrty();
    public static Instrumon oppCurrentMon = oppParty[0];
    public int oppCurrentIndex = 0;
    public Sprite oppSprite = oppCurrentMon.Base.FrontSprite;
    private String oppName = oppCurrentMon.Base.Name;
    private int oppMonHP = oppCurrentMon.MaxHP;

    //button variables
    public GameObject monList;
    public GameObject monBackBtn;

    // Start is called before the first frame update
    void Start()
    {
        descriptionText.text = "What will you do?";
        //Displays the right things on screen at the start of battle for the player
        playerSpriteHolder.sprite = playerSprite;
        playerNameText.text = playerName.ToString();
        playerCurrentHealth = playerCurrentMon.Base.CurrentHP;
        playerTotalHealth = playerCurrentMon.MaxHP;
        takeDamage(0);
        playerTotalHealthText.text = playerTotalHealth.ToString();

        //... and the opponent
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

    //is called when all of the opponent's mons die
    public void winBattle()
    {
        descriptionText.text = "You win!";
        SceneManager.LoadScene(1);
    }

    //is called when all of the player's mons die
    public void loseBattle()
    {
        descriptionText.text = "You lost...";
        SceneManager.LoadScene(1);
    }

    //is called when player voluntarily switches mons
    public void playerSwitch(int monIndex)
    {
        playerCurrentMon = playerParty[monIndex];
        playerSpriteHolder.sprite = playerSprite;
        playerNameText.text = playerName.ToString();
        playerCurrentHealth = playerCurrentMon.Base.CurrentHP;
        playerTotalHealth = playerCurrentMon.MaxHP;
        takeDamage(0);
        playerTotalHealthText.text = playerCurrentMon.MaxHP.ToString();

        oppTurn();
    }
    
    //is called when player's mon dies
    public void playerDeathSwitch()
    {
        descriptionText.text = playerName.ToString() + "has fainted, please choose another Instrumon to battle.";
        monList.SetActive(true);
        monBackBtn.SetActive(false);
    }
    
    //is called when the player chooses a move to use
    public void executeTurn(int attackIndex)
    {
        if (playerFirst())
        {
            float dmgVal = calcDamage(oppCurrentMon.MaxHP, playerCurrentMon.Attack, playerCurrentMon.Moves[attackIndex]);
            dealDamage(dmgVal);

            if (oppCurrentHealth > 0) //if the opp mon dies, force a switch
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

            if (playerCurrentHealth > 0) //if the player mon dies, force a switch
            {
                float dmgVal = calcDamage(oppCurrentMon.MaxHP, playerCurrentMon.Attack, playerCurrentMon.Moves[attackIndex]);
                dealDamage(dmgVal);
            }
            else
            {
                playerDeathSwitch();
            }
        }
        descriptionText.text = "What's the next move?";
    }

    //is called by execute turn depending on who attacks first according to
    //playerFirst()
    public void oppTurn()
    {
        int randVal = oppCurrentMon.Moves.Count;
        Move selMove = oppCurrentMon.Moves[random.Next(0, randVal)];
        float dmgVal = calcDamage(oppCurrentMon.MaxHP, oppCurrentMon.Attack, selMove);
        takeDamage(dmgVal);
    }

    //is called when an opponent mon dies
    public void oppSwitch()
    {
        oppCurrentIndex += 1;
        if (oppCurrentIndex > oppParty.Count - 1)
        {
            winBattle();
        }
        else
        {
            oppCurrentMon = oppParty[oppCurrentIndex];
            oppSpriteHolder.sprite = oppSprite;
            oppNameText.text = oppName.ToString();
            oppCurrentHealth = oppMonHP;
            oppTotalHealth = oppMonHP;
            dealDamage(0);
            oppTotalHealthText.text = oppMonHP.ToString();
        }
    }

    //returns a bool for if the player or opponent goes first
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
    
    //damage value calc
    public int calcDamage(int totalHP, int atkStat, Move Move)
    {
        return (int)Math.Ceiling((decimal)(Math.Abs(atkStat + Move.Base.Power - totalHP / 2)));
    }

    //damage done to player
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

    //damage done to opponent
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

    //heal done to player
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

    //heal done to opponent
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

    //OnAttack1-4() passes the index of the attack to the turn executer
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

    //OnMon1-4() passes the index of the mon to switch to to the mon switcher
    public void OnMon1()
    {
        if (playerParty[0].Base.CurrentHP > 0)
        {
            playerSwitch(0);
        }
        else
        {
            playerNameText.text = "That Instrumon isn't fit for battle!";
}
    }

    public void OnMon2()
    {
        if (playerParty[1].Base.CurrentHP > 0)
        {
            playerSwitch(1);
        }
        else
        {
            playerNameText.text = "That Instrumon isn't fit for battle!";
        }
    }

    public void OnMon3()
    {
        if (playerParty[2].Base.CurrentHP > 0)
        {
            playerSwitch(2);
        }
        else
        {
            playerNameText.text = "That Instrumon isn't fit for battle!";
        }
    }

    public void OnMon4()
    {
        if (playerParty[3].Base.CurrentHP > 0)
        {
            playerSwitch(3);
        }
        else
        {
            playerNameText.text = "That Instrumon isn't fit for battle!";
        }
    }

    //extra functions in case needed for each main button press
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
