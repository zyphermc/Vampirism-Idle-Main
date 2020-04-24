using UnityEngine;
using UnityEngine.UI;

public class labor_arrowBehavior : MonoBehaviour
{
    //Object References
    public LaborManager LaborManager;

    //Buttons
    public Button wood_arrowLeft;

    public Button wood_arrowRight;
    public Button stone_arrowLeft;
    public Button stone_arrowRight;

    public AmountButton AmountButton;

    //Number variables
    private int amount;

    // Update is called once per frame
    private void Update()
    {
        if (AmountButton.amountIndex == 6)
        {
            amount = (int)LaborManager.fledgelings_available;
        }
        else
        {
            amount = AmountButton.amountNumber;
        }

        /* Update arrow states */

        //Update Wood arrows
        if (LaborManager.fledgelings_used_wood - amount < 0 || LaborManager.field_selected_wood == true || LaborManager.fledgelings_used_wood == 0)
        {
            wood_arrowLeft.interactable = false;
        }
        else
        {
            wood_arrowLeft.interactable = true;
        }

        if (amount > LaborManager.fledgelings_available || LaborManager.field_selected_wood == true || LaborManager.fledgelings_available == 0)
        {
            wood_arrowRight.interactable = false;
        }
        else
        {
            wood_arrowRight.interactable = true;
        }

        //Update Stone arrows
        if (LaborManager.fledgelings_used_stone - amount < 0 || LaborManager.field_selected_stone == true || LaborManager.fledgelings_used_stone == 0)
        {
            stone_arrowLeft.interactable = false;
        }
        else
        {
            stone_arrowLeft.interactable = true;
        }

        if (amount > LaborManager.fledgelings_available || LaborManager.field_selected_stone == true || LaborManager.fledgelings_available == 0)
        {
            stone_arrowRight.interactable = false;
        }
        else
        {
            stone_arrowRight.interactable = true;
        }
    }

    //On click
    public void add_fledgeling_wood()
    {
        LaborManager.fledgelings_used_wood += amount;
    }

    public void subtract_fledgeling_wood()
    {
        if (AmountButton.amountIndex == 6)
        {
            amount = (int)LaborManager.fledgelings_used_wood;
        }
        else
        {
            amount = AmountButton.amountNumber;
        }

        LaborManager.fledgelings_used_wood -= amount;
    }

    public void add_fledgeling_stone()
    {
        LaborManager.fledgelings_used_stone += amount;
    }

    public void subtract_fledgeling_stone()
    {
        if (AmountButton.amountIndex == 6)
        {
            amount = (int)LaborManager.fledgelings_used_stone;
        }
        else
        {
            amount = AmountButton.amountNumber;
        }

        LaborManager.fledgelings_used_stone -= amount;
    }
}