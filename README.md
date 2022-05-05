# Terrasoft-Creatio-DLL-Solution-Template
Шаблонный Solution для разработки внешних DLL Terrasoft Creatio с автоматической разверткой. 

Содержит 2 проекта:
1. `Navicon.Configuration` — DLL-библиотека;
2. `DllDescriptorJsonGenerator` — консольная утилита для генерации дескрипторов внешних сборок (_descriptor.json_) или обновления даты последнего изменения в существующих дескрипторах. Используется проектом `Navicon.Configuration` для создания/обновления связанного с DLL файла _descriptor.json_.

# Требования к среде
1. Режим разработки в файловой системе должен быть включен;
2. Стандартная утилита `WorkspaceConsole` должна быть развернута в директории `Terrasoft.WebApp\DesktopBin\WorkspaceConsole`. Чтобы сделать это, запускаем `PrepareWorkspaceConsole.x64.bat` или `PrepareWorkspaceConsole.x86.bat` в соответствующей директории.

# Как настроить
2. Копируем папку с решением `Navicon.Configuration` в `Terrasoft.WebApp`. Папка решения `Navicon.Configuration` должна находиться на одном уровне с `Terrasoft.Configuration`;
3. Открываем текстовым редактором файл проекта `Navicon.Configuration.csproj` и заменяем все **%DLL_PACKAGE_NAME%** на название пакета, в котором будет находиться DLL (прим. _Custom_);
4. Открываем Solution и восстанавливаем NuGet-пакеты для проекта `DllDescriptorJsonGenerator`;
5. Собираем `DllDescriptorJsonGenerator`;
6. **(Опционально)** Меняем название проекта с DLL-библиотекой и выходного DLL-файла, отредактировав `Navicon.Configuration.csproj` и `Navicon.Configuration.sln`;
7. **(Опционально)** Если после билда требуется заливать изменения пакетов в БД и компилировать приложение Creatio, то раскомментировать в файле `Navicon.Configuration.csproj` строчку `<!--<Exec Command="UpdateDbAndCompile.bat"/>-->`

# Как пользоваться
1. Пишем код в проекте `Navicon.Configuration`;

2. Собираем проект `Navicon.Configuration`;
   * [x] После сборки `Navicon.Configuration` автоматически скопирует выходной DLL и создаст/обновит связанный _descriptor.json_ в директории пакета с внешней сборкой.

3. Запускаем `UpdateDbAndCompile.bat` в корне проекта `Navicon.Configuration` для обновления БД и компиляции приложения Creatio. **Это не нужно делать, если** `UpdateDbAndCompile.bat`**автоматически запускается после каждого билда (см. _п.7_ выше).**
