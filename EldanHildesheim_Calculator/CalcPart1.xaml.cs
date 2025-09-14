using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EldanHildesheim_Calculator;

public partial class CalcPart1 : ContentPage
{
  enum Mode { reset, numberTyped1, numberTyped2}
  Mode mode = Mode.numberTyped1;
  int num1 = 0;
  int num2 = 0;
  string arithmetic="";
	public CalcPart1()
	{
		InitializeComponent();
  }

  private void Button_Dig_Clicked(object sender, EventArgs e)
  {
    if (sender is Button button)
    {
      if (mode == Mode.reset)
      {
        lblScreen.Text = "";
        mode = Mode.numberTyped1;
      }
      int typeNum = int.Parse(button.Text);
      if (mode == Mode.numberTyped1)
      {
        
        num1 = typeNum + num1 * 10;
        
      } else
      {
        num2 = typeNum + num2 * 10;
      }
      
      lblScreen.Text += typeNum.ToString();
      

    }

  }
  private void Button_Action_Clicked(object sender, EventArgs e)
  {
    if (mode==Mode.numberTyped1)
    {
      if (sender is Button button)
      {
        lblScreen.Text += button.Text;
        arithmetic = button.Text;
        mode = mode = Mode.numberTyped2;
      }
    }
  }
  private void Button_Equal_Clicked(object sender, EventArgs e)
  {
    float total=0;
    switch (arithmetic)
    {
      case "+":
        total = num1 + num2;
        break;
      case "-":
        total = num1 - num2;
        break;
      case "*":
        total = num1 * num2;
        break;
      case "/":
        total = (float)(num1) / num2;
        break;
    }
    
    lblScreen.Text += "="+total.ToString();
    num1 = (int)total;
    num2 = 0;
    mode = Mode.numberTyped1;
  }


  private void Button_Clear_Clicked(object sender, EventArgs e)
  {
    lblScreen.Text = "";
    num1 = 0;
    num2 = 0;
    mode = Mode.reset;
  }

}
