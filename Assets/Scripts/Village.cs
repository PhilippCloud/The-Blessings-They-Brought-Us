using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Village : MonoBehaviour
{
    public static Village Instance { get { return instance; } }
    public Resources CurrentResources;
    public TextMeshProUGUI MilitaryUI;
    public TextMeshProUGUI WealthUI;
    public TextMeshProUGUI AllianceUI;
    public TextMeshProUGUI CultureUI;
    public TextMeshProUGUI AssimilationUI;
    public TextMeshProUGUI AggressionUI;

    private static Village instance;
    // Traits and Customization

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        UpdateUI();
    }

    internal void ModifyResources(Resources result)
    {
        CurrentResources.Military = Mathf.Max(0, CurrentResources.Military + result.Military);
        CurrentResources.Wealth = Mathf.Max(0, CurrentResources.Wealth + result.Wealth);
        CurrentResources.Alliance = Mathf.Max(0, CurrentResources.Alliance + result.Alliance);
        CurrentResources.Culture = Mathf.Max(0, CurrentResources.Culture + result.Culture);
        CurrentResources.Assimilation = Mathf.Max(0, CurrentResources.Assimilation + result.Assimilation);
        CurrentResources.Aggression = Mathf.Max(0, CurrentResources.Aggression + result.Aggression);
        UpdateUI();
    }

    private void UpdateUI()
    {
        MilitaryUI.text = CurrentResources.Military.ToString();
        WealthUI.text = CurrentResources.Wealth.ToString();
        AllianceUI.text = CurrentResources.Alliance.ToString();
        CultureUI.text = CurrentResources.Culture.ToString();
        AssimilationUI.text = CurrentResources.Assimilation.ToString();
        AggressionUI.text = CurrentResources.Aggression.ToString();
    }
}
