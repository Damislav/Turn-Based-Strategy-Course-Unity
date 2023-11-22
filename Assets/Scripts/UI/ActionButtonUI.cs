using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] Button button;
    [SerializeField] private GameObject selectedGameObject;

    private BaseAction baseAction;


    public void SetBaseAction(BaseAction baseAction)
    {
        this.baseAction = baseAction;
        textMeshPro.text = baseAction.GetActionName().ToUpper();

        button.onClick.AddListener(() =>
        {
            //code
            UnitActionSystem.Instance.SetSelectedAction(baseAction);

        });
    }
    public void UpdateSelectedVisual()
    {
        BaseAction selectedBaseAction = UnitActionSystem.Instance.GetSelectedAction();

        selectedGameObject.SetActive(selectedBaseAction == baseAction);
    }
}
