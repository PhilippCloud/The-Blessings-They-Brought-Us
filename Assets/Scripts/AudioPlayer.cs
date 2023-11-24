using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource Soundtrack;

    // Start is called before the first frame update
    void Start()
    {
        Soundtrack.Play();       
    }

}
