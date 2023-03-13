#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Presentation/Api/ECommerce.WebApi/ECommerce.WebApi.csproj", "Presentation/Api/ECommerce.WebApi/"]
COPY ["Core/ECommerce.Application/ECommerce.Application.csproj", "Core/ECommerce.Application/"]
COPY ["Core/ECommerce.Domain/ECommerce.Domain.csproj", "Core/ECommerce.Domain/"]
COPY ["Core/ECommerce.Resource/ECommerce.Resource.csproj", "Core/ECommerce.Resource/"]
COPY ["Core/ECommerce.Mapper/ECommerce.Mapper.csproj", "Core/ECommerce.Mapper/"]
COPY ["Infrastructure/ECommerce.Infrastructure/ECommerce.Infrastructure.csproj", "Infrastructure/ECommerce.Infrastructure/"]
COPY ["Infrastructure/ECommerce.Persistence/ECommerce.Persistence.csproj", "Infrastructure/ECommerce.Persistence/"]
RUN dotnet restore "Presentation/Api/ECommerce.WebApi/ECommerce.WebApi.csproj"
COPY . .
WORKDIR "/src/Presentation/Api/ECommerce.WebApi"
RUN dotnet build "ECommerce.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.WebApi.dll"]
