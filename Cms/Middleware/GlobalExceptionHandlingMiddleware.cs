//using System.Net;

//namespace Cms.Middleware
//{
//    public class GlobalExceptionHandlingMiddleware:IMiddleware
//    { 
        
//        private readonly RequestDelegate _next;
//        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
//        public GlobalExceptionHandlingMiddleware(
//            RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
//        {
          
            
//            _logger = logger;   
//        }
        

//        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
//        {
//            try
//            {

//                await _next(context);
//            }

//            catch (Exception ee)
//            {


//                _logger.LogError(ee, ee.Message);
//                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//                //Console.WriteLine(ee);
//                //throw;
//            }
//        }
//    }
//}
