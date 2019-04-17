using UnityEngine;

public class BiteButton : MonoBehaviour
{
    public GameManager GameManager;
    public VampireManager VampireManager;

    public void biteHuman()
    {
        if (GameManager.res_HumanPop > 0)
        {
            VampireManager.vampires_amount_Total[0] += 1;
            GameManager.res_HumanPop -= 1;
        }
    }
}