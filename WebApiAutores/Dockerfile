FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR webapp 

EXPOSE 80
EXPOSE 5024

COPY ./*.csproj ./
 
RUN dotnet restore 

COPY . .

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /webapp
COPY --from=build /webapp/out .
ENTRYPOINT ["dotnet", "WebApiAutores.dll"]