## Collecting Code Coverage

To collect code coverage metrics for your .NET tests, use the following command in your terminal:

```sh
dotnet test --collect:"XPlat Code Coverage" --results-directory ./TestResults
```

This command will execute all tests in your solution and collect code coverage data using the cross-platform code coverage tool.

**_The results will be stored in the `./TestResults` directory._**

## Generating Coverage Reports

After collecting code coverage data, you can generate readable reports using ReportGenerator. Use the command below:

```sh
reportgenerator -reports:"<.../coverage.cobertura.xml>;<.../coverage.cobertura.xml>;<.../coverage.cobertura.xml>" -targetdir:"CoverletReports" -reporttypes:"HtmlInline_AzurePipelines;Cobertura" -historydir:./TestResults -filefilters:-*\KlockanAPI.Infrastructure\Data\Migrations*
```

Replace `<.../coverage.cobertura.xml>` with the path to your coverage files.

This command compiles the coverage data into an HTML report.



## Viewing Coverage Reports

Once you have generated the coverage reports, you can view a detailed HTML report by opening the `index.html` file located in the `CoverletReports` directory.

To open the report, navigate to the `CoverletReports` directory and double-click on the `index.html` file.

Alternatively, you can open it directly from the command line with the following command, depending on your operating system:

For Windows:

```powershell
start CoverletReports\index.html
```

## Command Summary

dotnet test --collect:"XPlat Code Coverage" --results-directory ./TestResults /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./TestResults/Coverage/ ; reportgenerator -reports:"./TestResults/*/*.xml" -targetdir:"./TestResults/CoverletReports" -reporttypes:"HtmlInline_AzurePipelines_Dark;Cobertura" -historydir:./TestResults -filefilters:-*\WakuWakuAPI.Infraestructure\Data\Migrations* ; start ./TestResults/CoverletReports/index.html
```
```sh