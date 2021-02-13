using TMPro;
using UnityEngine;

public class RoombaController : MonoBehaviour
{
    [SerializeField] private GameObject ingameUI, shopUI;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private RoombaStats stats;
    [SerializeField] private UpgradeUI[] upgradesUI;
    private Vector3 startPos;
    private Quaternion startRot;
    private RoombaMovement _movement;
    private RoombaCleaning _cleaning;
    private void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        _movement = GetComponent<RoombaMovement>();
        _cleaning = GetComponent<RoombaCleaning>();
        UpdateStats();
    }

    public void OpenShopUI()
    {
        stats.money += _cleaning.CurrentCapacity * 25;
        _movement.enabled = false;
        _cleaning.enabled = false;
        ingameUI.SetActive(false);
        shopUI.SetActive(true);
        moneyText.text = stats.money.ToString();
    }

    public void CloseShopUI()
    {
        shopUI.SetActive(false);
        ingameUI.SetActive(true);
        _movement.enabled = true;
        _cleaning.enabled = true;
    }

    public void StartAgain()
    {
        transform.position = startPos;
        transform.rotation = startRot;
        UpdateStats();
        CloseShopUI();
    }

    public void UpgradeStat(string upgradeName)
    {
        if (stats.CanUpgrade(upgradeName))
        {
            stats.UpgradeByName(upgradeName);
            moneyText.text = stats.money.ToString();
            for (int i = 0; i < upgradesUI.Length; i++)
            {
                upgradesUI[i].UpdateUI();
            }
        }
        else
        {
            print("Can't upgrade: " + upgradeName);
        }
    }

    private void UpdateStats()
    {
        _movement.MaxPower = stats.GetValueByName("Battery");
        _movement.CurrentPower = _movement.MaxPower;

        _movement.PowerConsMultiplier = stats.GetValueByName("Efficiency");
        _movement.MoveSpeed = stats.GetValueByName("Speed");
        _movement.TurnSpeed = stats.GetValueByName("Turn Speed");

        _cleaning.TankCapacity = stats.GetValueByName("Dust Tank");
        _cleaning.CurrentCapacity = 0;
    }
}
