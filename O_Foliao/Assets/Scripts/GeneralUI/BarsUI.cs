using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarsUI : MonoBehaviour
{
    [SerializeField]
    private Slider alcoholSlider;
    [SerializeField]
    private Gradient alcoholGradient;
    [SerializeField]
    private Image alcoholFill;

    [SerializeField]
    private Slider funSlider;
    [SerializeField]
    private Gradient funGradient;
    [SerializeField]
    private Image funFill;

    [SerializeField]
    private Slider energySlider;
    [SerializeField]
    private Gradient energyGradient;
    [SerializeField]
    private Image energyFill;
    [SerializeField]
    private TextMeshProUGUI moneyText;

    [SerializeField]
    private AnimationStatus animStatus;
    
    public void SetMaxAllBars(int maxAlcohol, int maxFun,
                              int maxEnergy, int money)
    {
        alcoholSlider.maxValue = maxAlcohol;

        funSlider.maxValue = maxFun;


        energySlider.maxValue = maxEnergy;

        SetValueAllBars();
    }

    public void SetValueAllBars(int alcohol = 0, int fun = 50,
                                int energy = 100, int money = 100)
    {
        
        //alcoolFill.color = alcoolGradient.Evaluate(alcoolSlider.value);
        if(alcoholSlider.value != alcohol)
        {
            animStatus.ChangeAlcoholSize();
        }
        alcoholSlider.value = alcohol;
    
        //funFill.color = funGradient.Evaluate(funSlider.value);
        if(funSlider.value != fun)
        {
            animStatus.ChangeFunSize();
        }
        funSlider.value = fun;

        
        //energyFill.color = energyGradient.Evaluate(energySlider.value);
        if(energySlider.value != energy)
        {
            animStatus.ChangeEnergySize();
        }
        energySlider.value = energy;

        moneyText.text = money.ToString() + "€";
    }



}
