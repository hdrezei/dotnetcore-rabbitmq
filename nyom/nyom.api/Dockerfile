FROM microsoft/aspnetcore
ARG source
WORKDIR /nyom
EXPOSE 80
COPY /bin/Release/netcoreapp1.1/publish/ /nyom
ENTRYPOINT ["dotnet","nyom.api.dll"]