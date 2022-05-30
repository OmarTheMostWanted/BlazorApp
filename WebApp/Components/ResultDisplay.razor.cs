using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Components;

public partial class ResultDisplay
{
    [Parameter] public double? Result { get; set; } = 0;
    [Parameter] public EventCallback<double?> ResultChanged { get; set; }
}