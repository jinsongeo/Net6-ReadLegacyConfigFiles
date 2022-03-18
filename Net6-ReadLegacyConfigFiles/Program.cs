// See https://aka.ms/new-console-template for more information
using Configurations.ConfigurationSections.Export;
using System.Configuration;
using System.Text.Json;

Console.WriteLine("Getting configurations from app.config file....");

//Reads from app.Config. Doesn't read from web.config
var appSetting = ConfigurationManager.AppSettings["AppSettingKey"];

var configSection = (ExportConfigurationSection)ConfigurationManager.GetSection("App.Export");

var configSectionForOutput = new
{
    ExportSettings = new
    {
        configSection.ExportServiceSettings.ConcurrentExportProcessLimit,
        configSection.ExportServiceSettings.RequestLifetimeInHours
    },
    PdfSettings = new
    {
        configSection.PdfSettings.SecretKey,
        configSection.PdfSettings.AuthExpirationInMinutes
    }
};

Console.WriteLine($"AppSetting:AppSettingKey - {appSetting}");

Console.WriteLine($"ConfigSection:App.Export - { JsonSerializer.Serialize(configSectionForOutput)}");

Console.WriteLine("Done!");

