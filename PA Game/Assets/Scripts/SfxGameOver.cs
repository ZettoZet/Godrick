using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxGameOver : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx;

    private void Start()
    {
        PlaySfx();
    }
    public void PlaySfx()
    {
        src.clip = sfx;
        src.Play();
    }
}
