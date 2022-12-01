﻿# app-api-nginx

This app is a simple example of api built in dotnet as MVC and sqlite as databse. To keep this api simple for deployment purpose it uses SQLITE with the help of Entity Framework provided by dotnet.

# For deployment

This app contains two important files 'docker-compose.yml' and 'Jenkinsfile'. To deploy this app into pipeline user must have working Jenkins Master and at least ONE Jenkins Slave machine. Both must have Docker and Docker-Compose installed (Otherwise build will fail).
User may need to make changes to the Jenkinsfile (Such as agent name) and must add docker access tokens as credentials in jenkins.
It does not require nginx installed explicitly since it will pull, bind and configure the nginx docker container with the app automatically.
