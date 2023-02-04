using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Places.Details.Response;

namespace BlazingApple.Google.Shared
{
	/// <summary><see cref="Review" /></summary>
	public partial class GoogleReview
	{
		/// <summary>
		///     aspects contains a collection of AspectRating objects, each of which provides a rating of a single attribute of the establishment. The
		///     first object in the collection is considered the primary aspect.
		/// </summary>
		public virtual Aspect Aspect { get; set; }

		/// <summary>Name of the user who submitted the review. Anonymous reviews are attributed to "A Google user".</summary>
		public virtual string AuthorName { get; set; }

		/// <summary>The URL to the users Google+ profile, if available.</summary>
		public virtual string AuthorUrl { get; set; }

		/// <summary>Time the time that the review was submitted, measured in the number of seconds since since midnight, January 1, 1970 UTC.</summary>
		public virtual DateTime DateTime { get; set; }

		/// <summary>
		///     Language an IETF language code indicating the language used in the user's review. This field contains the main language tag only, and
		///     not the secondary tag indicating country or region. For example, all the English reviews are tagged as 'en', and not 'en-AU' or
		///     'en-UK' and so on.
		/// </summary>
		public virtual string Language { get; set; }

		/// <summary>The url to the photo.</summary>
		public virtual string ProfilePhotoUrl { get; set; }

		/// <summary>Rating the user's overall rating for this place. This is a whole number, ranging from 1 to 5.</summary>
		public virtual double Rating { get; set; }

		/// <summary>The relative time, in human language description.</summary>
		public virtual string RelativeTime { get; set; }

		/// <summary>
		///     Text contains the user's review. When reviewing a location with Google Places, text reviews are considered optional; therefore, this
		///     field may by empty.
		/// </summary>
		public virtual string Text { get; set; }

		internal int TimeInt
		{
			get => DateTime.DateTimeToUnixTimestamp();
			set => DateTime = DateTimeExtension.epoch.AddSeconds(value);
		}

		/// <summary>Default constructor.</summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		public GoogleReview()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		{ }

		/// <summary>Copy constructor.</summary>
		/// <param name="review"><see cref="Review" /></param>
		public GoogleReview(Review review)
		{
			Aspect = review.Aspect;
			AuthorName = review.AuthorName;
			AuthorUrl = review.AuthorUrl;
			Language = review.Language;
			Rating = review.Rating;
			Text = review.Text;
			ProfilePhotoUrl = review.ProfilePhotoUrl;
			RelativeTime = review.RelativeTime;
			DateTime = review.DateTime;
		}

		/// <summary>Convert this <see cref="GoogleReview" /> to a <see cref="Review" /></summary>
		/// <returns><see cref="Review" /></returns>
		public Review ToReview()
		{
			return new Review()
			{
				Aspect = Aspect,
				AuthorName = AuthorName,
				AuthorUrl = AuthorUrl,
				Language = Language,
				Rating = Rating,
				Text = Text,
				ProfilePhotoUrl = ProfilePhotoUrl,
				RelativeTime = RelativeTime,
				DateTime = DateTime,
			};
		}

		/// <summary>Convert back from <see cref="GoogleReview" /> to <see cref="Review" /></summary>
		/// <param name="d"></param>
		public static implicit operator Review(GoogleReview d) => d.ToReview();

		/// <summary>Implicitly convert <see cref="Review" /> to <see cref="GoogleReview" /></summary>
		/// <param name="b"></param>
		public static implicit operator GoogleReview(Review b) => new GoogleReview(b);
	}
}
