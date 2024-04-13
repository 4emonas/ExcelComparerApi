FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
COPY . .
RUN dotnet publish ExcelComparerApi/ExcelComparerApi.csproj -o /app/published-app -c Release -r linux-arm64 --self-contained

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=build /app/published-app /app
EXPOSE 80
ENTRYPOINT [ "dotnet", "/app/ExcelComparerApi/ExcelComparerApi.dll" ]
