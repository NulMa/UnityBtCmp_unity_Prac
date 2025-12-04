using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalcBtn : MonoBehaviour{

    public CalcPanel calcPanel;
    public string btnValue;
    public bool isNum;

    Button btn;


    void Start(){
        btn = GetComponent<Button>();

        if (btnValue == "blank") {
            GetComponentInChildren<TextMeshProUGUI>().text = "";
            btn.interactable = false;
        }
        else
            GetComponentInChildren<TextMeshProUGUI>().text = btnValue;

    }

    public void BtnClick() {
        if (btnValue == "blank" || btnValue == null)// do nothing, blank button
            return;


        if (isNum) { // do number input
            calcPanel.calcPanel.text += btnValue;
        }
        else {  // do operation calculation
            if (btnValue == "=") {
                calcPanel.Temp2 = int.Parse(calcPanel.calcPanel.text.Split(' ')[2]);
                int result = 0;
                string operation = calcPanel.calcPanel.text.Split(' ')[1];
                switch (operation) {
                    case "+":
                        result = calcPanel.Temp1 + calcPanel.Temp2;
                        break;
                    case "-":
                        result = calcPanel.Temp1 - calcPanel.Temp2;
                        break;
                    case "*":
                        result = calcPanel.Temp1 * calcPanel.Temp2;
                        break;
                    case "/":
                        result = calcPanel.Temp1 / calcPanel.Temp2;
                        break;
                }
                calcPanel.calcPanel.text = result.ToString();
                return;
            }
            else if (btnValue == "C") {     //reset calc
                calcPanel.calcPanel.text = "";
                calcPanel.isTemp1 = true;
                calcPanel.Temp1 = 0;
                calcPanel.Temp2 = 0;
                return;
            }

                calcPanel.Temp1 = int.Parse(calcPanel.calcPanel.text);
            calcPanel.calcPanel.text = calcPanel.calcPanel.text + " " + btnValue + " ";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
