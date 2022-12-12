using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Response;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Google.Services.Reviews;

/// <summary>Retrieves</summary>
public class ReviewRetrievalService
{
    private readonly GooglePlaces.DetailsApi _client;
    private readonly ILogger _logger;
    private readonly GoogleSettings _settings;

    /// <summary>DI Constructor</summary>
    public ReviewRetrievalService(GooglePlaces.DetailsApi client, ILogger logger, IOptions<GoogleSettings> settings)
    {
        _client = client;
        _logger = logger;
        _settings = settings.Value;
    }

    /// <summary>Get business details from Google.</summary>
    /// <param name="placeId">The identifier for the desired place/business.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" /></param>
    /// <returns><see cref="DetailsResult" /></returns>
    public async Task<DetailsResult?> GetBusinessDetails(string placeId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        PlacesDetailsRequest request = new()
        {
            Key = _settings.ApiKey,
            PlaceId = placeId,
        };

        PlacesDetailsResponse response = await _client.QueryAsync(request, cancellationToken);

        if (response.Status != Status.Ok)
        {
            _logger.LogWarning("Google Places Response status was not Ok, result was {status}.", response.Status);
            return null;
        }
        else
        {
            return response.Result;
        }
    }

    /// <summary>Get up to 5 reviews from Google about a business/place.</summary>
    /// <param name="placeId">The placeId for the business</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" /></param>
    /// <returns></returns>
    public async Task<IReadOnlyList<Review>?> GetReviewsAsync(string placeId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        PlacesDetailsRequest request = new()
        {
            Key = _settings.ApiKey,
            PlaceId = placeId,
        };

        PlacesDetailsResponse response = await _client.QueryAsync(request, cancellationToken);

        if (response.Status != Status.Ok)
        {
            _logger.LogWarning("Google Places Response status was not Ok, result was {status}.", response.Status);
            return null;
        }
        return response.Result.Review.ToList();
    }
}
