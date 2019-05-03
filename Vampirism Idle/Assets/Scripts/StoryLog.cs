using UnityEngine;

public class StoryLog : MonoBehaviour //Persistent
{
    public GameManager GameManager;
    public HousingManager HousingManager;
    public VampireManager VampireManager;
    public StatisticsWindow StatisticsWindow;
    public NewsTicker NewsTicker;

    //Log Messages (0 = locked, 1 = to be sent, 2 = sent)
    public int Log_WelcomeMessage;

    private void Update()
    {
        //Welcome Message
        if (StatisticsWindow.isActiveAndEnabled && Log_WelcomeMessage == 0)
        {
            Log_WelcomeMessage = 1;
        }
        else
        if (StatisticsWindow.isActiveAndEnabled && Log_WelcomeMessage == 1)
        {
            StatisticsWindow.AddEvent("Welcome to Vampirism Idle!");
            Log_WelcomeMessage = 2;
        }
        /////
    }
}