using BlazingApple.Google.Shared;
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
    private string _imgStyle = "";

    /// <summary><see cref="Review" /></summary>
    [Parameter, EditorRequired]
    public GoogleReview? Review { get; set; }

    private void OnImageLoadFail()
    {
        _imgStyle = "display: none;";
        StateHasChanged();
    }
}
