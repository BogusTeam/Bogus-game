using UnityEngine;

public class Trigger : MonoBehaviour
{
    public TriggerTypes triggerType;
    public int money;
    public string dialogName;
    public GameObject linkedObject;
    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        var script = gameObject.GetComponent<Entity>();
        triggerType = script.triggerType;
        money = script.moneyToSet;
        dialogName = script.dialogNameToSet;
        linkedObject = script.linkedObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name} triggered on trigger {name}!");
        var script = other.gameObject.GetComponent<Entity>();
        if (script == null || script.type != TargetTypes.Player)
            return;

        if (triggered)
            return;
        triggered = true;

        switch (triggerType)
        {
            case TriggerTypes.Money:
                Utils.GetStatsScript()!.Money += money;
                Destroy(linkedObject);
                break;
            case TriggerTypes.Dialog:
                var scriptD = Utils.GetDialogsScript();
                var dialogs = Utils.GetDialogs(dialogName);
                scriptD!.dialogs = dialogs;
                Utils.CreateDialogPanel(dialogs);
                break;
            case TriggerTypes.Fight:
                break;
            case TriggerTypes.Teleport:
                break;
        }
    }
}