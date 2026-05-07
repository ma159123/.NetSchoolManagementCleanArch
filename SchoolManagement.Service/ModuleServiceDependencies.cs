using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Service.Abstract;
using SchoolManagement.Service.Impl;

namespace SchoolManagement.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
