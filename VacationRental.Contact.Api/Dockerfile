#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["VacationRental.Contact.Api/VacationRental.Contact.Api.csproj", "VacationRental.Contact.Api/"]
RUN dotnet restore "VacationRental.Contact.Api/VacationRental.Contact.Api.csproj"
COPY . .
WORKDIR "/src/VacationRental.Contact.Api"
RUN dotnet build "VacationRental.Contact.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VacationRental.Contact.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VacationRental.Contact.Api.dll"]