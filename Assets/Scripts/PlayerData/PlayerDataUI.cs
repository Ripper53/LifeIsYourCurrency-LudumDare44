using GameEngine;
using TMPro;

public class PlayerDataUI : Entity<PlayerDataUI> {
    public PlayerData PlayerData;
    public TextMeshProUGUI ScoreText;

    protected override void Init() {
        PlayerData.ChangedMoney += PlayerData_ChangedMoney;
    }

    private void PlayerData_ChangedMoney(PlayerData arg1, int arg2) {
        ScoreText.text = arg2.ToString();
    }

    protected override void Destroyed() {
        PlayerData.ChangedMoney -= PlayerData_ChangedMoney;
    }
}
