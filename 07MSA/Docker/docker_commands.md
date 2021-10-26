##Docker operations

#Build Image
$Docker build .  #builds Dockerfile in current working directory
$Docker build -f ./child_dir  #builds Dockerfile in specified directory
$Docker build -f ./child_dir/Dockerfile.ubuntu
$Docker build -f ./child_dir/Dockerfile.centos  #builds Dockerfile with the corresponding name in the specified directory (useful for multiple environment deployments)
$Docker build . -t my_image  #builds Dockerfile in current working directory, and tags image as "my_image"

#Run Image
$Docker run my_image  #runs image "my_image" in a docker container.
$Docker run my_image -d  #runs image "my_image" in a docker container in the background (will not write to the current terminal)

#Manage Images
$Docker image ls
$Docker images  #list locally stored docker images
$Docker images -a  #list all locally stored docker images
$Docker images -q  #list image ids of locally stored docker images
$Docker image rm -f my_image #delete docker image "my_image"

#Manage Containers
$Docker container ls  #list locally stored docker containers
$Docker container ls -a  #list all locally stored docker containers
$Docker container ls -q  #list container ids of locally stored docker containers

#Docker Compose
$Docker-compose up  #run the compose.yml file in the current working directory
$Docker-compose down  #stop all containers in the currently running docker-compose environment
