using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public GameObject moneyText;
    public GameObject heroHp;
    public LocationNames locationName = LocationNames.StartingLocation;

    private int _money;

    public int Money
    {
        get => _money;
        set
        {
            _money = value;
            moneyText.GetComponent<Text>().text = $"Деньги: {value}";
        }
    }
}