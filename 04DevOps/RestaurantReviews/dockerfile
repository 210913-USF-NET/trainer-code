#base image to start off with
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS Build

# declaring working directory
# We need this, to run copy, cd, those navigational commands
WORKDIR /app

# Copy over all the csproj and sln files from the directory dockerfile lives (RestaurantReviews) to the working directory in the image, so we can see if we can restore the deps before moving on
COPY *.sln ./
COPY BL/*.csproj ./BL/
COPY DL/*.csproj ./DL/
COPY WebUI/*.csproj ./WebUI/
COPY Tests/*.csproj ./Tests/
COPY Models/*.csproj ./Models/

# in the image, navigate to the WebUI folder, and restore the deps 
RUN cd WebUI && dotnet restore

#Copy the source code to the work directory
COPY . ./

# Build us a release version of WebUI, and then put it in the publish folder
# without restoring (we already did that a couple steps back)
RUN dotnet publish WebUI -c Release -o publish --no-restore

# Multistage build, to prune down our final image size (no source code, no sdk)
# as well as to hide source code away from end users
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS run

# declare my work directory as /app
WORKDIR /app

#from the build stage, copy only the built artifacts over to the run stage
# leaving behind the source code and the sdk
COPY --from=build /app/publish ./

# This is what gets executed when we "docker build" this image
CMD ["dotnet", "WebUI.dll"]