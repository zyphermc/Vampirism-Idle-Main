using NumberShortening;
using TMPro;
using UnityEngine;

public class HousingDescription : MonoBehaviour
{
    public int housing_infoNum;
    public int descSwitch;
    public HousingManager HousingManager;
    public ShortenNumber sn = new ShortenNumber();

    //global
    public TextMeshProUGUI txt_building_name;

    public TextMeshProUGUI txt_building_amount;

    //variables
    public TextMeshProUGUI txt_building_base;

    public TextMeshProUGUI txt_building_total;

    private void Start()
    {
        housing_infoNum = -1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (housing_infoNum > -1) //if any button is selected
        {
            if (descSwitch == 0) //if vampire housing is selected
            {
                txt_building_name.text = HousingManager.vamp_housing_buildingName[housing_infoNum];
                txt_building_base.text = "Cap (base): " + sn.shortenNumber(HousingManager.vamp_housing_buildingBaseCap[housing_infoNum], sn.shortenMethod, 2);
                txt_building_total.text = "Cap (total): " + sn.shortenNumber(HousingManager.vamp_housing_buildingTotalCap[housing_infoNum], sn.shortenMethod, 2);
                txt_building_amount.text = "Amount: " + sn.shortenNumber(HousingManager.vamp_housing_buildingAmount[housing_infoNum], sn.shortenMethod, 2);
            }
            else

            if (descSwitch == 1)
            {
                txt_building_name.text = HousingManager.human_housing_buildingName[housing_infoNum];
                txt_building_base.text = "Humans/s: " + sn.shortenNumber(HousingManager.human_housing_buildingBaseProduction[housing_infoNum], sn.shortenMethod, 2);
                txt_building_total.text = "Total/s: " + sn.shortenNumber(HousingManager.human_housing_buildingTotalProduction[housing_infoNum], sn.shortenMethod, 2);
                txt_building_amount.text = "Amount: " + sn.shortenNumber(HousingManager.human_housing_buildingAmount[housing_infoNum], sn.shortenMethod, 2);
            }
        }
    }
}