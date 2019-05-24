using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerController : MonoBehaviour
{
    public static AudioClip beerOpen, woosh, glassBreak, horn, suckUp;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        beerOpen = Resources.Load<AudioClip>("sounds/beerOpen");
        woosh = Resources.Load<AudioClip>("sounds/woosh");
        glassBreak = Resources.Load<AudioClip>("sounds/glassBreak");
        horn = Resources.Load<AudioClip>("sounds/horn");
        suckUp = Resources.Load<AudioClip>("sounds/suckUp");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "beerOpen":
                audioSrc.PlayOneShot(beerOpen);
                break;
            case "woosh":
                audioSrc.PlayOneShot(woosh);
                break;
            case "glassBreak":
                audioSrc.PlayOneShot(glassBreak);
                break;
            case "horn":
                audioSrc.PlayOneShot(horn);
                break;
            case "suckUp":
                audioSrc.PlayOneShot(suckUp);
                break;
        }
    }
}
