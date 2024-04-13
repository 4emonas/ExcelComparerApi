FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR app
COPY . .
RUN dotnet publish ExcelComparerApi/ExcelComparerApi.csproj -c Release -o /publish --self-contained --runtime linux-x64

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR app
COPY --from=build ./publish /app
EXPOSE 80
ENTRYPOINT [ "dotnet", "ExcelComparerApi.dll" ]
