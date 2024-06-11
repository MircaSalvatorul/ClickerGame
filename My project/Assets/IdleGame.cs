using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class IdleGame : MonoBehaviour
{
    public TMP_Text coinsText;
    public TMP_Text cpsText;
    public TMP_Text clickValueText;
    public double coins;
    public double cps;

    public double coinsClickValue=1;
    //Upgrades Text, part 1

    public TMP_Text clickup1Text;
    public TMP_Text clickup2Text;
    

    public double clickUpgrade1Cost;
    public double clickUpgrade1Level;

    public double prodUpgrade1Cost;
    public double prodUpgrade1Level;

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
        clickUpgrade1Cost = 20;
        prodUpgrade1Cost = 30;
        clickUpgrade2Cost = 100;
        prodUpgrade2Cost = 100;
        prodUpgrade2Power = 5;
    }



    // Update is called once per frame
    public void Update()
    {
        clickValueText.text = "Click\n+" + coinsClickValue + " Coins";
        cps = prodUpgrade1Level + (prodUpgrade2Power * prodUpgrade2Level);
        cpsText.text = cps + " /s";

        coinsText.text = "Coins: " + coins.ToString("F2");

        clickup1Text.text = "Click Upgrade 1\nCost:" + clickUpgrade1Cost.ToString("F2") + "\nPower +1\nLevel: " +clickUpgrade1Level;
        clickup2Text.text = "Click Upgrade 2\nCost:" + clickUpgrade2Cost.ToString("F2") + "\nPower +5\nLevel: " + clickUpgrade2Level;

        produp1Text.text = "Production Upgrade 1\nCost:" + prodUpgrade1Cost.ToString("F2") + "\nPower +1\nLevel: "+ prodUpgrade1Level;
        produp2Text.text = "Production Upgrade 2\nCost:" + prodUpgrade2Cost.ToString("F2") + "\nPower +" + prodUpgrade2Power + "\nLevel: " + prodUpgrade2Level;


        coins += cps * Time.deltaTime;
    }


    //Buttons
    public void Click()
    {
        coins+= coinsClickValue;
    }

    public void BuyClickUp1()
    {
        if (coins >= clickUpgrade1Cost) {
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
