using GoogleApi.Entities.Places.Details.Response;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Google.Components;

/// <summary>Shows a list of <see cref="ReviewCard" /></summary>
public partial class ReviewCarousel : ComponentBase
{
	/// <summary>The list of <see cref="Review" /> to render.</summary>
	[Parameter, EditorRequired]
	public IReadOnlyList<Review>? Reviews { get; set; }
}
