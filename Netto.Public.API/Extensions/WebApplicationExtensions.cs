using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using FluentValidation.AspNetCore;
using Netto.Public.API.Filters;

namespace Netto.Public.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void UseCustomCorsExtension(this WebApplication app)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    );
        }

        public static void AddControllersExtension(this IServiceCollection services)
        {
            services.AddControllers()
                .AddMvcOptions(options =>
                {
                    options.Filters.Add<ValidatorActionFilter>();
                    options.Filters.Add<ExceptionFilter>();
                    options.Filters.Add<ResponseFilter>();
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                    options.InvalidModelStateResponseFactory = c =>
                    {
                        var errors = c.ModelState.Values.Where(v => v.Errors.Count > 0)
                            .SelectMany(v => v.Errors)
                            .Select(v => v.ErrorMessage);

                        string json = JsonSerializer.Serialize(errors);
                        throw new ValidationException(json);
                    };
                })
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Program>();
                    fv.AutomaticValidationEnabled = true;
                    fv.ImplicitlyValidateChildProperties = true;
                    fv.DisableDataAnnotationsValidation = true;
                });
        }


    }
}
