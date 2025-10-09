using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using AliMartinCv.Core.Sevices.Interfaces; // مطمئن شو namespace درست باشه

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public sealed class ProfileStatusCheckerAttribute : Attribute, IFilterFactory, IOrderedFilter
{
    public string RedirectPath { get; }
    public bool IsReusable => false;
    public int Order { get; set; } = 0;

    public ProfileStatusCheckerAttribute(string redirectPath = "/parent/complete-profile")
    {
        RedirectPath = string.IsNullOrWhiteSpace(redirectPath)
            ? "/parent/complete-profile"
            : redirectPath;
    }

    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    {
        var parentService = serviceProvider.GetRequiredService<IParent>();
        return new Impl(parentService, RedirectPath);
    }

    // فیلتر اصلی
    private sealed class Impl : IAsyncActionFilter
    {
        private readonly IParent _parentService;
        private readonly string _redirectPath;

        public Impl(IParent parentService, string redirectPath)
        {
            _parentService = parentService;
            _redirectPath = redirectPath;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = context.HttpContext.User;

            // ✅ اگر کسی لاگین نکرده
            if (!user.Identity?.IsAuthenticated ?? true)
            {
                context.Result = new RedirectResult("/login");
                return;
            }

            // گرفتن نقش کاربر
            var role = user.FindFirst(ClaimTypes.Role)?.Value;

            // ✅ اگر ادمین هست، اصلاً بررسی نکن
            if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                await next();
                return;
            }

            // ✅ اگر والد است
            if (string.Equals(role, "Parent", StringComparison.OrdinalIgnoreCase))
            {
                var parentIdClaim = user.FindFirst(ClaimTypes.Anonymous)?.Value;

                if (string.IsNullOrEmpty(parentIdClaim) || !Guid.TryParse(parentIdClaim, out var parentId))
                {
                    context.Result = new RedirectResult("/login");
                    return;
                }

                var isCompleted = await _parentService.IsProfileCompleted(parentId);
                if (!isCompleted)
                {
                    
                    context.Result = new RedirectResult(_redirectPath);
                    return;
                }

                await next();
                return;
            }

            // ✅ اگر نقش User (مثلاً دانش‌آموز)
            if (string.Equals(role, "Student", StringComparison.OrdinalIgnoreCase))
            {
                // از NameIdentifier مقدار بگیر
                var studentIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(studentIdClaim))
                {
                    context.Result = new RedirectResult("/login");
                    return;
                }

                // برای دانش‌آموز فعلاً کاری انجام نمی‌دیم، می‌تونی در آینده چک مشابه اضافه کنی
                await next();
                return;
            }

            // ✅ سایر نقش‌ها یا بدون نقش
            context.Result = new RedirectResult("/login");
        }
    }
}
