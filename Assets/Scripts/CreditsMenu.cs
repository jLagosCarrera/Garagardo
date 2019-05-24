using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public void GoToSoundsSource()
    {
        Application.OpenURL("http://soundbible.com/");
    }

    public void GoToMusicSource()
    {
        Application.OpenURL("https://opengameart.org/");
    }

    public void GoToTilesSource()
    {
        Application.OpenURL("https://kenney.itch.io/");
    }
}
