using UnityEngine;
using UnityEngine.UI;
using GameEngine;
using TMPro;

public class ShipUI : Entity<ShipUI> {
    public Ship Ship;
    public PlayerMovementControls PlayerMovementControls;
    public GameObject GameOver, TurnOff;
    public TextMeshProUGUI ScoreText, HighScoreText;
    public Image Image, WaitImage;
    public Sprite Heart, Lungs, Liver, Intestines;

    protected override void Init() {
        Ship.ChangedType += Ship_ChangedType;
    }

    private void Ship_ChangedType(Ship arg1, BodyPart.Type arg2) {
        Image.enabled = false;
        switch (arg2) {
            case BodyPart.Type.HEART:
                Image.sprite = Heart;
                break;
            case BodyPart.Type.LUNGS:
                Image.sprite = Lungs;
                break;
            case BodyPart.Type.LIVER:
                Image.sprite = Liver;
                break;
            case BodyPart.Type.INTESTINES:
                Image.sprite = Intestines;
                break;
        }
    }

    public void CheckIfBankruptViaAnimation() {
        if (Ship.PlayerData.Money <= 0) {
            if (PlayerMovementControls != null) {
                Destroy(PlayerMovementControls);
                int currentHighest = Ship.PlayerData.CurrentHighest, alltimeHighest = Ship.PlayerData.HighScore;
                if (currentHighest > alltimeHighest) {
                    alltimeHighest = currentHighest;
                    PlayerPrefs.SetInt("HighScore", alltimeHighest);
                }
                ScoreText.text = currentHighest.ToString();
                HighScoreText.text = alltimeHighest.ToString();
            }
            TurnOff.SetActive(false);
            GameOver.SetActive(true);
        }
    }

    public void EnableImageViaAnimation() {
        Image.enabled = true;
    }

    protected override void Destroyed() {
        Ship.ChangedType -= Ship_ChangedType;
    }
}
