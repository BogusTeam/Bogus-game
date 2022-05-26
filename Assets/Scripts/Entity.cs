using UnityEngine;

public class Entity : MonoBehaviour
{
    public TargetTypes type;
    public TriggerTypes triggerType;
    public int healthPoints = 100;
    public int attackRating;
    public int armorRating;
    public int accuracyRating;

    public int cameraPos = 1;
    public int moneyToSet;

    // private void OnApplicationPause(bool pauseStatus)
    // {
        // gameObject.SetActive(!gameObject.activeSelf);
    // }

    void Start()
    {
        switch (type)
        {
            case TargetTypes.Player:
                gameObject.AddComponent<Player>();
                break;
            case TargetTypes.Follower:
                gameObject.AddComponent<FollowerPlayer>();
                break;
            case TargetTypes.Enemy:
                gameObject.AddComponent<Enemy>();
                break;
            case TargetTypes.Camera:
                gameObject.AddComponent<CameraMovement>();
                break;
            case TargetTypes.Trigger:
                gameObject.AddComponent<Trigger>();
                break;
        }
    }
}