//using Entities.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;
//using Repositories.EfCore.Concrete;

//namespace Repositories.EfCore.Extensions
//{
//    public static class ServicesExtensions
//    {
//        public static ConfigureIdentity(this IServiceCollection)
//        {
//            var buildr = services.AddIdentityCore<User, IdentityRole>(opt =>
//            {
//                opt.Password.RequireDigit = true;
//                opt.Password.RequiredLength = 4;
//                opt.Password.RequireNonAlphanumeric = false;
//                opt.Password.RequireUppercase = false;
//                opt.User.RequireUniqueEmail = true;

//            })
//                .AddEntityFrameworkStores<RepositoryContext>()
//                .AddDefaultTokenProviders();
//        }
//    }
//}
