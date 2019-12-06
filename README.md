# SeleniumWithPageObjectDemo

A demo project to show a correct way of Selenium WebDriver and Page Object pattern usage in Test Automation Framework.

## Technologies
1. .Net Core 2.2
2. Selenium WebDriver
3. NUnit3

## How to set up locally

### Prerequisites
- Visual Studio 17 or higher
- NET Core 2.2 SDK

### Steps
1.	Click on **Clone or download** button
2.	Open Visual Studio
3.	Navigate to Team Explorer tab
4.	Click on to open Manage Connections
5.	Click on Clone link
6.	Insert the copied link and click Clone button
7.	Open the solution from Solutions list 
8.	Click on Build -> Build Solution

## How to run tests
**Run from the command line / bash**
1.	Open command line or bash
2.	Navigate to the directory containing the .sln
3.	Run the following command
```
dotnet test
```

**Run from Visual Studio**
1.	Open the .sln in VS
2.	Build -> Build Solution (select necessary configuration)
3.	Open Test -> Windows -> Test Explorer
4.	Click on Run All (if you want to run all the tests) or right click on selected tests and Run Selected Tests

## Features
### Parallel Test Execution
Put the following attribute for the class with **[TestFixture]** attribute:
```
[Parallelizable(ParallelScope.All)]
```
More on this attribue [Nunit Paralalizable Attribute](https://github.com/nunit/docs/wiki/Parallelizable-Attribute)

**How to restrict max number of parallel tests**
This attribute is called **LevelOfParallelism** in NUnit, and for .net framework projects argument --workers can be used. But for .net core --workers argument isn’t available now (waiting for [NUnit issue](https://github.com/nunit/nunit-console/issues/475) to be resolved)
So, the only way to restrict number of parallel tests - is a custom **LevelOfParallelism attribute**.

Add the following task in **.csproj** file (e.g. in Tests.csproj)

```
<ItemGroup>
        <AssemblyAttribute Include="NetTAF.Attributes.LevelOfParallelismAttribute">
            <_Parameter1>5</_Parameter1>
        </AssemblyAttribute>
</ItemGroup>
```

Note: NUnit.Framework.LevelOfParallelismAttribute cannot be used, because it takes only int parameter, but this task (with NetTAF.Attributes.LevelOfParallelismAttribute) will convert Parameter1 to string.

### Configurations
**appsettings.{env}.json Files**
All the parameters are stored in .json files. There might be several different appsettings.{env}.json files for different environments/configurtaions. appsettings.json file is used as default configurations file (Local).

**ConfigManager.cs** reads configurations from .json file and map it to a properties.

**How to get any value from the .json file**
To retrieve any value form the config file use the following command ConfigManager.{Configuration section}.{Parameter}
Example: ```ConfigManager.Browser.StartUrl```

**How to add a new appsettings.{env}.json file**
1.	Create a new .json with all the necessary parameters
2.	Update ConfgiManager.Configuration property specifying the build configuration to which the new .json file related:
```
        public static IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
            .AddJsonFile("appsettings.json")
#else TEST
            .AddJsonFile("appsettings.Test.json")
#endif
            .Build();
```

### Page Object Pattern
The classes and objects participating in this pattern are:
1.	**Page** (PageModels/Pages/SearchPage.cs)- Holds the actions that can be performed on the page. Exposes an easy access to the Page Validator through the Validate() method. The best implementations of the pattern hide the usage of the Element Map, wrapping it through all action methods.
2.	Page **Element Map** (PageModels/Maps/SearchPageElementMap.cs) – Contains all element properties and their location logic.
3.	Page **Validator** (PageModels/Validators/SearchPageValidator.cs) – Consists of the validations that can be performed on the page.



