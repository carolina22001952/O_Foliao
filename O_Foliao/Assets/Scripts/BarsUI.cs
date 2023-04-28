using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarsUI : MonoBehaviour
{
    [SerializeField]
    private Slider alcoolSlider;
    [SerializeField]
    private Gradient alcoolGradient;
    [SerializeField]
    private Image alcoolFill;

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

    private AnimationStatus animStatus;


    public void SetMaxAllBars(int maxAlcool, int maxFun,
                              int maxEnergy, int money)
    {
        alcoolSlider.maxValue = maxAlcool;

        funSlider.maxValue = maxFun;


        energySlider.maxValue = maxEnergy;

        SetValueAllBars();
    }

    public void SetValueAllBars(int alcool = 0, int fun = 50,
                                int energy = 100, int money = 100)
    {
        alcoolSlider.value = alcool;
        alcoolFill.color = alcoolGradient.Evaluate(alcoolSlider.value);

        //animStatus.ChangeEnergySize();

        funSlider.value = fun;
        funFill.color = funGradient.Evaluate(funSlider.value);

        energySlider.value = energy;
        energyFill.color = energyGradient.Evaluate(energySlider.value);

        moneyText.text = money.ToString() + "€";
    }



}
