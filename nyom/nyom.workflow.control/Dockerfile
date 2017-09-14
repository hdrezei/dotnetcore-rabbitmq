FROM microsoft/dotnet
RUN mkdir /nyom
WORKDIR /nyom
COPY /bin/Release/netcoreapp2.0/publish/ /nyom
ENTRYPOINT ["dotnet","nyom.workflow.control.dll"]