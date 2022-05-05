namespace DllDescriptorJsonGenerator
{
    using System;
    using System.IO;
    using Newtonsoft.Json;

    /// <summary>
    /// Утилита для генерации дескрипторов внешних сборок или обновления даты последнего изменения в существующих дескрипторах. 
    /// </summary>
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 1. Парсим аргументы командной строки.
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: DllDescriptorJsonGenerator.exe ABSOLUTE_PATH_TO_descriptor.json DLL_NAME_WITHOUT_EXTENSION");
                return;
            }

            string descriptorJsonFilepath = args[0];
            string dllName = args[1];

            if (string.IsNullOrEmpty(descriptorJsonFilepath) || string.IsNullOrEmpty(dllName))
            {
                Console.WriteLine("One or more of the arguments are either empty or null, aborting.");
                return;
            }

            DescriptorJsonModel descriptorJsonToUpsert;

            // 2. Проверяем, существует ли файл по заданному пути.
            if (!File.Exists(descriptorJsonFilepath))
            {
                // Файл не существует — создаем новый descriptor.json со случайным UId.
                descriptorJsonToUpsert = new DescriptorJsonModel
                {
                    Descriptor = new DescriptorModel
                    {
                        UId = Guid.NewGuid(),
                        Name = $"{dllName}.dll",
                        FullName = $"{dllName}, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        ModifiedOnUtc = DateTime.UtcNow
                    }
                };
            }
            else
            {
                // Файл существует — читаем и десериализуем descriptor.json.
                string json = File.ReadAllText(descriptorJsonFilepath);
                descriptorJsonToUpsert = JsonConvert.DeserializeObject<DescriptorJsonModel>(json);

                if (descriptorJsonToUpsert?.Descriptor is null)
                {
                    Console.WriteLine("Existing file has invalid format, aborting.");
                    return;
                }

                // Обновляем дату на текущую.
                descriptorJsonToUpsert.Descriptor.ModifiedOnUtc = DateTime.UtcNow;
            }

            // 3. Сериализуем и перезаписываем файл.
            File.WriteAllText(descriptorJsonFilepath, JsonConvert.SerializeObject(descriptorJsonToUpsert, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            }));
        }
    }
}