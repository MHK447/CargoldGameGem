using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BanpoFri;

[EffectPath("Effect/DamageTextEffect", false, true)]
public class PirceTextEffect : Effect
{
    [SerializeField]
    private Animator ani;
    [SerializeField]
    private Text text;


    public void SetText(string _text)
    {
        text.text = _text;
        ani.Play("Damage_Critical");
    }
}
