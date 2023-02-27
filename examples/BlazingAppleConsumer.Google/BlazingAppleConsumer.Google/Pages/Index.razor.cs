using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Google.Pages;

/// <summary>Main index page.</summary>
public partial class Index : ComponentBase
{
    /// <summary>The API Key to send in the outgoing Google request.</summary>
    public string? ApiKey { get; set; }

    /// <summary>The Google place Id to retrieve.</summary>
    public string? PlaceId { get; set; }


}
