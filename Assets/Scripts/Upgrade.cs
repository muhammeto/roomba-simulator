using UnityEngine;

[CreateAssetMenu(fileName ="New Upgrade",menuName ="New Upgrade")]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public Sprite upgradeIcon;
    public int currentLevel = 0;
    public float[] valueLookup;
    public float[] costLookup;

    public bool CanUpgrade(float money)
    {
        if (currentLevel + 1 < costLookup.Length)
        {
            if(money >= costLookup[currentLevel + 1])
            {
                return true;
            }
        }
        return false;
    }
    public float GetCurrentCost()
    {
        if(currentLevel+1< costLookup.Length)
        {
            return costLookup[currentLevel+1];
        }
        else
        {
            return -1f;
        }
    }
    public float GetCurrentValue()
    {
        return valueLookup[currentLevel];
    }
    public int GetCurrentLevel()
    {
        return currentLevel;
    }
    public void IncraseLevel()
    {
        if (currentLevel + 1 < costLookup.Length)
        {
            currentLevel++;
        }
    }
}
