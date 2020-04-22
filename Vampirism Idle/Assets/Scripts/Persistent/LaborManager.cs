using NumberShortening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

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
    public TMP_InputField text_fledgelings_used_wood;
    public TMP_InputField text_fledgelings_used_stone;
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
        UpdateInputText();
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

    public void UpdateInputText() //updates and shortens numerical text
    {
        text_fledgelings_used_wood.text = sn.shortenNumber(fledgelings_used_wood, sn.shortenMethod, 2);
        text_fledgelings_used_stone.text = sn.shortenNumber(fledgelings_used_stone, sn.shortenMethod, 2);
    }

    #region Customizable Input Field Value Methods

    public double inputValue_Wood;
    public double inputValue_Stone;
    public bool field_selected_wood = false;
    public bool field_selected_stone = false;

    public void UpdateLaborWood() //OnTextValueChange - Input Field
    {
        if (text_fledgelings_used_wood.text == "")
        {
            text_fledgelings_used_wood.text = "0";

            text_fledgelings_used_wood.stringPosition = 1;

            inputValue_Wood = 0;
        }
        else
        {
            inputValue_Wood = double.Parse(text_fledgelings_used_wood.text);
            text_fledgelings_used_wood.text = inputValue_Wood.ToString();

            if (inputValue_Wood > (fledgelings_used_wood + fledgelings_available))
            {
                inputValue_Wood = fledgelings_used_wood + fledgelings_available;
                text_fledgelings_used_wood.text = inputValue_Wood.ToString();
            }
        }
        
    }

    public void UpdateLaborStone() //OnTextValueChange - Input Field
    {
        if (text_fledgelings_used_stone.text == "")
        {
            text_fledgelings_used_stone.text = "0";

            text_fledgelings_used_stone.stringPosition = 1;

            inputValue_Stone = 0;
        }
        else
        {
            inputValue_Stone = double.Parse(text_fledgelings_used_stone.text);
            text_fledgelings_used_stone.text = inputValue_Stone.ToString();

            if (inputValue_Stone > (fledgelings_used_stone + fledgelings_available))
            {
                inputValue_Stone = fledgelings_used_stone + fledgelings_available;
                text_fledgelings_used_stone.text = inputValue_Stone.ToString();
            }
        }
    }

    public void onSelectWood() //elongates the shortened value
    {
        text_fledgelings_used_wood.text = fledgelings_used_wood.ToString();
        field_selected_wood = true;
        
    }

    public void onSelectStone() //elongates the shortened value
    {
        text_fledgelings_used_stone.text = fledgelings_used_stone.ToString();
        field_selected_stone = true;
    }

    public void onDeselectWood() //Update value of woodcutters and textfield
    {
        fledgelings_used_wood = inputValue_Wood;
        text_fledgelings_used_wood.text = fledgelings_used_wood.ToString();


        field_selected_wood = false;
        UpdateInputText();
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void onDeselectStone() //Update value of miners and textfield
    {
        fledgelings_used_stone = inputValue_Stone;
        text_fledgelings_used_stone.text = fledgelings_used_stone.ToString();

        field_selected_stone = false;
        UpdateInputText();
        EventSystem.current.SetSelectedGameObject(null);
    }

    #endregion Customizable Input Field Value Methods
}