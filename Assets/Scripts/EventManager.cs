using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get { return instance; } }
    public Transform OptionContainer;
    public TextMeshProUGUI EventText;
    public GameObject Option;
    public Event FirstEvent;
    public Image Background;
    public TextMeshProUGUI Year;
    public Image Overlay;
    public GameObject[] Overlays;

    private static EventManager instance;
    private int overlayIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        FirstEvent.Trigger();
    }


    // Update is called once per frame
    void Update()
    {
        if (!Overlays[overlayIndex].activeSelf || overlayIndex == Overlays.Length - 1)
            return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetMouseButtonDown(0))
        {
            Overlays[overlayIndex].SetActive(false);
            if (Overlays[overlayIndex].name == "Startscreen" || overlayIndex >= 8)
                SetNextOverlay();
        }
    }

    public void SetNextOverlay() {
        Debug.Log("SetNextOverlay");
        overlayIndex++;
        Overlays[overlayIndex].SetActive(true);
    }
}
