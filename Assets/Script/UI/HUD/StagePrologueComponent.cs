using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagePrologueComponent : MonoBehaviour
{
    [SerializeField]
    private Button HideBtn;

    private System.Action Action;

    private void Awake()
    {
        HideBtn.onClick.AddListener(OnClickHide);
    }


    public void Init(System.Action action)
    {
        Action = action;    
    }
    public void OnClickHide()
    {
        ProjectUtility.SetActiveCheck(this.gameObject, false);
        Action?.Invoke();
    }
}
