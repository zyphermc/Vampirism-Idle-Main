[System.Serializable]
public class PlayerData
{
    /// <summary>
    /// Data to do:
    /// VampireManager
    /// Slider values
    /// EfficiencyUpgrades
    /// HousingManager
    /// LaborManager
    ///
    /// Done:
    /// GameManager
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

    #endregion Vampires [VampireManager & Slider Values & Efficiency Upgrades]

    #endregion Data Variables

    public PlayerData(GameManager gameManager, VampireManager vampireManager, EfficiencyUpgrades efficiencyUpgrades)
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
        }

        #endregion Vampire Data
    }
}