using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class IdleGame : MonoBehaviour
{
    public TMP_Text coinsText;
    public TMP_Text cpsText;
    public double coins;
    public double cps;

    public double coinsClickValue=1;
    //Upgrades Text

    public TMP_Text clickup1Text;
    public TMP_Text produp1Text;

 
    public double clickUpgrade1Cost;
    public double clickUpgrade1Level;

    public double prodUpgrade1Cost;
    public double prodUpgrade1Level;


    // Start is called before the first frame update
    public void Start()
    {
        clickUpgrade1Cost = 20;
        prodUpgrade1Cost = 50;
    }



    // Update is called once per frame
    public void Update()
    {
        cps = prodUpgrade1Level/10;
        cpsText.text = cps + " /s";

        coinsText.text = "Coins: " + coins.ToString("F2");

        clickup1Text.text = "Click Upgrade 1\nCost:" + clickUpgrade1Cost.ToString("F2") + "\nPower +1\nLevel: " +clickUpgrade1Level;
        produp1Text.text = "Production Upgrade 1\nCost:" + prodUpgrade1Cost.ToString("F2") + "\nPower +0.1\nLevel: "+ prodUpgrade1Level;

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


    public void BuyProdUp1()
    {
        if (coins >= prodUpgrade1Cost)
        {
            prodUpgrade1Level++;
            coins -= prodUpgrade1Cost;
            prodUpgrade1Cost *= 1.07;
        }
    }
}
