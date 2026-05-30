using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Core.Abstractions.infra_abstract;
using SchoolManagement.Core.Abstractions.Seeder;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Bases;
using SchoolManagement.Infrastructure.impl;
using SchoolManagement.Infrastructure.Seeder;

namespace SchoolManagement.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepo, StudentRepo>();
            services.AddTransient<IDepartmentRepo, DepartmentRepo>();
            services.AddTransient(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddTransient<IAuthRepo, AuthRepo>();
            services.AddTransient<ISeeder, RoleSeeder>();
            services.AddTransient<ISeeder, UserSeeder>();

            return services;
        }
    }
}
