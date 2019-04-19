using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BiteButton : MonoBehaviour //Local
{
    public GameManager GameManager;
    public VampireManager VampireManager;
    public Button button_biteButton;
    public TextMeshProUGUI textBox_biteButton;

    private bool cooldown = false;

    public void BiteHuman()
    {
        if (GameManager.res_HumanPop > 0)
        {
            VampireManager.vampires_amount_Total[0] += 1;
            GameManager.res_HumanPop -= 1;
            StartCoroutine("BiteCooldown");
            cooldown = true;
        }
    }

    IEnumerator BiteCooldown()
    {
        GameManager.cooldownTick = 11;
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
        }
        else
        {
            textBox_biteButton.text = GameManager.cooldownTick + "s";
        }
        
    }
}