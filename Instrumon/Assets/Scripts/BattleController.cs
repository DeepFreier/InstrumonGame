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
    public TextMeshProUGUI playerCurrentHealthText;
    public TextMeshProUGUI playerTotalHealthText;
    //attackbuttons
    public TextMeshProUGUI atk1text;
    public TextMeshProUGUI atk2text;
    public TextMeshProUGUI atk3text;
    public TextMeshProUGUI atk4text;
    //monbuttons
    public TextMeshProUGUI mon1text;
    public TextMeshProUGUI mon2text;
    public TextMeshProUGUI mon3text;
    public TextMeshProUGUI mon4text;
    //Stat screen variables
    public TextMeshProUGUI statPlayerName;
    public Image statPlayerSprite;
    public TextMeshProUGUI statPlayerHPText;
    public TextMeshProUGUI statPlayerAtkText;
    public TextMeshProUGUI statPlayerSpdText;
    public TextMeshProUGUI statMove1Name;
    public TextMeshProUGUI statMove2Name;
    public TextMeshProUGUI statMove3Name;
    public TextMeshProUGUI statMove4Name;
    public TextMeshProUGUI statMove1Pow;
    public TextMeshProUGUI statMove2Pow;
    public TextMeshProUGUI statMove3Pow;
    public TextMeshProUGUI statMove4Pow;

    public Image statOppSprite;
    public TextMeshProUGUI statOppName;
    public TextMeshProUGUI statOppHPText;
    public TextMeshProUGUI statOppAtkText;
    public TextMeshProUGUI statOppSpdText;
    public TextMeshProUGUI statOppDescriptionText;

    //cpu visual variables
    public SpriteRenderer oppSpriteHolder;
    public TextMeshProUGUI oppNameText;
    public Image oppHealthBar;
    public TextMeshProUGUI oppCurrentHealthText;
    public TextMeshProUGUI oppTotalHealthText;

    //player variables
    public static List<Instrumon> playerParty = ProgressFlags.ReturnPlyrPrty();
    public static Instrumon playerCurrentMon = playerParty[0];
    bool playerDeathSwitchFlag = false;
    
    //cpu variables
    public static List<Instrumon> oppParty = ProgressFlags.ReturnOppPrty();
    public static Instrumon oppCurrentMon = oppParty[0];
    int oppCurrentIndex = 0;

    //button variables
    public GameObject atkList;
    public GameObject monList;
    public GameObject monBackBtn;


    //Audio Manager
    BattleAudioManager audioManager;

    public SaveSystemMk2 saveSystem;


    // Start is called before the first frame update
    void Start()
    {
        audioManager.StartInstrumonSongs();
        audioManager.MutePlayerSongs();
        audioManager.MuteOppSongs();
      

        oppCurrentIndex = 0;
        playerDeathSwitchFlag = false;

        if (playerCurrentMon.Base.CurrentHP <= 0)
        {
            foreach (Instrumon mon in playerParty)
            {
                if (mon.Base.CurrentHP > 0)
                {
                    playerCurrentMon = mon;
                    break;
                }
            }
        }
        foreach (Instrumon mon in oppParty)
        {
            if (mon.Base.CurrentHP < mon.Base.MaxHP)
            {
                mon.Base.CurrentHP = mon.Base.MaxHP;
            }
        }


        descriptionText.text = "What will you do?";
        //Displays the right things on screen at the start of battle for the player
        playerSpriteHolder.sprite = playerCurrentMon.Base.FrontSprite;
        playerNameText.text = playerCurrentMon.Base.Name.ToString();
        playerCurrentHealthText.text = playerCurrentMon.Base.CurrentHP.ToString();
        playerTotalHealthText.text = playerCurrentMon.Base.MaxHP.ToString();
        playerHealthBar.fillAmount = (float)playerCurrentMon.Base.CurrentHP / playerCurrentMon.Base.MaxHP;
        playerCurrentHealthText.text = playerCurrentMon.Base.CurrentHP.ToString();

        //... and the opponent
        oppCurrentMon = oppParty[oppCurrentIndex];
        oppSpriteHolder.sprite = oppCurrentMon.Base.FrontSprite;
        oppNameText.text = oppCurrentMon.Base.Name.ToString();
        oppCurrentHealthText.text = oppCurrentMon.Base.CurrentHP.ToString();
        oppTotalHealthText.text = oppCurrentMon.Base.MaxHP.ToString();
        oppHealthBar.fillAmount = (float)oppCurrentMon.Base.CurrentHP / oppCurrentMon.Base.MaxHP;
        oppCurrentHealthText.text = oppCurrentMon.Base.CurrentHP.ToString();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<BattleAudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //display correct move names
        atk1text.text = playerCurrentMon.Base.Moves[0].Base.MoveName;
        atk2text.text = playerCurrentMon.Base.Moves[1].Base.MoveName;
        atk3text.text = playerCurrentMon.Base.Moves[2].Base.MoveName;
        atk4text.text = playerCurrentMon.Base.Moves[3].Base.MoveName;

        //display correct mon names
        mon1text.text = playerParty[0].Base.instrumonName;
        mon2text.text = playerParty[1].Base.instrumonName;
        mon3text.text = playerParty[2].Base.instrumonName;
        mon4text.text = playerParty[3].Base.instrumonName;

        //display correct stats
        statPlayerName.text = playerCurrentMon.Base.instrumonName;
        statPlayerSprite.sprite = playerCurrentMon.Base.FrontSprite;
        statPlayerHPText.text = playerCurrentMon.Base.MaxHP.ToString();
        statPlayerAtkText.text = playerCurrentMon.Base.Attack.ToString();
        statPlayerSpdText.text = playerCurrentMon.Base.Speed.ToString();
        statMove1Name.text = playerCurrentMon.Base.Moves[0].Base.name;
        statMove2Name.text = playerCurrentMon.Base.Moves[1].Base.name;
        statMove3Name.text = playerCurrentMon.Base.Moves[2].Base.name;
        statMove4Name.text = playerCurrentMon.Base.Moves[3].Base.name;
        statMove1Pow.text = playerCurrentMon.Base.Moves[0].Base.Power.ToString();
        statMove2Pow.text = playerCurrentMon.Base.Moves[1].Base.Power.ToString();
        statMove3Pow.text = playerCurrentMon.Base.Moves[2].Base.Power.ToString();
        statMove4Pow.text = playerCurrentMon.Base.Moves[3].Base.Power.ToString();

        statOppName.text = oppCurrentMon.Base.instrumonName;
        statOppSprite.sprite = oppCurrentMon.Base.FrontSprite;
        statOppHPText.text = oppCurrentMon.Base.MaxHP.ToString();
        statOppAtkText.text = oppCurrentMon.Base.Attack.ToString();
        statOppSpdText.text = oppCurrentMon.Base.Speed.ToString(); ;
        statOppDescriptionText.text = oppCurrentMon.Base.Description;
}

    //is called when all of the opponent's mons die
    public IEnumerator winBattle()
    {
        descriptionText.text = "You win!";
        yield return new WaitForSeconds(3);
        saveSystem.LoadWithFlag(ProgressFlags.Flag + 1);
    }

    //is called when all of the player's mons die
    public IEnumerator loseBattle()
    {
        descriptionText.text = "You lost...";
        yield return new WaitForSeconds(3);
        saveSystem.LoadWithPosition(96, -100.42);
        GameObject player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().healparty();
    }

    //is called when player voluntarily switches mons
    public IEnumerator playerSwitch(int monIndex)
    {
        descriptionText.text = "Go " + playerParty[monIndex].Base.instrumonName + "!";
        yield return new WaitForSeconds(1);
        playerCurrentMon = playerParty[monIndex];
        playerSpriteHolder.sprite = playerCurrentMon.Base.FrontSprite;
        playerNameText.text = playerCurrentMon.Base.instrumonName.ToString();
        playerTotalHealthText.text = playerCurrentMon.Base.MaxHP.ToString();
        takeDamage(0);
        monList.SetActive(false);
        audioManager.MutePlayerSongs();
        if (!playerDeathSwitchFlag)
        {
            descriptionText.text = oppCurrentMon.Base.instrumonName + " found an openning!";
            oppTurn();
        }
        playerDeathSwitchFlag = false;
    }
    
    //is called when player's mon dies
    public void playerDeathSwitch()
    {
        descriptionText.text = playerCurrentMon.Base.instrumonName.ToString() + " has fainted, please choose another Instrumon to battle.";
        playerDeathSwitchFlag = true;
        monList.SetActive(true);
        monBackBtn.SetActive(false);
    }
    
    //is called when the player chooses a move to use
    public IEnumerator executeTurn(int attackIndex)
    {
        if (playerFirst())
        {
            
            float dmgVal = calcDamage(oppCurrentMon.MaxHP, playerCurrentMon.Attack, playerCurrentMon.Base.Moves[attackIndex]);
            dealDamage(dmgVal);
            yield return new WaitForSeconds(1);
            if (oppCurrentMon.Base.CurrentHP > 0) //if the opp mon dies, force a switch
            {
                oppTurn();
                descriptionText.text = playerCurrentMon.Base.instrumonName + " and " + oppCurrentMon.Base.instrumonName +
                    " traded blows!";
            }
            else
            {
                oppSwitch();
            }
            if (playerCurrentMon.Base.CurrentHP <= 0)
            {
                int total = 0;
                foreach (Instrumon mon in playerParty)
                {
                    total += mon.Base.CurrentHP;
                }
                if (total > 0)
                {
                    playerDeathSwitch();
                }
                else
                {
                    StartCoroutine(loseBattle());
                }
            }
        }
        else
        {
            oppTurn();
            yield return new WaitForSeconds(1);
            if (playerCurrentMon.Base.CurrentHP > 0) //if the player mon dies, force a switch
            {
                float dmgVal = calcDamage(oppCurrentMon.MaxHP, playerCurrentMon.Attack, playerCurrentMon.Base.Moves[attackIndex]);
                dealDamage(dmgVal);
                descriptionText.text = oppCurrentMon.Base.instrumonName + " and " + playerCurrentMon.Base.instrumonName +
                    " traded blows!";
                if (oppCurrentMon.Base.CurrentHP <= 0)
                {
                    oppSwitch();
                }
            }
            else
            {
                int total = 0;
                foreach (Instrumon mon in playerParty)
                {
                    total += mon.Base.CurrentHP;
                }
                if (total > 0)
                {
                    playerDeathSwitch();
                }
                else
                {
                    StartCoroutine(loseBattle());
                }
                
            }
        }
        atkList.SetActive(false);
    }

    //is called by execute turn depending on who attacks first according to
    //playerFirst()
    public void oppTurn()
    {
        int randVal = oppCurrentMon.Base.Moves.Count;
        Moves selMove = oppCurrentMon.Base.Moves[random.Next(0, randVal)];
        float dmgVal = calcDamage(oppCurrentMon.MaxHP, oppCurrentMon.Attack, selMove);
        takeDamage(dmgVal);
    }

    //is called when an opponent mon dies
    public void oppSwitch()
    {
        oppCurrentIndex += 1;
        if (oppCurrentIndex > oppParty.Count - 1)
        {
            StartCoroutine(winBattle());
        }
        else
        {
            oppCurrentMon = oppParty[oppCurrentIndex];
            oppSpriteHolder.sprite = oppCurrentMon.Base.FrontSprite;
            oppNameText.text = oppCurrentMon.Base.instrumonName.ToString();
            dealDamage(0);
            oppCurrentHealthText.text = oppCurrentMon.Base.CurrentHP.ToString();
            oppTotalHealthText.text = oppCurrentMon.Base.MaxHP.ToString();
        }
        audioManager.MuteOppSongs();
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
    public int calcDamage(int totalHP, int atkStat, Moves Move)
    {
        return (int)Math.Ceiling((decimal)(Math.Abs(atkStat/4 + Move.Base.Power - totalHP / 2)));
    }

    //damage done to player
    public void takeDamage(float damage)
    {
        playerCurrentMon.Base.CurrentHP -= ((int)damage);
        if (playerCurrentMon.Base.CurrentHP < 0) 
        {
            playerCurrentMon.Base.CurrentHP = 0;
        }
        playerHealthBar.fillAmount = (float)playerCurrentMon.Base.CurrentHP / playerCurrentMon.Base.MaxHP;
        playerCurrentHealthText.text = playerCurrentMon.Base.CurrentHP.ToString();
    }

    //damage done to opponent
    public void dealDamage(float damage)
    {
        oppCurrentMon.Base.CurrentHP -= ((int)damage);
        if (oppCurrentMon.Base.CurrentHP < 0)
        {
            oppCurrentMon.Base.CurrentHP = 0;
        }
        oppHealthBar.fillAmount = (float)oppCurrentMon.Base.CurrentHP / oppCurrentMon.Base.MaxHP;
        oppCurrentHealthText.text = oppCurrentMon.Base.CurrentHP.ToString();
    }

    //heal done to player
    public void healDamage(float heal)
    {
        playerCurrentMon.Base.CurrentHP += ((int)heal);
        if (playerCurrentMon.Base.CurrentHP > playerCurrentMon.Base.MaxHP)
        {
            playerCurrentMon.Base.CurrentHP = playerCurrentMon.Base.MaxHP;
        }
        playerHealthBar.fillAmount = (float)playerCurrentMon.Base.CurrentHP / playerCurrentMon.Base.MaxHP;
        playerCurrentHealthText.text = playerCurrentMon.Base.CurrentHP.ToString();
    }

    //heal done to opponent
    public void healOppDamage(float heal)
    {
        oppCurrentMon.Base.CurrentHP += ((int)heal);
        if (oppCurrentMon.Base.CurrentHP > oppCurrentMon.Base.MaxHP)
        {
            oppCurrentMon.Base.CurrentHP = oppCurrentMon.Base.MaxHP;
        }
        oppHealthBar.fillAmount = (float)oppCurrentMon.Base.CurrentHP / oppCurrentMon.Base.MaxHP;
        oppCurrentHealthText.text = oppCurrentMon.Base.CurrentHP.ToString();
    }

    //OnAttack1-4() passes the index of the attack to the turn executer
    public void OnAttack1()
    {
        StartCoroutine(executeTurn(0));
    }

    public void OnAttack2()
    {
        StartCoroutine(executeTurn(1));
    }

    public void OnAttack3()
    {
        StartCoroutine(executeTurn(2));
    }

    public void OnAttack4()
    {
        StartCoroutine(executeTurn(3));
    }

    //OnMon1-4() passes the index of the mon to switch to to the mon switcher
    public void OnMon1()
    {
        if (playerParty[0].Base.CurrentHP > 0 & playerCurrentMon != playerParty[0])
        {
            StartCoroutine(playerSwitch(0));
        }
        if (playerParty[0].Base.CurrentHP <= 0)
        {
            descriptionText.text = playerParty[0].Base.instrumonName + " doesn't have enough HP to fight!";
        }
        if (playerCurrentMon == playerParty[0])
        {
            descriptionText.text = playerCurrentMon.Base.instrumonName + " is already in battle!";
        }
    }

    public void OnMon2()
    {
        if (playerParty[1].Base.CurrentHP > 0 & playerCurrentMon != playerParty[1])
        {
            StartCoroutine(playerSwitch(1));
        }
        if (playerParty[1].Base.CurrentHP <= 0)
        {
            descriptionText.text = playerParty[1].Base.instrumonName + " doesn't have enough HP to fight!";
        }
        if (playerCurrentMon == playerParty[1])
        {
            descriptionText.text = playerCurrentMon.Base.instrumonName + " is already in battle!";
        }
    }

    public void OnMon3()
    {
        if (playerParty[2].Base.CurrentHP > 0 & playerCurrentMon != playerParty[2])
        {
            StartCoroutine(playerSwitch(2));
        }
        if (playerParty[2].Base.CurrentHP <= 0)
        {
            descriptionText.text = playerParty[2].Base.instrumonName + " doesn't have enough HP to fight!";
        }
        if (playerCurrentMon == playerParty[2])
        {
            descriptionText.text = playerCurrentMon.Base.instrumonName + " is already in battle!";
        }
    }

    public void OnMon4()
    {
        if (playerParty[3].Base.CurrentHP > 0 & playerCurrentMon != playerParty[3])
        {
            StartCoroutine(playerSwitch(3));
        }
        if (playerParty[3].Base.CurrentHP <= 0)
        {
            descriptionText.text = playerParty[3].Base.instrumonName + " doesn't have enough HP to fight!";
        }
        if (playerCurrentMon == playerParty[3])
        {
            descriptionText.text = playerCurrentMon.Base.instrumonName + " is already in battle!";
        }
    }

    //extra functions in case needed for each main button press
    public void OnAttackButton()
    {

    }

    public void OnMonButton()
    {
        monBackBtn.SetActive(true);
    }

    public void OnStatButton()
    {

    }

}
