FROM microsoft/dotnet:latest
RUN mkdir /nyom
WORKDIR /nyom
COPY /bin/Release/netcoreapp1.1/publish/ /nyom
ENTRYPOINT ["dotnet","nyom.workflow.dll"]