using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    [TextArea]
    public string Text;
    public List<Option> Options;

    void Awake()
    {
        Options = GetComponentsInChildren<Option>().ToList();
    }

    public void Trigger()
    {
        // Remove previous options
        Transform container = EventManager.Instance.OptionContainer;
        int childCount = container.transform.childCount;
        if (childCount > 1)
        {
            for (int i = 1; i < childCount; i++)
            {
                Destroy(container.GetChild(i).gameObject);
            }
        }


        EventManager.Instance.EventText.text = Text;
        GameObject optionTemplate = EventManager.Instance.Option;
        // Check for requirements
        for(int i = 0; i < Options.Count; i++) 
        {
            bool valid = Options[i].isValid();
            string missingResources = "";
            if(!valid)
            {
                missingResources = "(Missing: ";
                List<string> missing = Options[i].GetMissingResources();
                foreach(string resource in missing)
                {
                    missingResources += resource + ", ";
                }
                missingResources += ")";
            }
            GameObject optionObject = Instantiate(optionTemplate, container);
            TextMeshProUGUI optionText = optionObject.GetComponentInChildren<TextMeshProUGUI>();
            optionText.color = valid ? Color.black : Color.grey;
            optionText.text = $"{i+1}.: {Options[i].ToString()} {missingResources}";
            Canvas.ForceUpdateCanvases();
            Vector2 textSize = optionText.GetRenderedValues();
            optionObject.GetComponent<RectTransform>().sizeDelta = new Vector2(textSize.x, textSize.y);
            if(valid)
            {
                Button optionButton = optionObject.GetComponent<Button>();
                optionButton.onClick = Options[i].TriggerFunction;
            }
        }
    }
}
