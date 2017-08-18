FROM microsoft/aspnetcore:2.0
RUN mkdir /nyom
WORKDIR /nyom
COPY /bin/Release/netcoreapp2.0/ /nyom
ENTRYPOINT ["dotnet", "nyom.api.dll"]


