# Git

Git is a distributed version control system that helps developers to collaborate over a code base. It also is an extremely helpful backup system.

## Commonly used git commands
- ```git clone <git-repo-url>```: Clones a repository from a remote source (ie github)
- ```git add <path-to-file-or-folder>```: Adds changes from a file or folder to staging area
- ```git commit -m "<meaningful-commit-message-here>"```: Commits staged changes to the working tree with the message provided
- ```git push```: pushes changes in local repository to the remote repository
    - ```git push --set-upstream <branch-name>```: pushes to the <branch-name> branch in remote repository and creates a new <branch-name> branch if there isn't one already. Furthermore, it pairs the current branch to the <branch-name> branch so in the future, all ```git push``` command in that branch will be equivalent to ```git push origin <branch-name>```
- ```git pull```: pulls changes from the remote repository to the local repository
    - Want to pull from a remote branch different from the current tracking one? use ```git pull origin <branch-name>```
- ```git merge <branch-name>```: Merges the <branch-name> branch to the current branch
- ```git status```: Displays you the currently staged files
- ```git branch```: Displays all the branches in the local repository
    - ```git branch <name>```: Creates a new branch named <name>
    - ```git branch -d <name>```: Deletes <name> branch
- ```git checkout <name>```: Checks out the <name> branch. 
    - ```git checkout -b <name>```: Creates a new branch named <name> And checks out that branch.
- ```git init```: Initializes the git repository in the current directory (basically, makes the .git folder)
- ```git log```: Displays commit history of the current working tree
- ```git stash```: Need to stash away your current changes real quick before pulling/checking out different branch? Use this command
    - ```git stash pop```: Use this to retrieve the latest stashed change

## Troubleshooting
- "Help, I didn't use -m flag when I was committing and I can't get out of vi/vim!"
    - Do not despair
    - vi/vim editors use commands starting with colon(:) to execute various function (ie, :i for inserting new text, :q for quitting)
    - The command you need to get out of it is :q. Don't forget the colon!
- "I tried merging with my teammate's branch, and we got a merge conflict!"
    - Look in your file tree in your code editor/IDE. If you have git extension, the ones with merge conflicts should be colored bright red or have some sort of indication.
    - The merge conflicts will be displaying two conflicting changes. One in your current repository, and another from where you were trying to merge.
    - Figure out which change you want, and manually resolve those. Sometimes it's as easy as accept current or incoming, but sometimes you'll have to keep some of both parts.
    - Finally, commit those changes.
- "I... pushed build outputs/db connection string to github"
    - First, make a gitignore file that ignores those files.
    - then run ```git rm --cached <file>``` or ```git rm -r --cached <folder>``` to remove the files and/or folders you don't want being tracked from remote repository but keep it in your local repository.
- "OH NO. MY CODE BROKE BEYOND ALL REPAIR"
    - Also do not despair
    - This is one of the main benefits of using git AND commiting frequently
    - First, do ```git log``` to figure out which commit was the last commit with working code
    - Once you decide on the commit, copy the first 5-6 letters of that long commit id
    - Type 'q' to get out of the log screen
    - Then, run ```git reset --hard <commit-id>``` to reset your code base to the point of that commit.

## Generating .gitignore file
- If your application consists of only .NET stuff, and you need to only ignore .NET files, you can simply use ```dotnet new gitignore``` command at the root source directory to have .NET sdk generate one for you
- If your stack is bigger than plain old .NET, [gitignore.io](https://gitignore.io) can help.
- if you want to ignore any additional files those templatese did not include for you, just add the file/folder path to the gitignore file