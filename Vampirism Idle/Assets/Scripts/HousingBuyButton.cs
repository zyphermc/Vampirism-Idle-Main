using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NumberShortening;

public class HousingBuyButton : MonoBehaviour
{
    public GameManager GameManager;
    public HousingManager HousingManager;
    public AmountButton AmountButton;
    public Button buyButton;
    public ShortenNumber sn = new ShortenNumber();
    public TextMeshProUGUI textbox_buy_amount;
    public TextMeshProUGUI textbox_buy_cost;

    public int descSwitch; //0 for vampire related, 1 for human related
    public int housing_infoNum;
    public bool buyable;
    public int amount;

    // Update is called once per frame
    void Update()
    {
        amount = AmountButton.amountNumber;
        textbox_buy_amount.text = "Build " + amount;

        if(descSwitch == 0)
        {
            //Check if buyable
            if((GameManager.res_Wood >= (HousingManager.vamp_housing_buildingCost_wood[housing_infoNum]) * amount) && (GameManager.res_Stone >= (HousingManager.vamp_housing_buildingCost_stone[housing_infoNum]) * amount))
            {
                buyable = true;
                buyButton.interactable = true;
            }
            else
            {
                buyable = false;
                buyButton.interactable = false;
            }

            //Update Buy Button Text
            textbox_buy_cost.text = sn.shortenNumber((HousingManager.vamp_housing_buildingCost_wood[housing_infoNum] * amount), sn.shortenMethod, 2) + " wood" + " - "
            + sn.shortenNumber((HousingManager.vamp_housing_buildingCost_stone[housing_infoNum] * amount), sn.shortenMethod, 2) + " stone";
        }
        else if(descSwitch == 1)
        {
            //Check if buyable
            if ((GameManager.res_Wood >= (HousingManager.human_housing_buildingCost_wood[housing_infoNum]) * amount) && (GameManager.res_Stone >= (HousingManager.human_housing_buildingCost_stone[housing_infoNum]) * amount))
            {
                buyable = true;
                buyButton.interactable = true;
            }
            else
            {
                buyable = false;
                buyButton.interactable = false;
            }

            //Update Buy Button Text
            textbox_buy_cost.text = (HousingManager.human_housing_buildingCost_wood[housing_infoNum] * amount) + " wood" + " - "
            + (HousingManager.human_housing_buildingCost_stone[housing_infoNum] * amount) + " stone";
        }
        
    }

    public void buyBuilding()
    {
        if(buyable == true)
        {
            if(descSwitch == 0)
            {
                GameManager.res_Wood -= HousingManager.vamp_housing_buildingCost_wood[housing_infoNum] * amount;
                GameManager.res_Stone -= HousingManager.vamp_housing_buildingCost_stone[housing_infoNum] * amount;
                HousingManager.vamp_housing_buildingAmount[housing_infoNum] += amount;
            }else 
            
            if(descSwitch == 1)
            {
                GameManager.res_Wood -= HousingManager.human_housing_buildingCost_wood[housing_infoNum] * amount;
                GameManager.res_Stone -= HousingManager.human_housing_buildingCost_stone[housing_infoNum] * amount;
                HousingManager.human_housing_buildingAmount[housing_infoNum] += amount;
            }
        }
    }
}
