FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# copy the .sln and .csproj files into /src/<folder> (minimally required to get dependencies)
COPY CourseRegistrationSystem.sln ./
COPY CourseRegistrationSystem/CourseRegistrationSystem.csproj CourseRegistrationSystem/
COPY CourseRegistrationSystem.Tests/CourseRegistrationSystem.Tests.csproj CourseRegistrationSystem.Tests/
# get all dependencies
RUN dotnet restore CourseRegistrationSystem.sln

# copy everything else into /src
COPY . ./
# create a release build for the main project into /app/build
RUN dotnet build CourseRegistrationSystem -c Release -o /app/build --no-restore

# publish this main project by creating a .dll file
FROM build AS publish 
RUN dotnet publish CourseRegistrationSystem -c Release -o /app/publish

# make this image an executable
FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS final
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "CourseRegistrationSystem.dll" ]