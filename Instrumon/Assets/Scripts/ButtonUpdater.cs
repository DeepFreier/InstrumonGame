using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    //public GameObject summaryButton1;
    //public GameObject summaryButton2;
    //public GameObject summaryButton3;
    //public GameObject summaryButton4;

    public PartyBase playerParty;

    private void Start()
    {
        UpdateInstrumonNames();
    }

    public void UpdateInstrumonNames()
    {
        var instrumons = playerParty.GetInstrumons();

        if (instrumons.Count >= 1)
        {
            instrumonName1Text.text = instrumons[0].Base.instrumonName;
            instrumonLevelText1.text = "Lvl " + instrumons[0].level.ToString();
            instrumonHPText1.text = instrumons[0].CurrentHP.ToString() + '/' + instrumons[0].MaxHP.ToString();
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
            instrumonHPText2.text = instrumons[1].CurrentHP.ToString() + '/' + instrumons[1].MaxHP.ToString();
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
            instrumonHPText3.text = instrumons[2].CurrentHP.ToString() + '/' + instrumons[2].MaxHP.ToString();
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
            instrumonHPText4.text = instrumons[3].CurrentHP.ToString() + '/' + instrumons[3].MaxHP.ToString();
        }
        else
        {
            instrumonName4Text.text = "";
            instrumonLevelText4.text = "";
            instrumonHPText4.text = "";
        }
    }


}
