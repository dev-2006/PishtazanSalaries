#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pishtazan.Salaries/Pishtazan.Salaries.csproj", "Pishtazan.Salaries/"]
COPY ["Pishtazan.Salaries.Application/Pishtazan.Salaries.Application.csproj", "Pishtazan.Salaries.Application/"]
COPY ["Pishtazan.Salaries.Domain/Pishtazan.Salaries.Domain.csproj", "Pishtazan.Salaries.Domain/"]
COPY ["Pishtazan.Salaries.Domain.Common/Pishtazan.Salaries.Domain.Common.csproj", "Pishtazan.Salaries.Domain.Common/"]
COPY ["Pishtazan.Salaries.Framework/Pishtazan.Salaries.Framework.csproj", "Pishtazan.Salaries.Framework/"]
COPY ["Pishtazan.Salaries.Infrastructure/Pishtazan.Salaries.Infrastructure.csproj", "Pishtazan.Salaries.Infrastructure/"]
COPY ["Pishtazan.Salaries.OvertimePolicies/Pishtazan.Salaries.OvertimePolicies.csproj", "Pishtazan.Salaries.OvertimePolicies/"]
COPY ["Pishtazan.Salaries.Persistence/Pishtazan.Salaries.Persistence.csproj", "Pishtazan.Salaries.Persistence/"]
RUN dotnet restore "Pishtazan.Salaries/Pishtazan.Salaries.csproj"
COPY . .
WORKDIR "/src/Pishtazan.Salaries"
RUN dotnet build "Pishtazan.Salaries.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pishtazan.Salaries.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pishtazan.Salaries.dll"]