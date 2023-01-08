FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Tldl.VoiceToTextService/Tldl.VoiceToTextService.csproj", "Tldl.VoiceToTextService/"]
RUN dotnet restore "Tldl.VoiceToTextService/Tldl.VoiceToTextService.csproj"
COPY . .
WORKDIR "/src/Tldl.VoiceToTextService"
RUN dotnet build "Tldl.VoiceToTextService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tldl.VoiceToTextService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tldl.VoiceToTextService.dll"]
