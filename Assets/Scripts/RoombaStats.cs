using UnityEngine;

[CreateAssetMenu(fileName = "New Roomba Stats", menuName = "New Roomba Stats")]

public class RoombaStats : ScriptableObject
{
    public Upgrade[] upgrades;
    public float money;
    public float GetValueByName(string upgradeName)
    {
        return GetUpgradeByName(upgradeName).GetCurrentValue();
    }
    public float GetCostByName(string upgradeName)
    {
        return GetUpgradeByName(upgradeName).GetCurrentCost();
    }
    public int GetLevelByName(string upgradeName)
    {
        return GetUpgradeByName(upgradeName).GetCurrentLevel();
    }
    public bool CanUpgrade(string upgradeName)
    {
        return GetUpgradeByName(upgradeName).CanUpgrade(money);
    }
    public Upgrade GetUpgradeByName(string upgradeName)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            if (upgrades[i].upgradeName.Equals(upgradeName))
            {
                return upgrades[i];
            }
        }
        return null;
    }
    public void UpgradeByName(string upgradeName)
    {
        money -= GetCostByName(upgradeName);
        GetUpgradeByName(upgradeName).IncraseLevel();
    }
}
