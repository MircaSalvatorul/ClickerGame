using UnityEngine.UI;
using UnityEngine;
using TMPro;
using static System.Math;

public class IdleGame : MonoBehaviour
{
    public TMP_Text coinsText;
    public TMP_Text cpsText;
    public TMP_Text clickValueText;
    public double coins;
    public double cps;

    public double coinsClickValue = 1;
    //Upgrades Text, part 1

    public TMP_Text clickup1Text;
    public TMP_Text clickup2Text;


    public double clickUpgrade1Cost;
    public int clickUpgrade1Level;
    public double clickUpgrade1Power;

    public double prodUpgrade1Cost;
    public int prodUpgrade1Level;
    public double prodUpgrade1Power;

    //Even more upgrades

    public TMP_Text produp1Text;
    public TMP_Text produp2Text;

    public double clickUpgrade2Cost;
    public double clickUpgrade2Power;
    public int clickUpgrade2Level;

    public double prodUpgrade2Cost;
    public int prodUpgrade2Level;
    public double prodUpgrade2Power;

    // Start is called before the first frame update
    public void Start()
    {
        Load();
    }

    //Methods

    public void ClickText(TMP_Text Text, double Cost, int Level, double Power)
    {
        Text.text = "Click Upgrade \nCost:" + Cost.ToString("F2") + "\nPower +" + Power + "\nLevel: " + Level;
    }

    public void ProdText(TMP_Text Text, double cost, int Level, double Power)
    {
        Text.text = "Production Upgrade \nCost:" + cost.ToString("F2") + "\nPower +" + Power + "\nLevel: " + Level;
    }

    public void Notatii(TMP_Text textValue, double numericValue)
    {
        if (numericValue > 1000)
        {
            var exponent = Floor(Log10(Abs(numericValue)));
            var mantissa = numericValue / Pow(10, exponent);
            textValue.text = "Coins: " + mantissa.ToString("F2") + "e" + exponent;
        }
        else
        {
            textValue.text = "Coins" + numericValue.ToString("F2");
        }
    }

    //Saving methods

    public void Load() 
    {
        coins = double.Parse(PlayerPrefs.GetString("coins", "0"));
        clickUpgrade1Cost = double.Parse(PlayerPrefs.GetString("clickUpgrade1Cost", "20"));
        clickUpgrade1Power = double.Parse(PlayerPrefs.GetString("clickUpgrade1Power", "1"));
        prodUpgrade1Cost = double.Parse(PlayerPrefs.GetString("prodUpgrade1Cost", "30"));
        prodUpgrade1Power = double.Parse(PlayerPrefs.GetString("prodUpgrade1Power", "1"));
        clickUpgrade2Cost = double.Parse(PlayerPrefs.GetString("clickUpgrade2Cost", "100"));
        clickUpgrade2Power = double.Parse(PlayerPrefs.GetString("clickUpgrade2Power", "5"));
        prodUpgrade2Cost = double.Parse(PlayerPrefs.GetString("prodUpgrade2Cost", "100"));
        prodUpgrade2Power = double.Parse(PlayerPrefs.GetString("prodUpgrade2Power", "5"));


        prodUpgrade2Level = PlayerPrefs.GetInt("prodUpgrade2Level", 0);
        prodUpgrade1Level = PlayerPrefs.GetInt("prodUpgrade1Level", 0);
        clickUpgrade1Level = PlayerPrefs.GetInt("clickUpgrade1Level", 0);
        clickUpgrade2Level = PlayerPrefs.GetInt("clickUpgrade2Level", 0);
    }

    public void Save()
    {
        PlayerPrefs.SetString("coins", coins.ToString());
        PlayerPrefs.SetString("clickUpgrade1Cost", clickUpgrade1Cost.ToString());
        PlayerPrefs.SetString("clickUpgrade1Power", clickUpgrade1Power.ToString());
        PlayerPrefs.SetString("prodUpgrade1Cost", prodUpgrade1Cost.ToString());
        PlayerPrefs.SetString("prodUpgrade1Power", prodUpgrade1Power.ToString());
        PlayerPrefs.SetString("clickUpgrade2Cost", clickUpgrade2Cost.ToString());
        PlayerPrefs.SetString("clickUpgrade2Power", clickUpgrade2Power.ToString());
        PlayerPrefs.SetString("prodUpgrade2Cost", prodUpgrade2Cost.ToString());
        PlayerPrefs.SetString("prodUpgrade2Power", prodUpgrade2Power.ToString());

        PlayerPrefs.SetInt("prodUpgrade1Level", prodUpgrade1Level);
        PlayerPrefs.SetInt("prodUpgrade2Level", prodUpgrade2Level);
        PlayerPrefs.SetInt("clickUpgrade1Level", clickUpgrade1Level);
        PlayerPrefs.SetInt("clickUpgrade2Level", clickUpgrade2Level);
    }



    // Update is called once per frame
    public void Update()
    {
        clickValueText.text = "Click\n" + coinsClickValue + " Coins";
        cps = prodUpgrade1Level + (prodUpgrade2Power * prodUpgrade2Level);
        cpsText.text = cps + "/s";

        Notatii(coinsText, coins);

        ClickText(clickup1Text, clickUpgrade1Cost, clickUpgrade1Level, clickUpgrade1Power);
        ClickText(clickup2Text, clickUpgrade2Cost, clickUpgrade2Level, clickUpgrade2Power);

        ProdText(produp1Text, prodUpgrade1Cost, prodUpgrade1Level, prodUpgrade1Power);
        ProdText(produp2Text, prodUpgrade2Cost, prodUpgrade2Level, prodUpgrade2Power);

        coins += cps * Time.deltaTime;
        Save();
    }


    //Buttons
    public void Click()
    {
        coins += coinsClickValue;
    }

    public void BuyClickUp1()
    {
        if (coins >= clickUpgrade1Cost)
        {
            clickUpgrade1Level++;
            coins -= clickUpgrade1Cost;
            clickUpgrade1Cost *= 1.07;
            coinsClickValue++;
        }


    }

    public void BuyClickUp2()
    {
        if (coins >= clickUpgrade2Cost)
        {
            clickUpgrade2Level++;
            coins -= clickUpgrade2Cost;
            clickUpgrade2Cost *= 1.1;
            coinsClickValue += 5;
        }


    }


    public void BuyProdUp1()
    {
        if (coins >= prodUpgrade1Cost)
        {
            prodUpgrade1Level++;
            coins -= prodUpgrade1Cost;
            prodUpgrade1Cost *= 1.07;
        }
    }

    public void BuyProdUp2()
    {
        if (coins >= prodUpgrade2Cost)
        {
            prodUpgrade2Level++;
            coins -= prodUpgrade2Cost;
            prodUpgrade2Cost *= 1.07;
        }
    }
}