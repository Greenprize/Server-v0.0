FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
# Copy csproj and restore as distinct layers
COPY ["./Server v0.0/*.csproj", "./"]
RUN dotnet restore
# Copy everything else and build
COPY ["./Server v0.0/", "./"]
# COPY ./_stylecop/ /_stylecop/
RUN dotnet publish -c Release -o out
# RUN ls -l /app/
# to see output - use --progress=plain --no-cache flag

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/Views /Views
COPY --from=build-env /app/out/ ./
# RUN ls -l /Views

ENTRYPOINT ["dotnet", "Server v0.0.dll"]
