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
                _input = X;
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
                _input += _op + Y;
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

        _input = X + _op;
    }


    private void Clear()
    {
        X = null;
        Y = null;
        _op = null;
        _settingX = true;
        _settingY = false;
        _input = "";
    }
}