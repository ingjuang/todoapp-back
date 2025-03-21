using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TodoApp_Back.Application.Services.Interfaces;

namespace TodoApp_Back.API.Filters
{
    public class AuthorizeHmacAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var hmacService = context.HttpContext.RequestServices.GetService<IHmacService>();

            if (hmacService == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // 🔹 Extraer los headers HMAC y Timestamp
            if (!context.HttpContext.Request.Headers.TryGetValue("X-HMAC-Signature", out var receivedHmac) ||
                !context.HttpContext.Request.Headers.TryGetValue("X-Timestamp", out var timestamp))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            string method = context.HttpContext.Request.Method;
            string path = context.HttpContext.Request.Path;

            // 🔹 Leer el cuerpo de la petición si es POST o PUT
            string body = string.Empty;
            if (method == "POST" || method == "PUT")
            {
                context.HttpContext.Request.EnableBuffering();
                using var reader = new StreamReader(context.HttpContext.Request.Body, Encoding.UTF8, leaveOpen: true);
                string rawBody = await reader.ReadToEndAsync();
                context.HttpContext.Request.Body.Position = 0;

                if (!string.IsNullOrWhiteSpace(rawBody))
                {
                    using var doc = JsonDocument.Parse(rawBody);
                    body = JsonSerializer.Serialize(doc.RootElement);
                }
            }

            // 🔹 Construir el mensaje a firmar
            string message = $"{method} {path} {timestamp} {body}";

            // 🔹 Validar el HMAC
            if (!hmacService.ValidateHmac(message, receivedHmac.ToString()))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
