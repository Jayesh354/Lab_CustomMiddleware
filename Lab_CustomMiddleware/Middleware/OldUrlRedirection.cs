namespace Lab_CustomMiddleware.Middleware
{
    public class OldUrlRedirection
    {
        private readonly RequestDelegate _next;

        public OldUrlRedirection(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var url = context.Request.Path.Value;
            string redirectURL=string.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                url = url.ToLowerInvariant();
            }
            switch(url)
            {
                case "/home/privacy":
                    redirectURL = "/privacy-policy";
                    break;
                case "/account/login":
                    redirectURL = "/login";
                    break;
            }
            if(!string.IsNullOrEmpty(redirectURL))
            {
                context.Response.Redirect(redirectURL);
                return;
            }
            await _next(context);
        }
    }
}
