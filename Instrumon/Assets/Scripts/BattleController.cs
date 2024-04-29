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

    //cpu visual variables
    public SpriteRenderer oppSpriteHolder;
    public TextMeshProUGUI oppNameText;
    public Image oppHealthBar;
    public TextMeshProUGUI oppCurrentHealthText;
    public TextMeshProUGUI oppTotalHealthText;

    //player variables

    public static List<Instrumon> playerParty = ProgressFlags.ReturnPlyrPrty();
    public static Instrumon playerCurrentMon = playerParty[0];
    
    //cpu variables
    public static List<Instrumon> oppParty = ProgressFlags.ReturnOppPrty();
    public static Instrumon oppCurrentMon = oppParty[0];
    public int oppCurrentIndex = 0;

    //button variables
    public GameObject atkList;
    public GameObject monList;
    public GameObject monBackBtn;


    //Audio Manager
    BattleAudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {

        PlayerSongs();
        OppSongs();
        oppCurrentIndex = 0;


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

    void PlayerSongs()
    {

        if (playerCurrentMon.Base.instrumonName == "Corvinet")
        {
            audioManager.PlayInstrumonSongs(audioManager.clarinetSong, audioManager.drumLoop);
        }
        if (playerCurrentMon.Base.instrumonName == "Trumpig")
        {
            audioManager.PlayInstrumonSongs(audioManager.trumpetSong, audioManager.drumLoop);
        }
        if (playerCurrentMon.Base.instrumonName == "Elephone")
        {
            audioManager.PlayInstrumonSongs(audioManager.saxophoneSong, audioManager.drumLoop);
        }
        if (playerCurrentMon.Base.instrumonName == "Flumingo")
        {
            audioManager.PlayInstrumonSongs(audioManager.fluteSong, audioManager.drumLoop);
        }
        if (playerCurrentMon.Base.instrumonName == "Guitowl")
        {
            audioManager.PlayInstrumonSongs(audioManager.guitarSong, audioManager.drumLoop);
        }
        if (playerCurrentMon.Base.instrumonName == "Locello")
        {
            audioManager.PlayInstrumonSongs(audioManager.celloSong, audioManager.drumLoop);
        }
        if (playerCurrentMon.Base.instrumonName == "Tarampani")
        {
            audioManager.PlayInstrumonSongs(audioManager.timpaniSong, audioManager.drumLoop);
        }
        if (playerCurrentMon.Base.instrumonName == "Tortuba")
        {
            audioManager.PlayInstrumonSongs(audioManager.tubaSong, audioManager.drumLoop);
        }
        if (playerCurrentMon.Base.instrumonName == "Trombeaver")
        {
            audioManager.PlayInstrumonSongs(audioManager.tromboneSong, audioManager.drumLoop);
        }
        if (playerCurrentMon.Base.instrumonName == "Viperlin")
        {
            audioManager.PlayInstrumonSongs(audioManager.violinSong, audioManager.drumLoop);
        }
        if (playerCurrentMon.Base.instrumonName == "Xylynx")
        {
            audioManager.PlayInstrumonSongs(audioManager.xylophoneSong, audioManager.drumLoop);
        }
    }

    void OppSongs()
    {
        if (oppCurrentMon.Base.instrumonName == "Corvinet")
        {

            audioManager.OppInstrumonSongs(audioManager.clarinetSong);
        }
        if (oppCurrentMon.Base.instrumonName == "Trumpig")
        {

            audioManager.OppInstrumonSongs(audioManager.trumpetSong);
        }
        if (oppCurrentMon.Base.instrumonName == "Elephone")
        {

            audioManager.OppInstrumonSongs(audioManager.saxophoneSong);
        }
        if (oppCurrentMon.Base.instrumonName == "Flumingo")
        {

            audioManager.OppInstrumonSongs(audioManager.fluteSong);
        }
        if (oppCurrentMon.Base.instrumonName == "Guitowl")
        {
            audioManager.OppInstrumonSongs(audioManager.guitarSong);
        }
        if (oppCurrentMon.Base.instrumonName == "Locello")
        {
            audioManager.OppInstrumonSongs(audioManager.celloSong);
        }
        if (oppCurrentMon.Base.instrumonName == "Tarampani")
        {
            audioManager.OppInstrumonSongs(audioManager.timpaniSong);
        }
        if (oppCurrentMon.Base.instrumonName == "Tortuba")
        {
            audioManager.OppInstrumonSongs(audioManager.tubaSong);
        }
        if (oppCurrentMon.Base.instrumonName == "Trombeaver")
        {
            audioManager.OppInstrumonSongs(audioManager.tromboneSong);
        }
        if (oppCurrentMon.Base.instrumonName == "Viperlin")
        {
            audioManager.OppInstrumonSongs(audioManager.violinSong);
        }
        if (oppCurrentMon.Base.instrumonName == "Xylynx")
        {
            audioManager.OppInstrumonSongs(audioManager.xylophoneSong);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //is called when all of the opponent's mons die
    public IEnumerator winBattle()
    {
        descriptionText.text = "You win!";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
        ProgressFlags.UpdateFlag(ProgressFlags.Flag + 1);
    }

    //is called when all of the player's mons die
    public IEnumerator loseBattle()
    {
        descriptionText.text = "You lost...";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
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
        PlayerSongs();

        descriptionText.text = oppCurrentMon.Base.instrumonName + " found an openning!";
        oppTurn();
    }
    
    //is called when player's mon dies
    public void playerDeathSwitch()
    {
        descriptionText.text = playerCurrentMon.Base.instrumonName.ToString() + " has fainted, please choose another Instrumon to battle.";
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
            oppTotalHealthText.text = oppCurrentMon.Base.Name.ToString();
            OppSongs();
            oppTotalHealthText.text = oppCurrentMon.Base.MaxHP.ToString();
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

    }

    public void OnStatButton()
    {

    }

}
