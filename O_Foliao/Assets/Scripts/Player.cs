using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxAlcohol = 100;
    [SerializeField]
    private int maxFun = 100;
    [SerializeField]
    private int maxEnergy = 100;

    [SerializeField]
    private int alcohol = 0;
    [SerializeField]
    private int fun = 50;
    [SerializeField]
    private int energy = 100;

    [SerializeField]
    private int money;
    [SerializeField]
    private GameObject position;
    [SerializeField]
    private SceneChanger scene;
    [SerializeField]
    private BarsUI bars;

    private void Start()
    {
        bars.SetMaxAllBars(maxAlcohol, maxFun, maxEnergy, money);
    }

    public int GetAllStats()
    {
        return this.alcohol;
    }


    public void ChangeStats(Player player, int alcohol = 0, int fun = 0,
                            int money = 0, int energy = 0)
    {
        player.alcohol += alcohol;
        player.fun += fun;
        player.money += money;
        player.energy += energy;

        if (player.alcohol > maxAlcohol)
        {
            player.alcohol = maxAlcohol;
        }
        if (player.fun > maxFun)
        {
            player.fun = maxFun;
        }

        if (player.energy > maxEnergy)
        {
            player.energy = maxEnergy;
        }

        if (player.alcohol < 0)
        {
            player.alcohol = 0;
        }
        if (player.fun < 0)
        {
            player.fun = 0;
        }
        if (player.energy < 0)
        {
            player.energy = 0;
        }
        if (player.money < 0)
        {
            player.money = 0;
        }

        bars.SetValueAllBars(player.alcohol, player.fun,
                             player.energy, player.money);
        if (player.alcohol == 100)
        {
            scene.DeathAlcool();
        }
        else if (player.energy == 0)
        {
            scene.DeathEnergy();
        }

    }

    public void ChangePosition(GameObject position)
    {
        this.position = position;
    }

    public int GetAlcohol()
    {
        return this.alcohol;
    }

    public int GetEnergy()
    {
        return this.energy;
    }
    public int GetFun()
    {
        return this.fun;
    }

    public int GetMoney()
    {
        return this.money;
    }

    public GameObject Position()
    {
        return this.position;
    }
}

