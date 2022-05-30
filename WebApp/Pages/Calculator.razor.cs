using Microsoft.AspNetCore.Components;
using WebApp.Components;

namespace WebApp.Pages;

public partial class Calculator
{
    [Parameter] public double? Result { get; set; }
    [Parameter] public EventCallback<double?> ResultChanged { get; set; }

    [Parameter] public string? InputC { get; set; } 
    [Parameter] public EventCallback<string?> InputCChanged { get; set; }


    [Parameter] public string? X { get; set; }
    [Parameter] public string? Y { get; set; }

    [Inject] private Client Client { get; init; } = default;


    private bool _settingX = true;
    private bool _settingY;

    private string? _op = null;


    private async void HandleClickNumber(string arg)
    {
        if (_settingX)
        {
            double x = 0;
            try
            {
                x = Convert.ToDouble(X + arg);
            }
            catch (FormatException formatException)
            {
                X = "";
                _settingX = true;
                _settingY = false;
            }

            if (await Client.SetX(x))
            {
                X += arg;
                InputC = X;
            }
        }
        else if (_op is not null && _settingY)
        {
            double y = 0;
            try
            {
                y = Convert.ToDouble(Y + arg);
            }
            catch (FormatException formatException)
            {
                Y = "";
                _settingX = false;
                _settingY = true;
            }

            if (await Client.SetY(y))
            {
                Y += arg;
                InputC += _op + Y;
            }
        }
    }

    private async void HandleClickOp(string arg)
    {
        if (X is null) return;

        if (arg.Length != 1) return;

        if (!await Client.SetOp(Convert.ToChar(arg))) return;

        _op = arg;
        _settingX = false;
        _settingY = true;

        InputC = X + _op;
    }

    private async void Res()
    {
        if (X is not null && Y is not null && _op is not null)
        {
            var res = await Client.Calculate();
            Result = res;
        }
        
    }

    private void Clear()
    {
        X = null;
        Y = null;
        _op = null;
        _settingX = true;
        _settingY = false;
        InputC = "";
        Result = 0;
    }
}