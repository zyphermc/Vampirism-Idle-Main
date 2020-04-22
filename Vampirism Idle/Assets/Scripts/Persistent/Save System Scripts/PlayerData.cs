[System.Serializable]
public class PlayerData
{
    /// <summary>
    /// Data to do:
    /// LaborManager
    ///
    /// </summary>

    #region Data Variables

    #region Resources [GameManager]

    public double res_Blood;
    public double res_HumanPop;
    public double res_Wood;
    public double res_Stone;

    #endregion Resources [GameManager]

    #region Vampires [VampireManager & Slider Values & Efficiency Upgrades]

    public double[] vampires_amount_Total = new double[10];
    public bool[] vampires_unlocked = new bool[10];

    public float[] slider_savedMaxValueFeed = new float[10];
    public float[] slider_savedMaxValueInfect = new float[10];
    public int[] slider_usedFeed = new int[10];
    public int[] slider_usedInfect = new int[10];

    public int[] level_SharpenFang = new int[10];
    public int[] level_TrainAgility = new int[10];

    #endregion Vampires [VampireManager & Slider Values & Efficiency Upgrades]

    #region Housing [HousingManager]

    public double[] vamp_housing_buildingAmount = new double[10];
    public double[] human_housing_buildingAmount = new double[10];

    #endregion Housing [HousingManager]

    #region Labor [LaborManager]

    public double fledgelings_used_wood;
    public double fledgelings_used_stone;

    #endregion Labor [LaborManager]

    #endregion Data Variables

    public PlayerData(GameManager gameManager, VampireManager vampireManager, EfficiencyUpgrades efficiencyUpgrades, HousingManager housingManager, LaborManager laborManager)
    {
        //Data is commented for easy tracing and readability

        #region Resources

        res_Blood = gameManager.res_Blood; //Blood
        res_HumanPop = gameManager.res_HumanPop; //Human Population
        res_Wood = gameManager.res_Wood; //Wood
        res_Stone = gameManager.res_Stone; //Stone

        #endregion Resources

        #region Vampire Data

        for (int a = 0; a < 10; a++)
        {
            vampires_amount_Total[a] = vampireManager.vampires_amount_Total[a]; //Amount of total vampires of each tier
            vampires_unlocked[a] = vampireManager.vampires_unlocked[a]; //State of the lock for vampire buttons in Lair Tab

            slider_savedMaxValueFeed[a] = vampireManager.slider_savedMaxValueFeed[a]; //Saved max slider value of feed of each vampire window
            slider_savedMaxValueInfect[a] = vampireManager.slider_savedMaxValueInfect[a]; //Saved max slider value of infect of each vampire window
            slider_usedFeed[a] = vampireManager.slider_usedFeed[a]; //Current allocated slider value of feed
            slider_usedInfect[a] = vampireManager.slider_usedInfect[a]; //Current allocated slider value of infect

            level_SharpenFang[a] = efficiencyUpgrades.level_SharpenFang[a];
            level_TrainAgility[a] = efficiencyUpgrades.level_TrainAgility[a];
        }

        #endregion Vampire Data

        #region Housing

        for (int a = 0; a < 10; a++)
        {
            vamp_housing_buildingAmount[a] = housingManager.vamp_housing_buildingAmount[a];
            human_housing_buildingAmount[a] = housingManager.human_housing_buildingAmount[a];
        }

        #endregion Housing

        #region Labor

        fledgelings_used_wood = laborManager.fledgelings_used_wood;
        fledgelings_used_stone = laborManager.fledgelings_used_stone;

        #endregion Labor
    }
}