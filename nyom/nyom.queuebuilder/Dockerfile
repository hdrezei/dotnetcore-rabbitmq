FROM microsoft/dotnet:latest
RUN mkdir /nyom
WORKDIR /nyom
COPY /bin/Release/netcoreapp2.0/publish/ /nyom
ENTRYPOINT ["dotnet","nyom.queuebuilder.dll"]
