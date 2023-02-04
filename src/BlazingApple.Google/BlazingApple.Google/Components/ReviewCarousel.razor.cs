using BlazingApple.Google.Shared;
using GoogleApi.Entities.Places.Details.Response;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Google.Components;

/// <summary>Shows a list of <see cref="ReviewCard" /></summary>
public partial class ReviewCarousel : ComponentBase
{
	/// <summary>The list of <see cref="Review" /> to render.</summary>
	[Parameter, EditorRequired]
	public IReadOnlyList<GoogleReview>? Reviews { get; set; }

	/// <summary>If true, show the previous and next navigation buttons.</summary>
	[Parameter]
	public bool ShowPrevNextButtons { get; set; }
}
