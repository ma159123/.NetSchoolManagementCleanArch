using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Bases;
using SchoolManagement.Infrastructure.impl;

namespace SchoolManagement.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepo, StudentRepo>();
            services.AddTransient<IDepartmentRepo, DepartmentRepo>();
            services.AddTransient(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            return services;
        }
    }
}
