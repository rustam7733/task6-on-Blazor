# =========================
# BUILD STAGE
# =========================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# копируем solution
COPY *.sln ./

# копируем проект
COPY task6 BlazorApplication/*.csproj ./task6 BlazorApplication/
RUN dotnet restore

# копируем весь код
COPY . ./

# publish
RUN dotnet publish "task6 BlazorApplication/task6 BlazorApplication.csproj" -c Release -o /app/publish


# =========================
# RUNTIME STAGE
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "task6_BlazorApplication.dll"]
