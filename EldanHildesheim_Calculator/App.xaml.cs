namespace EldanHildesheim_Calculator
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
      return new Window(new CalcPart2());
    }
  }
}
