using DotNetCrudAutomation.Model;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCrudAutomation.Helper;

public class ResponseHelper
{
    public static OkObjectResult OK_Result(dynamic? data, DefaultResponseMessageModel? model)
    {
        return new OkObjectResult(new DefaultResponseModel
        {
            Success = true,
            Code = StatusCodes.Status200OK,
            Meta = new { message = model },
            Data = data,
            Error = null
        });
    }

    public static CreatedResult Created_Result(string endpoint, dynamic? data, DefaultResponseMessageModel? model)
    {
        return new CreatedResult(endpoint, new DefaultResponseModel
        {
            Success = true,
            Code = StatusCodes.Status201Created,
            Meta = new { message = model },
            Data = data,
            Error = null
        });
    }

    public static BadRequestObjectResult Bad_Request(dynamic? data, DefaultResponseMessageModel? model)
    {
        return new BadRequestObjectResult(new DefaultResponseModel
        {
            Success = false,
            Code = StatusCodes.Status400BadRequest,
            Meta = null,
            Data = data,
            Error = new { message = model }
        });
    }

    public static NotFoundObjectResult NotFound_Request(dynamic? data, DefaultResponseMessageModel? model)
    {
        return new NotFoundObjectResult(new DefaultResponseModel
        {
            Success = false,
            Code = StatusCodes.Status404NotFound,
            Meta = null,
            Data = data,
            Error = new { message = model }
        });
    }

    public static UnauthorizedObjectResult Unauthorized_Request(dynamic? data, DefaultResponseMessageModel? model)
    {
        return new UnauthorizedObjectResult(new DefaultResponseModel
        {
            Success = false,
            Code = StatusCodes.Status401Unauthorized,
            Meta = null,
            Data = data,
            Error = new { message = model }
        });
    }
    
    public static ObjectResult TooManyRequest_Request(DefaultResponseMessageModel? model)
    {
        return new ObjectResult(new DefaultResponseModel
        {
            Success = false,
            Code = StatusCodes.Status429TooManyRequests,
            Meta = null,
            Data = null,
            Error = new { message = model }
        });
    }
    
    public static ObjectResult InternalServerError_Request(dynamic? data, DefaultResponseMessageModel? model)
    {
        return new ObjectResult(new DefaultResponseModel
        {
            Success = false,
            Code = StatusCodes.Status500InternalServerError,
            Meta = null,
            Data = data,
            Error = new { message = model }
        });
    }

    public static IResult OK_Result_Endpoint(dynamic? data, DefaultResponseMessageModel? model)
    {
        return Results.Ok(new DefaultResponseModel
        {
            Success = true,
            Code = StatusCodes.Status200OK,
            Meta = new { message = model },
            Data = data,
            Error = null
        });
    }

    public static IResult Created_Result_Endpoint(string endpoint, dynamic? data, DefaultResponseMessageModel? model)
    {
        return Results.Created(endpoint, new DefaultResponseModel
        {
            Success = true,
            Code = StatusCodes.Status201Created,
            Meta = new { message = model },
            Data = data,
            Error = null
        });
    }

    public static IResult UnprocessableEntity_Request_Endpoint(dynamic? data, DefaultResponseMessageModel? model)
    {
        return Results.BadRequest(new DefaultResponseModel
        {
            Success = false,
            Code = StatusCodes.Status400BadRequest,
            Meta = null,
            Data = data,
            Error = new { message = model }
        });
    }

    public static IResult Bad_Request_Endpoint(dynamic? data, DefaultResponseMessageModel? model)
    {
        return Results.BadRequest(new DefaultResponseModel
        {
            Success = false,
            Code = StatusCodes.Status400BadRequest,
            Meta = null,
            Data = data,
            Error = new { message = model }
        });
    }

    public static IResult NotFound_Request_Endpoint(dynamic? data, DefaultResponseMessageModel? model)
    {
        return Results.NotFound(new DefaultResponseModel
        {
            Success = false,
            Code = StatusCodes.Status404NotFound,
            Meta = null,
            Data = data,
            Error = new { message = model }
        });
    }

    public static IResult InternalServerError_Request_Endpoint(dynamic? data, DefaultResponseMessageModel? model)
    {
        return Results.BadRequest(new DefaultResponseModel
        {
            Success = false,
            Code = StatusCodes.Status500InternalServerError,
            Meta = null,
            Data = data,
            Error = new { message = model }
        });
    }
}