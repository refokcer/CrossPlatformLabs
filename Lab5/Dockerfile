# Используем базовый образ для ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Слой для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Копируем файл NuGet.Config (если используется)
COPY ["NuGet.Config", "."]

# Копируем проект Lab5
COPY ["Lab5/Lab5.csproj", "Lab5/"]

# Восстанавливаем зависимости
RUN dotnet restore "./Lab5/Lab5.csproj"

# Копируем всё остальное
COPY . .

# Переходим в папку Lab5 и собираем проект
WORKDIR "/src/Lab5"
RUN dotnet build "./Lab5.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Слой для публикации
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Lab5.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Финальный рабочий слой
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Указываем порт по умолчанию, соответствующий настройкам launchSettings.json
ENV ASPNETCORE_URLS=http://+:8080

# Точка входа
ENTRYPOINT ["dotnet", "Lab5.dll"]