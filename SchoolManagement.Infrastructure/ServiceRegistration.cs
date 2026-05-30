using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Core.Data;
using SchoolManagement.Core.Entities.identity;
using SchoolManagement.Infrastructure.Data;
using System.Text;

namespace SchoolManagement.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServiceRegistrationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. جلب إعدادات الـ JWT من ملف الـ appsettings.json
            var jwtSettings = configuration.GetSection("Jwt").Get<JWTSettings>();
            // services.AddSingleton(jwtSettings);
            // 2. إعداد الـ ASP.NET Core Identity لإدارة المستخدمين والصلاحيات
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // 3. إعداد الـ Authentication ليعتمد بالكامل على الـ JWT Bearer Token
            services.AddAuthentication(options =>
            {
                // المخطط الافتراضي عند استخدام وسم [Authorize] بدون تحديد نوع
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                // المخطط الافتراضي الذي يتم استدعاؤه عند فشل عملية التحقق (401)
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false; // يفضل جعلها true في بيئة الإنتاج الفعلية Production

                // شروط ومعايير التحقق من صحة التوكن المستلم
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),

                    // إلغاء وقت السماحية الافتراضي (5 دقائق) لضمان انتهاء صلاحية التوكن فوراً وبدقة
                    ClockSkew = TimeSpan.Zero
                };
            });

            // 4. تفعيل خدمات الـ Authorization (تحديد الصلاحيات والأدوار)
            services.AddAuthorization();

            return services;
        }
    }
}