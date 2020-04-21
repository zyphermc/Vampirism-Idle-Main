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

    public float res_Blood;
    public float res_HumanPop;
    public float res_Wood;
    public float res_Stone;

    #endregion Resources

    #region Vampires [VampireManager]

    #endregion

    #endregion Data Variables

    public PlayerData(GameManager GameManager)
    {
        #region Resources

        res_Blood = (float)GameManager.res_Blood;
        res_HumanPop = (float)GameManager.res_HumanPop;
        res_Wood = (float)GameManager.res_Wood;
        res_Stone = (float)GameManager.res_Stone;

        #endregion Resources
    }
}