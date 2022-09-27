using Microsoft.Extensions.Configuration;
using ProductManagementDataAccess.AppConsts;


namespace ProductManagementDataAccess.Config
{
    public class AppSettingConfiguration
    {
        public static string ConnectionStrings => GetRoot()
            .GetSection(AppConfigConsts.ProductManagement)
            .GetSection(AppConfigConsts.ConnectionStrings)
            .Value;

        public static string FileWebApiAddress => GetRoot()
            .GetSection(AppConfigConsts.ExternalWebApiAddress)
            .GetSection(AppConfigConsts.FileWebApiAddress)
            .Value;

        public static IConfigurationRoot GetRoot()
        {
            var config = 
                new ConfigurationBuilder().
                AddJsonFile(AppSettingFilePath).
                Build();

            return config;
        }

        private static string AppSettingFilePath => Path.Combine(
                                                    Directory.GetCurrentDirectory(),
                                                    AppConfigConsts.AppSettingFileName);

    }


}
