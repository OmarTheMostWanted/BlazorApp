using Microsoft.AspNetCore.Components;
using WebApp.Components;

namespace WebApp.Pages;

public partial class Calculator
{
    [Parameter] public double? Result { get; set; }
    [Parameter] public EventCallback<double?> ResultChanged { get; set; }

    private string _input = "default";

    [Parameter] public string? X { get; set; }
    [Parameter] public string? Y { get; set; }


    private bool _settingX = true;
    private bool _settingY;


    private async void HandleClickNumber(char arg)
    {
        if (_settingX)
        {
            X += arg;

            try
            {
                double x = Convert.ToDouble(X);
                
                Console.WriteLine($"X set to {X}");
            }
            catch (FormatException formatException)
            {
                X = "";
                _settingX = true;
                _settingY = false;
            }
        }
        else if (_settingY)
        {
            Y += arg;
            Console.WriteLine($"Y set to {Y}");
        }

        if (X is null | Y is null) return;
        _input = X + "()" + Y;
    }

    private void HandleClickOp(char arg)
    {
    }


    private void Clear()
    {
        X = null;
        Y = null;

        _settingX = true;
        _settingY = false;

        Console.WriteLine("Input Cleared");
    }
}