FROM microsoft/dotnet
WORKDIR /app

ENV ASPNETCORE_URLS http://+:8080
EXPOSE 8080

COPY . ./
RUN dotnet restore

ENTRYPOINT ["dotnet", "run"]
