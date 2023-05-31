using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;

public class MainMenuMusic : MonoBehaviour
{
    public EventReference inputsound;

    private void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot(inputsound);
    }

}
