using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Restaurants.Users.Api.Helpers
{
    public static class ErrorHelper
    {
        /// <summary>
        /// Convenience method for adding errors encountered by the Identity system to a ModelStateDictionary instance.
        /// </summary>
        /// <param name="identityResult">Results object returned by any of the Identity system methods.</param>
        /// <param name="modelState">The ModelStateDictionary instance to which the errors should be added.</param>
        /// <returns>The provided ModelStateDictionary instance with the errors added.</returns>
        public static ModelStateDictionary AddErrorsToModelState(IdentityResult identityResult, ModelStateDictionary modelState)
        {
            foreach (var e in identityResult.Errors)
            {
                modelState.TryAddModelError(e.Code, e.Description);
            }

            return modelState;
        }



        /// <summary>
        /// Convenience method for adding a custom error to a ModelStateDictionary instance.
        /// </summary>
        /// <param name="code">The identifier of the error.</param>
        /// <param name="description">A short description of the error.</param>
        /// <param name="modelState">The ModelStateDictionary instance to which the error should be added.</param>
        /// <returns>The provided ModelStateDictionary instance with the specified error added.</returns>
        public static ModelStateDictionary AddErrorToModelState(string code, string description, ModelStateDictionary modelState)
        {
            modelState.TryAddModelError(code, description);

            return modelState;
        }
    }
}
