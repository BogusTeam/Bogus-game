using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public GameObject moneyText;
    public GameObject heroHp;
    public LocationNames locationName = LocationNames.StartingLocation;

    private int _money;
    private int _heroHp;

    public int Money
    {
        get => _money;
        set
        {
            _money = value;
            moneyText.GetComponent<Text>().text = $"Деньги: {value}";
        }
    }

    public int HeroHP
    {
        get => _heroHp;
        set
        {
            _heroHp = value;
            heroHp.GetComponent<Text>().text = $"ХП героя: {value}";
        }
    }
}