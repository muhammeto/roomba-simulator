using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoombaCleaning : MonoBehaviour
{
    [SerializeField] private Image tankCapacityUI; 
    [SerializeField] private List<GameObject> garbages;
    
    private float tankCapacity;
    private int currentCapacity = 0;

    public float TankCapacity { get => tankCapacity; set => tankCapacity = value; }
    public int CurrentCapacity { get => currentCapacity; set => currentCapacity = value; }

    private void OnEnable()
    {
        tankCapacityUI.fillAmount = currentCapacity / tankCapacity;

        for (int i = 0; i < garbages.Count; i++)
        {
            garbages[i].SetActive(true);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Garbage") && currentCapacity < tankCapacity)
        {
            currentCapacity++;
            tankCapacityUI.fillAmount = currentCapacity / tankCapacity;
            hit.gameObject.SetActive(false);
        }
    }
}
