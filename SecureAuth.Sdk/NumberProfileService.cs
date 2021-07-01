using System;
using System.Linq;

namespace SecureAuth.Sdk
{
    public class NumberProfileService : INumberProfileService
    {
        private readonly ApiClient _apiClient;
        private string apiVersion = "v2";

        protected internal NumberProfileService(ApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        /// <summary>
        /// Evaluate the provided phone number for carrier status and details.
        /// </summary>
        /// <param name="userId">The unique user ID.</param>
        /// <param name="phoneNumber">The phone number for evaluation.</param>
        /// <returns>NumberProfileResponse</returns>
        public NumberProfileResponse EvaluatePhoneNumber(string userId, string phoneNumber)
        {
            NumberProfileRequest request = new NumberProfileRequest()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            return EvaluatePhoneNumber(request);
        }

        /// <summary>
        /// Evaluate the provided phone number for carrier status and details.
        /// </summary>
        /// <param name="request">NumberProfileRequest object.</param>
        /// <returns>NumberProfileResponse</returns>
        public NumberProfileResponse EvaluatePhoneNumber(NumberProfileRequest request)
        {
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }
            if (string.IsNullOrEmpty(request.PhoneNumber))
            {
                throw new ArgumentNullException("phoneNumber", "Phone Number cannot be empty.");
            }

            return this._apiClient.Post<NumberProfileResponse>("/api/" + apiVersion + "/numberprofile", request);
        }

        /// <summary>
        /// Updates the original carrier information stored for the user and phone number
        /// with the updated current carrier information. Used once the user validates
        /// ownership of the phone number after the carrier change.
        /// </summary>
        /// <param name="userId">The unique user ID</param>
        /// <param name="phoneNumber">The phone number if the record to be updated</param>
        /// <param name="carrier">Current carrier information from the EvaluatePhoneNumber function.</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateOriginalCarrier(string userId, string phoneNumber, CurrentCarrier carrier)
        {
            NumberProfileRequest request = new NumberProfileRequest()
            {
                UserId = userId,
                PhoneNumber = phoneNumber,
                CarrierInfo = new CarrierInfo()
                {
                    CarrierCode = carrier.CarrierCode,
                    Carrier = carrier.Carrier,
                    CountryCode = carrier.CountryCode,
                    NetworkType = carrier.NetworkType
                }
            };

            return UpdateOriginalCarrier(request);

        }

        /// <summary>
        /// Updates the original carrier information stored for the user and phone number
        /// with the updated current carrier information. Used once the user validates
        /// ownership of the phone number after the carrier change.
        /// </summary>
        /// <param name="request">NumberProfileRequest object</param>
        /// <returns>BaseResponse</returns>
        public BaseResponse UpdateOriginalCarrier(NumberProfileRequest request)
        {
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException("userId", "User ID cannot be empty.");
            }
            if (ValidateCarrierUpdateRequest(request))
            {
                throw new ArgumentNullException("request", "NumberProfileRequest cannot contain empty properties.");
            }
            if (ValidateCarrierUpdateRequest(request.CarrierInfo))
            {
                throw new ArgumentNullException("carrierinfo", "CarrierInfo cannot contain empty properties.");
            }

            return this._apiClient.Put<BaseResponse>("/api/" + apiVersion + "/numberprofile", request);
        }

        private bool ValidateCarrierUpdateRequest(object carrier)
        {
            return carrier.GetType().GetProperties()
                .Where(pi => pi.GetValue(carrier) is string)
                .Select(pi => (string)pi.GetValue(carrier))
                .Any(value => string.IsNullOrEmpty(value));
        }
    }
}
