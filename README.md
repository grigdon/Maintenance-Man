Spring '25 Software Engineering Capstone Application:
**Collaborators**: Gabe, Joab, and Jack.

**Configuration Steps**:
Step 0: Install Visual Studio 2022 OR Jetbrains Rider
    --> Either of these IDEs will make working with the C# backend much, much easier than VS Code. In my opinion, Rider is a bit more lightweight, but both will be fine.

Step 1: Accept the new invite I sent on github. 
    --> The repo name should be "Maintenance-Man" instead of "Maintenance-Manager"
    --> I will be deleting "Maintenance-Manager" soon, as I needed to create a fresh repo for the initial commit.

Step 2: Install node.js && npm (node package manager)

    https://nodejs.org/en
    --> installs node.js
    --> installs npm (node package manager)
    --> installs all requirements for react.js (and vite)

    ## These are the linux commands. They may work on Windows powershell though.
    run "node -v" (linux)
    run "npm -v" (linux)

    Ensure versions match:

        node version: v22.XX.X
        npm version: v11.X.X

    ## Note: I have already created the react app and have it pushed to the repo, so just ensure that the versions align so that we can all run the client application locally.
    ##       We will be using "vite" under npm to create the react app. This should not be super important, but in the case that you want to experiment on your own, sub
    ##       "npm create-react-app client-name {flags}" with npm create vite@latest client-name {flags}". The vite creation utility initializes a faster react app out of the box.
    ##       Additionally, we will be using typescript because of better debugging capabilities, which I think we will all benefit from.


Step 3: Install/update git (if you have not already) && clone the repository
    Install git: https://gitforwindows.org/
    
    Set up user profile on git:
        Follow man pages here: https://docs.github.com/en/get-started/getting-started-with-git/set-up-git
    
    Configure Project Directory:
    --> create a project folder on your local machine with whatever name you want
    --> cd to the project directory
    --> clone the repo: "git clone https://github.com/YOUR_USER_NAME_HERE/Maintenance-Man.git"

## At this point, you should have an IDE of your choice installed, VS Code, Git, Node.js, npm, and the project repository on your local machine.
## Now that everything is downloaded and installed, you can verify that all the installs were performed correctly. 

Step 4: Verifying installs. 
    Frontend:
    --> cd to your project directory
    --> inside of this directory, there should be two more directories: "api" and "client"
    --> cd to "client"
    --> run "npm install" ## This installs all prerequisite packages for the react app; this command DOES NOT need to be ran every time as far as I am aware.
    --> run "npm run dev" to start the local client server.
    --> ctrl+click the localhost URL to verify the server is active. A web browser tab with a react + vue logo should launch now.
    --> To quit the server session, pres "q+enter" in powershell/cmd.

    ## Assuming this all went properly, the frontend is live at this point and can be edited.
    ## Getting react to work properly was kind of finicky for me; I tried a variety of package managers and so far, npm create vite@latest has been the easiest
    ## This was the hard part. Verifying the backend (C#) will be the easy part.
    
    Backend:
    --> Launch your IDE. Instead of creating a new project, open an existing project.
    --> Navigate to "your_project_directory" and within that directory, open the "api folder" in your IDE
    --> Your IDE will launch with all the files loaded. At this point, you can simply hit the green play button in the upper right toolbar. 
    --> If all goes well, it will launch a swagger web API suite with a demo "weatherforecast" API. This template will be the basis of our web API.

## This is the end of the requirments for this doc.
## At a later date, we will implement the database portion (PostgreSQL or MongoDB), but for now, we will use a mock database. Version control for the DB will also be addressed later.

  A 'tracker' style web application aimed at organizing DIY car maintenance records. This app utilizes a Vite + React frontend and an ASP.NET backend.
