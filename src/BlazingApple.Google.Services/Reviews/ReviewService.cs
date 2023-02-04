using BlazingApple.Google.Shared;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Response;
using Microsoft.Extensions.Logging;

namespace BlazingApple.Google.Services.Reviews;

/// <summary>Retrieves</summary>
public class ReviewService
{
	private readonly GooglePlaces.DetailsApi _client;
	private readonly ILogger<ReviewService> _logger;

	/// <summary>DI Constructor</summary>
	public ReviewService(GooglePlaces.DetailsApi client, ILogger<ReviewService> logger)
	{
		_client = client;
		_logger = logger;
	}

	/// <summary>Get business details from Google.</summary>
	/// <param name="placeId">The identifier for the desired place/business.</param>
	/// <param name="apiKey">API Key for Google</param>
	/// <param name="cancellationToken"><see cref="CancellationToken" /></param>
	/// <returns><see cref="DetailsResult" /></returns>
	public async Task<DetailsResult?> GetBusinessDetails(string placeId, string apiKey, CancellationToken cancellationToken = default)
	{
		cancellationToken.ThrowIfCancellationRequested();

		PlacesDetailsRequest request = new()
		{
			Key = apiKey,
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
	/// <param name="apiKey">API Key for Google</param>
	/// <param name="cancellationToken"><see cref="CancellationToken" /></param>
	/// <returns></returns>
	public async Task<IEnumerable<GoogleReview>?> GetReviewsAsync(string placeId, string apiKey, CancellationToken cancellationToken = default)
	{
		cancellationToken.ThrowIfCancellationRequested();

		PlacesDetailsRequest request = new()
		{
			Key = apiKey,
			PlaceId = placeId,
		};

		PlacesDetailsResponse response = await _client.QueryAsync(request, cancellationToken);

		if (response.Status != Status.Ok)
		{
			_logger.LogWarning("Google Places Response status was not Ok, result was {status}.", response.Status);
			return null;
		}

		return Convert(response.Result.Review);
	}

	/// <summary>Get up to 5 reviews from Google about a business/place.</summary>
	/// <param name="request"><see cref="PlacesDetailsRequest" /></param>
	/// <param name="cancellationToken"><see cref="CancellationToken" /></param>
	/// <returns></returns>
	public async Task<IEnumerable<GoogleReview>?> GetReviewsAsync(PlacesDetailsRequest request, CancellationToken cancellationToken = default)
	{
		cancellationToken.ThrowIfCancellationRequested();

		PlacesDetailsResponse response = await _client.QueryAsync(request, cancellationToken);

		if (response.Status != Status.Ok)
		{
			_logger.LogWarning("Google Places Response status was not Ok, result was {status}.", response.Status);
			return null;
		}
		return Convert(response.Result.Review);
	}

	private static IEnumerable<GoogleReview> Convert(IEnumerable<Review> reviews)
	{
		foreach (Review review in reviews)
			yield return new GoogleReview(review);
	}
}
