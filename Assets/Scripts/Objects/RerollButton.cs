using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RerollButton : MonoBehaviour
{
    public MagicType type;
    public float coinsRequired;
    public TextMeshProUGUI myText;
    public Color canBuyColor;
    public Color cantBuyColor;

    public static event Action onUpdateReroll;
    private void Awake()
    { 
        onUpdateReroll += UpdateReroll;
    }

    private void OnDestroy()
    {
        onUpdateReroll -= UpdateReroll;
    }

    public void Reroll()
    {
        if (PlayerStats.coins < coinsRequired) return;
        
        PlayerStats.coins -= coinsRequired;
        PlayerSpellCasting.Instance.RerollMagic(type);
        HUDManager.Instance.UpdateCoins();
        onUpdateReroll?.Invoke();
        
    }

    public void UpdateReroll()
    {
        myText.text = coinsRequired.ToString("F0");

        if (PlayerStats.coins < coinsRequired)
        {
            myText.color = cantBuyColor;
        }
        else myText.color = canBuyColor;
    }
}
