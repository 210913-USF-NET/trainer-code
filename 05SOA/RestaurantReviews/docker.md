# Docker Cli Commands

### To build an image
- docker build -t "username/image-name:tag-name" "relative-path-to-dockerfile"
- ie: docker build -t sminseonong/rrdemo:latest . (the dockerfile is at the folder i'm executing the docker command in)

### To Push to dockerhub
- docker push "the-image-name"
- make sure your image has the username in front, otherwise, authorization error will occur

### To see all the images in your local machine
- docker image ls

### To remove an image
- docker image rm "image-name/id"

### To see all your containers in your local machine
- docker container ls

### To run an image in a container
- docker run "image-name"

### To expose the port to your host machine
- docker run -p host:container "image-name"