using UnityEngine;


public class Game : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Movement move;
    [SerializeField] private Node node;
    [SerializeField] private Clock clock;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private QuestSystem questSystem;
    [SerializeField] private TimedEventsSystem timedEventsSystem;


    private void Start()
    {
        move.TakeMovementInput();
    }

    private Events randomEvent;
    private void Update()
    {
        if (clock.GetDay() >= 3)
        {
            sceneChanger.Win();
        }   

        if(player.GetEnergy() <= 0)
        {
            sceneChanger.DeathEnergy();
        }
        if(player.GetAlcohol() >= 100)
        {
            sceneChanger.DeathAlcool();
        }
    }

    public void CheckForInteraction()
    {
        if (player.Position().GetComponent<ILocal>() is ILocal)
        {
            player.Position().GetComponent<ILocal>().localInteraction(player, clock);
        }
        player.Position().GetComponent<Node>().NodeSound();
    }
    public void CheckForTimedEvents()
    {
        timedEventsSystem.CheckForTimedEvents();
    }

    public void CheckForQuestTimers()
    {
        questSystem.CheckForQuestTimers();
    }

    public void CheckForFailingQuests()
    {
        questSystem.EndFailedTimedQuets();
    }
    public void StartMovement()
    {
        CheckForTimedEvents();
        CheckForQuestTimers();
        CheckForFailingQuests();
        move.TakeMovementInput();

    }


}
