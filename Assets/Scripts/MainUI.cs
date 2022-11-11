using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI nbCoinsText;
    private int nbCoins;

    public TextMeshProUGUI CoinsLVLText;
    public TextMeshProUGUI TimerLVLText;
    public TextMeshProUGUI SpeedLVLText;

    public TextMeshProUGUI CoinsPriceText;
    public TextMeshProUGUI TimerPriceText;
    public TextMeshProUGUI SpeedPriceText;

    int CoinsLVL;
    int TimerLVL;
    int SpeedLVL;

    int initialPrice = 10;
    int CoinsPrice;
    int TimerPrice;
    int SpeedPrice;


    private void Awake()
    {
        RefreshUpgradeScreenAndData();
    }

    //public int UpgradeCost(int UpgradeLVL)
    //{
    //}
    private enum Upgrade
    {
        CoinUpgrade = 1,
        TimerUpgrade = 2,
        SpeedUpgrade = 3
    }
    public void BuyUpgrade()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        print("Nom du boutton détecté : " + ButtonName);

        if (ButtonName.Equals(Upgrade.CoinUpgrade.ToString()))
            UpgradeCoins();
        else if (ButtonName.Equals(Upgrade.TimerUpgrade.ToString()))
            UpgradeTimer();
        else if (ButtonName.Equals(Upgrade.SpeedUpgrade.ToString()))
            UpgradeSpeed();
        else
            print("Erreur : Ce boutton est inconnu.   Il faut le paramètrer dans MainUI.cs -> BuyUpgrade()");

    }
    private void UpgradeCoins()
    {
        if (HaveEnoughMoney(CoinsPrice))
        {
            PlayerPrefs.SetInt("CoinsLVL", CoinsLVL + 1);
            PlayerPrefs.SetInt("nbCoins", nbCoins - CoinsPrice);
            RefreshUpgradeScreenAndData();
        }
    }

    private void UpgradeSpeed()
    {
        if (HaveEnoughMoney(SpeedPrice))
        {
            PlayerPrefs.SetInt("SpeedLVL", SpeedLVL + 1);
            PlayerPrefs.SetInt("nbCoins", nbCoins - SpeedPrice);
            print(PlayerPrefs.GetInt("SpeedLVL", 0));
            RefreshUpgradeScreenAndData();
        }

    }

    private void UpgradeTimer()
    {
        if (HaveEnoughMoney(TimerPrice))
        {
            PlayerPrefs.SetInt("TimerLVL", TimerLVL + 1);
            PlayerPrefs.SetInt("nbCoins", nbCoins - TimerPrice);
            RefreshUpgradeScreenAndData();
        }

    }

    private bool HaveEnoughMoney(int Cost)
    {
        if (Cost > nbCoins)
            return false;
        else
            return true;
    }

    private void RefreshUpgradeScreenAndData()
    {
        print(SpeedLVL + " " + SpeedPrice);
        print("player prefab : " + PlayerPrefs.GetInt("SpeedLVL", 0));
        // Screen 1
        nbCoinsText.text = PlayerPrefs.GetInt("nbCoins", 0).ToString();

        CoinsLVLText.text = "LVL " + PlayerPrefs.GetInt("CoinsLVL", 0).ToString();
        TimerLVLText.text = "LVL " + PlayerPrefs.GetInt("TimerLVL", 0).ToString();
        SpeedLVLText.text = "LVL " + PlayerPrefs.GetInt("SpeedLVL", 0).ToString();
        
        // Data 1
        nbCoins = PlayerPrefs.GetInt("nbCoins", 0);

        CoinsLVL = PlayerPrefs.GetInt("CoinsLVL", 0);
        TimerLVL = PlayerPrefs.GetInt("TimerLVL", 0);
        SpeedLVL = PlayerPrefs.GetInt("SpeedLVL", 0);

        // Screen 2 (Need Data 1)
        CoinsPriceText.text = CalculPrice(CoinsLVL).ToString();
        TimerPriceText.text = CalculPrice(TimerLVL).ToString();
        SpeedPriceText.text = CalculPrice(SpeedLVL).ToString();

        // Data 2
        CoinsPrice = CalculPrice(CoinsLVL);
        TimerPrice = CalculPrice(TimerLVL);
        SpeedPrice = CalculPrice(SpeedLVL);

        print("refresh end : " + SpeedLVL + " " + SpeedPrice);
    }
    private int CalculPrice(int ActualLVL)
    {
        // Le cout d'une amélioration augmentera de +10 tous les 10 niveaux :   ex :    lvl 5->6 (+10 par rapport à 4->5)        lvl 14 -> 15 (+20 par rapport à 13->14)     lvl 35->36 (+40 par rapport à 34->35)   etc ...
        int scaleCost = (int)(float.Parse(ActualLVL.ToString()) / 10f) + 1;
        //print(scaleCost);
        if (ActualLVL == 0)
            return initialPrice;
        else
            return initialPrice * (ActualLVL + 1) * scaleCost;
    }
}
