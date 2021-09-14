# Bash
Bourne-again shell

## commands
- cd: Change directory
- ls: list contents
- pwd: present working directory (where you're right now)
- mkdir: Make new directory
- touch: makes new files
- rm: deletes stuff
    - ```rm -r``` for deleting folders
- **mv**: moves files/directories
    - ```mv currPath newPath```
    - also use mv to rename
- **cp**: Copies stuff
    - ```cp currfile newFileName```

## dotnet cli commands
- dotnet new console : creates new console app
- dotnet new classlib: creates new class library
- dotnet new sln : creates new file
    - -n to name your stuff from the get go
- dotnet run : to run your project (make sure you're in the project folder you want to run)
- dotnet build : to build your project
- dotnet restore : to restore all your dependencies for the project
- dotnet add reference : add project reference 
- dotnet sln <sln-name> add <project-name> : adds projects to sln
- dotnet watch run : watches for changes in the file and automatically recompiles and runs for you everytime you save your changes
