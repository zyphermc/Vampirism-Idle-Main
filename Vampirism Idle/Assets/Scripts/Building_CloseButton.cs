using UnityEngine;

public class Building_CloseButton : MonoBehaviour
{
    public HousingManager HousingManager;
    public HousingDescription HousingDescription;
    public int descSwitch;

    private void Update()
    {
        descSwitch = HousingDescription.descSwitch;
    }

    private void Close()
    {
        if(descSwitch == 0)
        {
            HousingManager.vamp_housing_infoNum = -1;
        }
        else
        if(descSwitch == 1)
        {
            HousingManager.human_housing_infoNum = -1;
        }
        
    }
}