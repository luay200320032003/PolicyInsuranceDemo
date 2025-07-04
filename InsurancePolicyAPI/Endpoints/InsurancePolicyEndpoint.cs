using FluentValidation;
using InsurancePolicy.Domain;
using InsurancePolicy.Service;
using InsurancePolicyAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePolicyAPI.Endpoints
{
    
        public static class InsurancePolicyEndpoint
        {
            public static void MapEndPoint(this IEndpointRouteBuilder routers)
            {
                string enPointName = "InsurancePolicyEndpoints";


                routers.MapGet("/api/policies/{policyNumber}", GetPolicy)
                    .WithName("GetPolicy")
                    .Produces<APIResponse<Policy>>(200)
                    .ProducesProblem(400)  // Apply the ProblemDetails format for BadRequest
                    .ProducesProblem(404)  // Apply the ProblemDetails format for NotFound
                    .WithTags(enPointName);
            }
            // Handler method for the endpoint
            public static IResult GetPolicy(string policyNumber, PolicyService policyService, IValidator<Policy> validator)
            {
                var validationResult = validator.Validate(new Policy { PolicyNumber = policyNumber });

                // If validation fails, return a BadRequest with the validation errors
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(new ProblemDetails
                    {
                        Status = 400,
                        Title = "Invalid Policy Number",
                        Detail = validationResult.ToString(),
                        Instance = $"/api/policies/{policyNumber}"
                    });
                }
                // Fetch the policy from the service
                var policy = policyService.GetPolicy(policyNumber);

                if (policy == null)
                {
                    return Results.NotFound(new ProblemDetails
                    {
                        Status = 404,
                        Title = "Policy Not Found",
                        Detail = "The policy number provided does not exist.",
                        Instance = $"/api/policies/{policyNumber}"
                    });
                }

                return Results.Ok(new APIResponse<Policy>
                {
                    Success = true,
                    Data = policy,
                    Message = "Policy fetched successfully."
                });
            }
        }
    }

