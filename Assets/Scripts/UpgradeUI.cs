using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private Upgrade _upgrade;
    [SerializeField] private TextMeshProUGUI costAmount;
    [SerializeField] private TextMeshProUGUI upgradeName;

    private void OnEnable()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        upgradeName.text = _upgrade.upgradeName + " Lv. " + _upgrade.GetCurrentLevel();
        costAmount.text = _upgrade.GetCurrentCost().ToString();
    }
}
