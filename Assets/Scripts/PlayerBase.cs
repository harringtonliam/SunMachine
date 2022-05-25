using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] int energy = 20;
    [SerializeField] Text energyTextBox;
    [SerializeField] Text healthTextBox;


    public int Energy
    {
        get { return energy; }
    }

    private void Start()
    {
        if (energyTextBox != null)
        {
            energyTextBox.text = energy.ToString();
        }
    }
        

    public void DecreaseEnergy(int cost)
    {
        energy = energy - cost;
        if (energyTextBox != null)
        {
            energyTextBox.text = energy.ToString();
        }
    }

    public void AddEnergy( int cost)
    {
        energy = energy + cost;
        if (energyTextBox != null)
        {
            energyTextBox.text = energy.ToString();
        }
    }

    public void DisplayHealth(int health)
    {
        if (healthTextBox != null)
        {
            healthTextBox.text = health.ToString();
        }
        
    }

    public int GetHealth()
    {
        return GetComponent<PlayerHealth>().HitPoints;
    }

}
