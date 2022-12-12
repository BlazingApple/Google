using GoogleApi.Entities.Places.Details.Response;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Google.Components;

/// <summary>Renders a <see cref="Review" /> in card format.</summary>
public partial class ReviewCard : ComponentBase
{
    /// <summary><see cref="Review" /></summary>
    [Parameter, EditorRequired]
    public Review? Review { get; set; }
}
