using NumberShortening;
using System.Collections;
using TMPro;
using UnityEngine;

public class LaborManager : MonoBehaviour
{
    /* Object references */

    //Managers
    public GameManager GameManager;

    public VampireManager VampireManager;
    public labor_resourceIncome labor_resourceIncome;

    //Textboxes
    public TextMeshProUGUI text_income_wood;

    public TextMeshProUGUI text_income_stone;
    public TextMeshProUGUI text_fledgelings_used_wood;
    public TextMeshProUGUI text_fledgelings_used_stone;
    public TextMeshProUGUI text_fledgelings_available;

    //----------------------------------------------------

    //Fledgeling Amount Variables
    [HideInInspector] public double fledgelings_available;

    [HideInInspector] public double fledgelings_used_wood;
    [HideInInspector] public double fledgelings_used_stone;
    [HideInInspector] public double fledgelings_used_total;

    private double income_wood; //per second
    private double income_stone;

    private ShortenNumber sn = new ShortenNumber();

    private void Start()
    {
        fledgelings_used_wood = 0;
        fledgelings_used_stone = 0;

        StartCoroutine("UpdateLaborResources");
    }

    // Update is called once per frame
    private void Update()
    {
        //Update amount of available fledgelings
        fledgelings_available = VampireManager.vampires_amount_Available_Total[0];
        fledgelings_used_total = fledgelings_used_wood + fledgelings_used_stone;

        income_wood = labor_resourceIncome.get_wood_income(fledgelings_used_wood);
        income_stone = labor_resourceIncome.get_stone_income(fledgelings_used_stone);

        //Update Texts
        text_income_wood.text = "Wood/s: " + sn.shortenNumber(income_wood, sn.shortenMethod, 2);
        text_income_stone.text = "Stone/s: " + sn.shortenNumber(income_stone, sn.shortenMethod, 2);
        text_fledgelings_used_wood.text = sn.shortenNumber(fledgelings_used_wood, sn.shortenMethod, 2);
        text_fledgelings_used_stone.text = sn.shortenNumber(fledgelings_used_stone, sn.shortenMethod, 2);
        text_fledgelings_available.text = sn.shortenNumber(fledgelings_available, sn.shortenMethod, 2);
    }

    private IEnumerator UpdateLaborResources()
    {
        while (true)
        {
            GameManager.res_Wood += income_wood;
            GameManager.res_Stone += income_stone;
            yield return new WaitForSeconds(1f);
        }
    }
}