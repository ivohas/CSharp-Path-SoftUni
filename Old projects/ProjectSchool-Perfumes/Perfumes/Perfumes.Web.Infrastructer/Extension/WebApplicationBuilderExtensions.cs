//using Perfumes.Data.Models;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Identity;
//using System.Reflection;
//using static Perfumes.Common.GeneralApplicationConstansts;
//using Microsoft.Extensions.DependencyInjection;

//namespace BookFindingAndRatingSystem.Web.Infrastucture.Extensions
//{
//    public static class WebApplicationBuilderExtensions
//    {

//        public static void AddApllicationServices(this IServiceCollection services, Type serviceType)
//        {
//            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
//            if (serviceAssembly == null)
//            {
//                throw new InvalidOperationException("Invalid service type provided");
//            }

//            Type[] serviceTypes = serviceAssembly
//                .GetTypes()
//                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
//                .ToArray();

//            foreach (var st in serviceTypes)
//            {
//                Type? interfaceType = st
//                    .GetInterface($"I{st.Name}");
//                if (interfaceType == null)
//                {
//                    throw new InvalidOperationException($"No Interface is provided for service {st.Name}");
//                }
//                services.AddScoped(interfaceType, st);
//            }
//        }
//        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
//        {
//            using var scopedServices = app.ApplicationServices.CreateScope();

//            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

//            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<AplicationUser>>();

//            RoleManager<IdentityRole<Guid>> roleManager =
//                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

//            Task.Run(async () =>
//            {
//                if (await roleManager.RoleExistsAsync(AdminRoleName))
//                {
//                    return;
//                }
//                IdentityRole<Guid> role =
//                    new IdentityRole<Guid>(AdminRoleName);

//                await roleManager.CreateAsync(role);

//                AplicationUser adminUser =
//                    await userManager.FindByEmailAsync(email);

//                await userManager.AddToRoleAsync(adminUser, AdminRoleName);
//            })
//              .GetAwaiter()
//              .GetResult();

//            return app;
//        }
//    }
//}
