using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProductCatalogAPI.Api.Models;

public class CustomValidationProblemDetails : ProblemDetails
{
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}