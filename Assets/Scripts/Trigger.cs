using UnityEngine;

public class Trigger : MonoBehaviour
{
    public TriggerTypes triggerType;
    public int money;
    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        var script = gameObject.GetComponent<Entity>();
        triggerType = script.triggerType;
        money = script.moneyToSet;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name} triggered!");
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
                break;
            case TriggerTypes.Dialog:
                break;
            case TriggerTypes.Fight:
                break;
            case TriggerTypes.Teleport:
                break;
        }
    }
}