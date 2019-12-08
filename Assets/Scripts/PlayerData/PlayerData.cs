using UnityEngine;

public class PlayerData : MonoBehaviour {
    [System.NonSerialized]
    public int HighScore, CurrentHighest;
    [SerializeField]
    private int _money;
    public int Money {
        get => _money;
        set {
            _money = value;
            if (_money < 0)
                _money = 0;
            ChangedMoney?.Invoke(this, _money);
        }
    }
    public event System.Action<PlayerData, int> ChangedMoney;

    private void Awake() {
        CurrentHighest = 0;
        Money = Money;
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public bool Use(int money) {
        int amount = Money - money;
        if (amount < 0) return false;
        Money = amount;
        return true;
    }
}
