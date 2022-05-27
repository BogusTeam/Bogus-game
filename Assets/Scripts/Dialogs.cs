using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogs : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject prefabFor1Action;
    public GameObject prefabFor2Actions;
    public GameObject prefabFor3Actions;
    public DialogList dialogs;
    public bool inDialog;
    public bool haveKassit;

    public void CreateDialogFor1Action(Dialog dialog)
    {
        var prefab = Instantiate(prefabFor1Action, dialogPanel.transform);
        prefab.transform.SetParent(dialogPanel.transform);
        prefab.transform.GetChild(1).gameObject.GetComponent<Text>().text = dialog.author;
        prefab.transform.GetChild(2).gameObject.GetComponent<Text>().text = dialog.authorDialog;
        prefab.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text =
            dialog.choices[0].choice;
        prefab.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (dialog.choices[0].quitGame)
                Application.Quit();
            if (dialog.choices[0].money > 0)
                Utils.GetStatsScript()!.Money += dialog.choices[0].money;
            if (dialog.chooseKassit && dialog.choices[0].isKassitWithUs)
                haveKassit = true;
            Utils.CreateDialogPanel(dialogs,
                haveKassit ? dialog.choices[0].nextIdWithKassit : dialog.choices[0].nextIdWithoutKassit);
            Destroy(prefab);
        });
    }

    public void CreateDialogFor2Actions(Dialog dialog)
    {
        var prefab = Instantiate(prefabFor2Actions, dialogPanel.transform);
        prefab.transform.SetParent(dialogPanel.transform);
        prefab.transform.GetChild(1).gameObject.GetComponent<Text>().text = dialog.author;
        prefab.transform.GetChild(2).gameObject.GetComponent<Text>().text = dialog.authorDialog;
        for (var i = 0; i < 2; i++)
        {
            var index = i;
            prefab.transform.GetChild(3 + i).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text =
                dialog.choices[i].choice;
            prefab.transform.GetChild(3 + i).gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (dialog.choices[index].quitGame)
                    Application.Quit();
                if (dialog.choices[index].money > 0)
                    Utils.GetStatsScript()!.Money += dialog.choices[index].money;
                if (dialog.chooseKassit && dialog.choices[index].isKassitWithUs)
                    Utils.GetDialogsScript()!.haveKassit = true;
                Utils.CreateDialogPanel(dialogs,
                    haveKassit ? dialog.choices[index].nextIdWithKassit : dialog.choices[index].nextIdWithoutKassit);
                Destroy(prefab);
            });
        }
    }

    public void CreateDialogFor3Actions(Dialog dialog)
    {
        var prefab = Instantiate(prefabFor3Actions, dialogPanel.transform);
        prefab.transform.SetParent(dialogPanel.transform);
        prefab.transform.GetChild(1).gameObject.GetComponent<Text>().text = dialog.author;
        prefab.transform.GetChild(2).gameObject.GetComponent<Text>().text = dialog.authorDialog;
        for (var i = 0; i < 3; i++)
        {
            var index = i;
            prefab.transform.GetChild(3 + i).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text =
                dialog.choices[i].choice;
            prefab.transform.GetChild(3 + i).gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (dialog.choices[index].quitGame)
                    Application.Quit();
                if (dialog.choices[index].money > 0)
                    Utils.GetStatsScript()!.Money += dialog.choices[index].money;
                if (dialog.chooseKassit && dialog.choices[index].isKassitWithUs)
                    Utils.GetDialogsScript()!.haveKassit = true;
                Utils.CreateDialogPanel(dialogs,
                    haveKassit ? dialog.choices[index].nextIdWithKassit : dialog.choices[index].nextIdWithoutKassit);
                Destroy(prefab);
            });
        }
    }
}