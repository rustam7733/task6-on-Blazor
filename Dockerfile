# =========================
# BUILD
# =========================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# копируем solution
COPY "task6 BlazorApplication.sln" .

# копируем csproj
COPY "task6 BlazorApplication/task6 BlazorApplication.csproj" "task6 BlazorApplication/"

# restore
RUN dotnet restore "task6 BlazorApplication/task6 BlazorApplication.csproj"

# копируем всё остальное
COPY . .

# publish
RUN dotnet publish "task6 BlazorApplication/task6 BlazorApplication.csproj" -c Release -o /app/publish


# =========================
# RUNTIME
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "task6_BlazorApplication.dll"]
