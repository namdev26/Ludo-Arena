using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceUI : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public Button rollButton;

    private void Start()
    {
        rollButton.onClick.AddListener(() => DiceRoller.Instance.RollDice());
        DiceRoller.Instance.OnDiceRolled += UpdateResultText;
    }

    private void UpdateResultText (int value)
    {
        resultText.text = value.ToString();
    }
    private void OnDestroy()
    {
        if (DiceRoller.Instance != null)
        {
            DiceRoller.Instance.OnDiceRolled -= UpdateResultText;
        }
    }
}
