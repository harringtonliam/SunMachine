using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUIButton : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] Towers towers;

    private void Start()
    {
        Text text = GetComponentInChildren<Text>();
        text.text = towerPrefab.Cost.ToString();
    }

    public void TowerSelected()
    {
        towers.TowerPrefab = towerPrefab;

        SetSelectButtonColor();

    }

    private void SetSelectButtonColor()
    {
        TowerUIButton[] towerUIButtons = FindObjectsOfType<TowerUIButton>();
        foreach (var towerUIButton in towerUIButtons)
        {
            GameObject uiButtonGameObject = towerUIButton.gameObject;
            Button uiButton = uiButtonGameObject.GetComponent<Button>();
            uiButton.image.color = Color.white;
        }
        Button button = gameObject.GetComponent<Button>();
        button.image.color = Color.yellow;
    }
}
