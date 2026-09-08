FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["IncogNicoInvoicing/IncogNicoInvoicing.csproj", "IncogNicoInvoicing/"]
COPY ["Invoicing.Business/Invoicing.Business.csproj", "Invoicing.Business/"]
COPY ["Invoicing.Contract/Invoicing.Contract.csproj", "Invoicing.Contract/"]
COPY ["Invoicing.Domain/Invoicing.Domain.csproj", "Invoicing.Domain/"]
COPY ["Invoicing.Infrastructure/Invoicing.Infrastructure.csproj", "Invoicing.Infrastructure/"]

RUN dotnet restore "IncogNicoInvoicing/IncogNicoInvoicing.csproj"

COPY . .

RUN dotnet publish "IncogNicoInvoicing/IncogNicoInvoicing.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "IncogNicoInvoicing.dll"]