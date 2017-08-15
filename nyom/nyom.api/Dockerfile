FROM microsoft/aspnetcore:2.0
RUN mkdir /nyom
WORKDIR /nyom
COPY /bin/Release/netcoreapp2.0/ /nyom
ENTRYPOINT ["dotnet", "nyom.api.dll"]

#
#FROM microsoft/dotnet:latest
#RUN mkdir /nyom
#WORKDIR /nyom
#COPY /bin/Release/netcoreapp2.0/publish/ /nyom
#ENTRYPOINT ["dotnet","nyom.api.dll"]
