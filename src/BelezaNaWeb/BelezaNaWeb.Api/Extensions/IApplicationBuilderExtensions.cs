﻿using System.Net;
using System.Globalization;
using BelezaNaWeb.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using BelezaNaWeb.Framework.Helpers;
using Microsoft.AspNetCore.Localization;
using BelezaNaWeb.Api.Infrastructure.Middlewares;

namespace BelezaNaWeb.Api.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        #region Extension Methods

        public static IApplicationBuilder UseCultureConfiguration(this IApplicationBuilder app)
        {
            var supportedCultures = new[] { new CultureInfo("pt-BR") };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            return app;
        }

        public static IApplicationBuilder UseStaticFilesConfiguration(this IApplicationBuilder app)
        {
            app.UseStaticFiles();
            return app;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {           
            app
                .UseOpenApi()
                .UseSwaggerUi3();

            return app;
        }

        public static IApplicationBuilder UseStatusCodePagesConfiguration(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(async context =>
            {
                var req = context.HttpContext.Request;
                var res = context.HttpContext.Response;

                res.ContentType = "application/json";

                switch (res.StatusCode)
                {
                    case (int)HttpStatusCode.Unauthorized:
                        await res.WriteAsync(SerializationHelper.SerializeToJson(ErrorDto.DefaultUnauthorizedResponse()));
                        break;
                    case (int)HttpStatusCode.Forbidden:
                        await res.WriteAsync(SerializationHelper.SerializeToJson(ErrorDto.DefaultForbiddenResponse()));
                        break;
                    case (int)HttpStatusCode.NotFound:
                        await res.WriteAsync(SerializationHelper.SerializeToJson(ErrorDto.DefaultNotFoundResponse()));
                        break;
                    case (int)HttpStatusCode.BadRequest:
                        await res.WriteAsync(SerializationHelper.SerializeToJson(ErrorDto.DefaultBadRequestResponse()));
                        break;
                    case (int)HttpStatusCode.MethodNotAllowed:
                        await res.WriteAsync(SerializationHelper.SerializeToJson(ErrorDto.DefaultMethodNotAllowedResponse()));
                        break;
                    case (int)HttpStatusCode.RequestTimeout:
                        await res.WriteAsync(SerializationHelper.SerializeToJson(ErrorDto.DefaultRequestTimeoutResponse()));
                        break;
                    case (int)HttpStatusCode.InternalServerError:
                        await res.WriteAsync(SerializationHelper.SerializeToJson(ErrorDto.DefaultInternalServerErrorResponse()));
                        break;
                    default:
                        await res.WriteAsync(SerializationHelper.SerializeToJson(ErrorDto.DefaultInternalServerErrorResponse()));
                        break;
                }
            });

            return app;
        }

        public static IApplicationBuilder UseMiddlewareConfiguration(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiExceptionMiddleware>();
            return app;
        }

        #endregion
    }
}
