using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFX : MonoBehaviour
{
    [SerializeField] ParticleSystem bombFX;

    private void Start()
    {
        bombFX.Play();
    }
}
