using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Party", menuName = "Party/Create new Party")]
public class PartyBase : ScriptableObject
{
    [SerializeField] string PartyName;   
    

    [SerializeField]
    public int PartyID;
    [SerializeField] 
    public int level;
    [SerializeField]
    public List<Instrumon> Instrumons;

    public int GetID()
    {
        return PartyID;
    }

    public void SetLevel(int nlevel)
    {
        level = nlevel;
    }

    public List<Instrumon> GetInstrumons()
    {

        return Instrumons;
    }

    public Instrumon GetHealthyInstrumon()
    {
        return Instrumons.Where(x => x.MaxHP > 0).FirstOrDefault();
    }
    public void UpdateLevelParty()
    {
        this.SetLevel(ProgressFlags.Flag);
        this.updatelevel();
        Debug.Log("Party Level: " + level);

    }

    public void updatelevel()
    {
        foreach (var instrumon in Instrumons)
        {
            instrumon.LevelSet(level);
            Debug.Log("Instrumon Level: " + instrumon.level);
        }
    }
}
