using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BiteButton : MonoBehaviour //Local
{
    public GameManager GameManager;
    public VampireManager VampireManager;
    public HousingManager HousingManager;
    public Button button_biteButton;
    public TextMeshProUGUI textBox_biteButton;
    public StatisticsWindow StatisticsWindow;

    private bool cooldown = false;
    private float cooldownTime = 2f;

    public void BiteHuman()
    {
        if (GameManager.res_HumanPop > 0)
        {
            VampireManager.vampires_amount_Total[0] += 1;
            GameManager.res_HumanPop -= 1;
            StartCoroutine("BiteCooldown");
            StatisticsWindow.AddEvent("A human is bitten. +1 " + VampireManager.vampires_name[0]);
            cooldown = true;
        }
    }

    IEnumerator BiteCooldown()
    {
        GameManager.cooldownTick = (int)cooldownTime+1;
        button_biteButton.interactable = false;

        while (true)
        {
            GameManager.cooldownTick--;

            if(GameManager.cooldownTick <= 0)
            {
                cooldown = false;
                button_biteButton.interactable = true;
                StopCoroutine("BiteCooldown");
            }

            yield return new WaitForSeconds(1f);
        }
        
    }

    private void Update()
    {
        if(cooldown == false)
        {
            textBox_biteButton.text = "Bite";

            if(HousingManager.housing_amountAvailable <= 0)
            {
                button_biteButton.interactable = false;
            }
            else
            {
                button_biteButton.interactable = true;
            }
        }
        else
        {
            textBox_biteButton.text = GameManager.cooldownTick + "s";
        }
        
    }
}