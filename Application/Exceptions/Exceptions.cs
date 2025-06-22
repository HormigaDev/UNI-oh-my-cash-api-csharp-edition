using System;

namespace App.Application.Exceptions;

public class HttpException(int statusCode, string message) : Exception(message)
{
    public int StatusCode { get; } = statusCode;
}

public class BadRequestException(string message) : HttpException(400, message) { }

public class UnauthorizedException(string message) : HttpException(401, message) { }

public class ForbiddenException(string message) : HttpException(403, message) { }

public class NotFoundException(string message) : HttpException(404, message) { }

public class ConflictException(string message) : HttpException(409, message) { }

public class UnprocessableEntityException(string message) : HttpException(422, message) { }
