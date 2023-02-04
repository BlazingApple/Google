using BlazingApple.Google.Services.Reviews;
using BlazingApple.Google.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Google.Pages;

/// <summary>Main index page.</summary>
public partial class Index : ComponentBase
{
    private IReadOnlyList<GoogleReview>? _reviews;

    /// <summary>The API Key to send in the outgoing Google request.</summary>
    [Parameter]
    public string? ApiKey { get; set; }

    /// <summary>The Google place Id to retrieve.</summary>
    [Parameter]
    public string? PlaceId { get; set; }

    /// <summary>
    ///     This is the primary service used to interact with Google's REST API. Normally, you'd want this on the server, not the client, so as not to
    ///     expose any keys.
    /// </summary>
    [Inject]
    private ReviewService ReviewService { get; set; } = null!;

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await GetTweets();
    }

    private async Task GetTweets()
    {
        if (ApiKey is not null && PlaceId is not null)
        {
            _reviews = (IReadOnlyList<GoogleReview>?)await ReviewService.GetReviewsAsync(PlaceId, ApiKey);
        }
    }
}
