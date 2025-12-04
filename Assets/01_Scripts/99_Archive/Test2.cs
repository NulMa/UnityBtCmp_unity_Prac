using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Test2 : MonoBehaviour{
    public TextMeshProUGUI userDisplay;
    public TextMeshProUGUI numBtn;

    public int number;
    public string FirstNum;
    public string SecondNum;

    public bool isFirstNum = true;

    public enum CalcState {
        Add,
        Sub,
        Mul,
        Div,
        Reset
    }

    public void NumberClick(int input) { //click Event
        if (number == 9999)
            return;
        number = input;


        if (number >= 0 && number <= 9) {
            if (isFirstNum) {
                FirstNum = FirstNum + number;
                userDisplay.text = "Your Input is :\n" + FirstNum;
            }
            else {
                SecondNum = SecondNum + number;
                userDisplay.text = "Your Input is :\n" + SecondNum;
            }
        }
        else {
            CalcFunc();
        }

    }

    public void CalcFunc() {

        switch (number) {
            case -99:
                isFirstNum = true;
                userDisplay.text = "Calc is Reset";
                FirstNum = SecondNum = "";
                break;

            default:
                isFirstNum = false;
                userDisplay.text = userDisplay.text + numBtn.text;
                break;
        }
    }

    void Start() {
        if (numBtn == null)
            return;


        ButtonNum();
    }

    void Update() {

    }

    public void ButtonNum() {   //Set Button Text
        switch (number) {
            case 9999:
                numBtn.text = " ";
                break;

            case -99:
                numBtn.text = "C";
                break;

            case -98:
                numBtn.text = "+";
                break;

            case -97:
                numBtn.text = "-";
                break;

            case -96:
                numBtn.text = "*";
                break;

            case -95:
                numBtn.text = "/";
                break;

            case -94:
                numBtn.text = "=";
                break;


            default:
                numBtn.text = number.ToString();
                break;
        }
    }
}
