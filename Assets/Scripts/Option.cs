using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Option : MonoBehaviour
{
    public string Text;
    public Resources Requirements;
    public Resources Result;
    public Event NextEvent;
    public Sprite Background;
    public int Year;
    [SerializeField]
    public Button.ButtonClickedEvent TriggerFunction;

    public void Trigger()
    {
        Debug.Log("Option is triggered");
        if (Year != 0)
            EventManager.Instance.Year.text = "Year: " + Year.ToString();
        if (Background != null)
        {
            EventManager.Instance.Background.sprite = Background;
            EventManager.Instance.SetNextOverlay();
        }
        Village.Instance.ModifyResources(Result);
        if(NextEvent != null )
            NextEvent.Trigger();
    }


    public string ToString()
    {
        string str = Text;
        //     + " (";
        // str += Result.Military == 0 ? "" : $"Military: {Result.Military} ";
        // str += Result.Wealth == 0 ? "" : $"Wealth: {Result.Wealth} ";
        // str += Result.Alliance == 0 ? "" : $"Alliance: {Result.Alliance} ";
        // str += Result.Culture == 0 ? "" : $"Culture: {Result.Culture} ";
        // str += Result.Assimilation == 0 ? "" : $"Assimilation: {Result.Assimilation} ";
        // str += Result.Aggression == 0 ? "" : $"Aggresion: {Result.Aggression} ";
        // str += ")";
        return str;
    }

    public bool isValid()
    {
        Resources villageResources = Village.Instance.CurrentResources;
        return villageResources.Military >= Requirements.Military &&
               villageResources.Wealth >= Requirements.Wealth &&
               villageResources.Alliance >= Requirements.Alliance &&
               villageResources.Culture >= Requirements.Culture &&
               villageResources.Assimilation >= Requirements.Assimilation &&
               villageResources.Aggression >= Requirements.Aggression;
    }

    public List<string> GetMissingResources()
    {
        List<string> result = new List<string>();
        Resources villageResources = Village.Instance.CurrentResources;
        if (villageResources.Military < Requirements.Military)
            result.Add("Military");
        if (villageResources.Wealth < Requirements.Wealth)
            result.Add("Wealth");
        if (villageResources.Alliance < Requirements.Alliance)
            result.Add("Alliance");
        if (villageResources.Culture < Requirements.Culture)
            result.Add("Culture");
        if (villageResources.Assimilation < Requirements.Assimilation)
            result.Add("Assimilation");
        if (villageResources.Aggression < Requirements.Aggression)
            result.Add("Aggression");
        return result;
    }
}
