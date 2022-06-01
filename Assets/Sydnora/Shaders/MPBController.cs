using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPBController : MonoBehaviour
{
    private MaterialPropertyBlock mpb;

    public MaterialPropertyBlock Mpb => mpb;

    private void Start()
    {
        mpb = new MaterialPropertyBlock();
    }
}
