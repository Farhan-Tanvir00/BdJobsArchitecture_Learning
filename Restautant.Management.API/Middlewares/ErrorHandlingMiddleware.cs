namespace Restautant.Management.API.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            //catch (NotFoundException ex)
            //{
            //    context.Response.StatusCode = 404;
            //    await context.Response.WriteAsJsonAsync(ex.Message);

            //}
            //catch (DtoValidationException dtoEx)
            //{
            //    context.Response.StatusCode = 400;
            //    await context.Response.WriteAsJsonAsync(new
            //    {
            //        Error = dtoEx.Message,
            //        ValidatioErrors = dtoEx.ValidationErrors
            //    });
            //}
            catch (Exception)
            {

                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync("Something Went Wrong");
            }
        }
    }
}
