using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BattleController : MonoBehaviour
{
    public Image playerHealthBar;
    private float playerCurrentHealth;
    private float playerTotalHealth;
    public TextMeshProUGUI playerCurrentHealthText;
    public TextMeshProUGUI playerTotalHealthText;

    public Image oppHealthBar;
    private float oppCurrentHealth;
    private float oppTotalHealth;
    public TextMeshProUGUI oppCurrentHealthText;
    public TextMeshProUGUI oppTotalHealthText;

    private int playerCurrentHP = 80;
    private int playerMonHP = 90;
    private int PlayerMonSpd = 5;
    private int oppMonHP = 120;
    private int OpponentMonSpd = 4;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerCurrentHP;
        playerTotalHealth = playerMonHP;
        takeDamage(0);
        playerTotalHealthText.text = playerMonHP.ToString();

        oppCurrentHealth = oppMonHP;
        oppTotalHealth = oppMonHP;
        dealDamage(0);
        oppTotalHealthText.text = oppMonHP.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            takeDamage(5);
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
    }

    public void takeDamage(float damage)
    {
        playerCurrentHealth -= damage;
        playerHealthBar.fillAmount = playerCurrentHealth / playerTotalHealth;
        playerCurrentHealthText.text = playerCurrentHealth.ToString();
    }

    public void dealDamage(float damage)
    {
        oppCurrentHealth -= damage;
        oppHealthBar.fillAmount = oppCurrentHealth / oppTotalHealth;
        oppCurrentHealthText.text = oppCurrentHealth.ToString();
    }

    public void healDamage(float heal)
    {
        playerCurrentHealth += heal;
        playerHealthBar.fillAmount = playerCurrentHealth / playerTotalHealth;
        playerCurrentHealthText.text = playerCurrentHealth.ToString();
    }

    public void healOppDamage(float heal)
    {
        oppCurrentHealth += heal;
        oppHealthBar.fillAmount = oppCurrentHealth / oppTotalHealth;
        oppCurrentHealthText.text = oppCurrentHealth.ToString();
    }
        public void OnAttackButton()
    {

    }

    public void OnAttackSelected(int attackPow)
    {
        if (PlayerMonSpd > OpponentMonSpd)
        {

        }
        else
        {
            
        }
    }

    public void OnMonButton()
    {

    }

    public void OnStatButton()
    {

    }

}
