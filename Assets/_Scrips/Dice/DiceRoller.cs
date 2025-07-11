using System;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public static DiceRoller Instance { get; private set; }
    public event Action<int> OnDiceRolled;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RollDice()
    {
        int result = UnityEngine.Random.Range(1, 7);
        OnDiceRolled?.Invoke(result);
    }
}
