using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonUpdater : MonoBehaviour
{
    public TMP_Text instrumonName1Text;
    public TMP_Text instrumonName2Text;
    public TMP_Text instrumonName3Text;
    public TMP_Text instrumonName4Text;

    public TMP_Text instrumonLevelText1;
    public TMP_Text instrumonLevelText2;
    public TMP_Text instrumonLevelText3;
    public TMP_Text instrumonLevelText4;

    public TMP_Text instrumonHPText1;
    public TMP_Text instrumonHPText2;
    public TMP_Text instrumonHPText3;
    public TMP_Text instrumonHPText4;

    public Image instrumonHealthBar1;
    public Image instrumonHealthBar2;
    public Image instrumonHealthBar3;
    public Image instrumonHealthBar4;

    public Button instrumonButton1;
    public Button instrumonButton2;
    public Button instrumonButton3;
    public Button instrumonButton4;

    private void Start()
    {
        UpdateInstrumonNames();
    }

    public void UpdateInstrumonNames()
    {
        var instrumons = ProgressFlags.ReturnPlyrPrty();

        if (instrumons.Count >= 1)
        {
            instrumonName1Text.text = instrumons[0].Base.instrumonName;
            instrumonLevelText1.text = "Lvl " + instrumons[0].level.ToString();
            instrumonHPText1.text = instrumons[0].Base.CurrentHP.ToString() + '/' + instrumons[0].Base.MaxHP.ToString();
            instrumonHealthBar1.fillAmount = (float)instrumons[0].Base.CurrentHP / instrumons[0].Base.MaxHP;
            /*if (instrumons[0].Base.CurrentHP == 0)
            {
                ColorBlock colors = instrumonButton1.colors;
                colors.normalColor = new Color(170f / 255f, 0f, 0f);
                instrumonButton1.colors = colors;
            }*/
        }
        else
        {
            instrumonName1Text.text = "No Instrumon";
            instrumonLevelText1.text = "";
            instrumonHPText1.text = "";
        }

        if (instrumons.Count >= 2)
        {
            instrumonName2Text.text = instrumons[1].Base.instrumonName;
            instrumonLevelText2.text = "Lvl " + instrumons[1].level.ToString();
            instrumonHPText2.text = instrumons[1].Base.CurrentHP.ToString() + '/' + instrumons[1].Base.MaxHP.ToString();
            instrumonHealthBar2.fillAmount = (float)instrumons[1].Base.CurrentHP / instrumons[1].Base.MaxHP;
        }
        else
        {
            instrumonName2Text.text = "";
            instrumonLevelText2.text = "";
            instrumonHPText2.text = "";
        }

        if (instrumons.Count >= 3)
        {
            instrumonName3Text.text = instrumons[2].Base.instrumonName;
            instrumonLevelText3.text = "Lvl " + instrumons[2].level.ToString();
            instrumonHPText3.text = instrumons[2].Base.CurrentHP.ToString() + '/' + instrumons[2].Base.MaxHP.ToString();
            instrumonHealthBar3.fillAmount = (float)instrumons[2].Base.CurrentHP / instrumons[2].Base.MaxHP;
        }
        else
        {
            instrumonName3Text.text = "";
            instrumonLevelText3.text = "";
            instrumonHPText3.text = "";
        }

        if (instrumons.Count >= 4)
        {
            instrumonName4Text.text = instrumons[3].Base.instrumonName;
            instrumonLevelText4.text = "Lvl " + instrumons[3].level.ToString();
            instrumonHPText4.text = instrumons[3].Base.CurrentHP.ToString() + '/' + instrumons[3].Base.MaxHP.ToString();
            instrumonHealthBar4.fillAmount = (float)instrumons[3].Base.CurrentHP / instrumons[3].Base.MaxHP;
        }
        else
        {
            instrumonName4Text.text = "";
            instrumonLevelText4.text = "";
            instrumonHPText4.text = "";
        }
    }


}
