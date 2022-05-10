using PlatformService.Models;

namespace PlatformService.Data{
    public static class PrepDb{
        public static void PrepPopulation(IApplicationBuilder app){

            using(var services=app.ApplicationServices.CreateScope()){
                SeedData(services.ServiceProvider.GetService<AppDbContext>());
            }
        }

        public static void SeedData(AppDbContext context){

            if(!context.Platforms.Any()){
                Console.WriteLine("--> Seeding the data --");
                
                context.Platforms.AddRange(
                    new Platform(){ Name="dotnet", Publisher="Microsoft", Cost="Free"},
                    new Platform(){Name="SQL SERVER",Publisher="Microsoft",Cost="Free"},
                    new Platform(){Name="Kubernetes",Publisher="Cloud Native",Cost="Paid"}
                );
            }
            else{
                Console.WriteLine("We already have data ");
            }
        }
    }
}