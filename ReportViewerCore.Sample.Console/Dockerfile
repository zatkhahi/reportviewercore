#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReportViewerCore.Sample.Console/ReportViewerCore.Sample.Console.csproj", "ReportViewerCore.Sample.Console/"]
COPY ["Microsoft.ReportViewer.NETCore/Microsoft.ReportViewer.NETCore.csproj", "Microsoft.ReportViewer.NETCore/"]
COPY ["Microsoft.ReportViewer.DataVisualization/Microsoft.ReportViewer.DataVisualization.csproj", "Microsoft.ReportViewer.DataVisualization/"]
COPY ["Microsoft.ReportViewer.ProcessingObjectModel/Microsoft.ReportViewer.ProcessingObjectModel.csproj", "Microsoft.ReportViewer.ProcessingObjectModel/"]
COPY ["Microsoft.ReportViewer.Common/Microsoft.ReportViewer.Common.csproj", "Microsoft.ReportViewer.Common/"]
RUN dotnet restore "ReportViewerCore.Sample.Console/ReportViewerCore.Sample.Console.csproj"
COPY . .
WORKDIR "/src/ReportViewerCore.Sample.Console"
RUN dotnet build "ReportViewerCore.Sample.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReportViewerCore.Sample.Console.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReportViewerCore.Sample.Console.dll"]