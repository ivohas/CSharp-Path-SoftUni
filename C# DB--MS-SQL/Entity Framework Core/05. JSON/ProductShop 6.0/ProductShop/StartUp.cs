using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            string inputJson = File
                .ReadAllText(@"../../../Datasets/users.json");
            string result = ImportUsers(context, inputJson);
            Console.WriteLine(result);


           
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        { 
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
            var userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);
            ICollection<User> validUsers = new HashSet<User>();
            foreach (ImportUserDto uD in userDtos)
            {
                var user = mapper.Map<User>(uD);
                validUsers.Add(user);
            }
            context.Users.AddRange(validUsers);
            context.SaveChanges();
            return $"Successfully imported {validUsers.Count}";
        }
    }
} 