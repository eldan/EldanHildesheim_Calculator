using Microsoft.Maui.Controls.Shapes;

namespace EldanHildesheim_Calculator;

public partial class CalcPart2 : ContentPage
{
  enum Mode { reset, numberTyped1, numberTyped2 }
  Mode mode = Mode.numberTyped1;
  int num1 = 0;
  int num2 = 0;
  string arithmetic = "";
  Label lblScreen;
  public CalcPart2()
	{
		InitializeComponent();

    VerticalStackLayout stackLayout = GetLayout();
    Grid grid = CreateGrid();
    // screen
    grid.Add(CreateScreen());




   // buttons
    Button button1 = CreateButton(grid, "1", 0, 1,Colors.DimGrey, Button_Dig_Clicked);
    Button button2 = CreateButton(grid, "2", 1, 1, Colors.DimGrey, Button_Dig_Clicked);
    Button button3 = CreateButton(grid, "3", 2, 1, Colors.DimGrey, Button_Dig_Clicked);
    Button button4 = CreateButton(grid, "4", 0, 2, Colors.DimGrey, Button_Dig_Clicked);
    Button button5 = CreateButton(grid, "5", 1, 2, Colors.DimGrey, Button_Dig_Clicked);
    Button button6 = CreateButton(grid, "6", 2, 2, Colors.DimGrey, Button_Dig_Clicked);
    Button button7 = CreateButton(grid, "7", 0, 3, Colors.DimGrey, Button_Dig_Clicked);
    Button button8 = CreateButton(grid, "8", 1, 3, Colors.DimGrey, Button_Dig_Clicked);
    Button button9 = CreateButton(grid, "9", 2, 3, Colors.DimGrey, Button_Dig_Clicked);
    Button button0 = CreateButton(grid, "0", 0, 4, Colors.DimGrey, 2, Button_Dig_Clicked);
    Button buttonAdd = CreateButton(grid, "+", 4, 1, Colors.Orange, Button_Action_Clicked);
    Button buttonSub = CreateButton(grid, "-", 4, 2, Colors.Orange, Button_Action_Clicked);
    Button buttonMult = CreateButton(grid, "*", 4, 3, Colors.Orange, Button_Action_Clicked);
    Button buttonDev = CreateButton(grid, "/", 4, 4, Colors.Orange, Button_Action_Clicked);
    Button buttonRes = CreateButton(grid, "=", 0, 5, Colors.Green,4, Button_Equal_Clicked);
    Button buttonErase = CreateButton(grid, "Clear", 2, 4, Colors.Red, Button_Clear_Clicked);
    stackLayout.Add(grid);
  
    this.Content = stackLayout;

    
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

      }
      else
      {
        num2 = typeNum + num2 * 10;
      }

      lblScreen.Text += typeNum.ToString();


    }

  }
  private void Button_Action_Clicked(object sender, EventArgs e)
  {
    if (mode == Mode.numberTyped1)
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
    float total = 0;
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

    lblScreen.Text += "=" + total.ToString();
    num1 = 0;
    num2 = 0;
    mode = Mode.reset;
  }


  private void Button_Clear_Clicked(object sender, EventArgs e)
  {
    lblScreen.Text = "";
    num1 = 0;
    num2 = 0;
    mode = Mode.reset;
  }
  private VerticalStackLayout GetLayout()
  {
    VerticalStackLayout stackLayout = new VerticalStackLayout
    {
      Spacing = 20,
      BackgroundColor = Colors.Black,
    };
    return stackLayout;
  }
  private Grid CreateGrid() {
    Grid grid = new Grid
    {
      Margin = new Thickness(20),
      Padding = new Thickness(20),
      BackgroundColor = Color.FromArgb("#333333"),
      ColumnSpacing = 10,
      RowSpacing = 10
    };
    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });

    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
    return grid;
  }


  private Button CreateButton(Grid ggrid, String str, int col, int row, Color c, EventHandler onClick)
  {

    Button button = new Button
    {
      Text = str,
      FontSize = 80,
      TextColor = Colors.White,
      BackgroundColor = c,
      BorderColor = Color.FromArgb("#80000000"),
      BorderWidth = 8,
      CornerRadius = 10,
      VerticalOptions = LayoutOptions.Center
    };

    ggrid.SetRow(button, row);
    ggrid.SetColumn(button, col);
    button.Clicked += onClick;//חחח
    ggrid.Add(button);
    return button;
  }
  private Button CreateButton(Grid ggrid, String str, int col, int row, Color c, int colspan, EventHandler onClick)
  {
    Button button = CreateButton(ggrid,str,col,row,c, onClick);
    Grid.SetColumnSpan(button, colspan);
    return button;
  }

  private Border CreateScreen()
  {
    Label lclLblScreenn = new Label
    {
      Padding = 20,
      BackgroundColor = Color.FromArgb("#7b9389"),
      FontFamily = "Digital",
      FontSize = 100,
      HorizontalOptions = LayoutOptions.End,
      HorizontalTextAlignment = TextAlignment.End,
      TextColor = Color.FromArgb("#1c1812"),

      
    };
    this.lblScreen = lclLblScreenn;

    Border border = new Border
    {
      Padding = 10,
      BackgroundColor = Color.FromArgb("#7b9389"),
      HorizontalOptions = LayoutOptions.Fill,
      Stroke = Color.FromArgb("#80000000"),
      StrokeThickness = 8,
      StrokeShape = new RoundRectangle
      {
        CornerRadius = new CornerRadius(10)
      },
      Content = lclLblScreenn
    };

    Grid.SetRow(border, 0);
    Grid.SetColumn(border, 0);
    Grid.SetColumnSpan(border, 4);
    return border;
  }
}
