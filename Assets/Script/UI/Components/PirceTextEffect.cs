using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BanpoFri;

[EffectPath("Effect/PirceTextEffect", true , false)]
public class PirceTextEffect : Effect
{
    [SerializeField]
    private Animator ani;
    [SerializeField]
    private Text text;


    private string[] AniStrList = { "Damage_01", "Damage_02" , "Damage_03" , "Damage_Critical" };

    public void SetText(string _text)
    {
        this.transform.SetParent(GameRoot.Instance.MainCanvas.transform);

        text.text = _text;
        var randvalue = Random.Range(0, AniStrList.Length);

        ani.Play("Damage_01", 0, 0f);

        //ani.Play(AniStrList[randvalue], 0, 0f);
    }
}
