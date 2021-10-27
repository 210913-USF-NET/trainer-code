#minikube and kubectl operations  

##Resources  
- minikube  
https://minikube.sigs.k8s.io/docs/handbook/controls/  

- kubectl  
https://kubernetes.io/docs/reference/generated/kubectl/kubectl-commands

##minikube basics
- `$minikube start`   
*starts minikube containers*
- `$minikube stop`  
*stops minikube containers*  

##kubectl (kube control) basics
###kubectl commands generally follow a "verb" "noun" structure
- `$kubectl get pods`  
*lists all pods in current context*
- `$kubectl get jobs`  
*lists all jobs in current context*

- `$kubectl create -f manifest.yml`  
*create a Kubernetes component based on the contents of manifest.yml*
- `$kubectl delete -f manifest.yml`  
*delete a Kubernetes component based on the contents of manifest.yml*


##Advanced Nonsense
- `$eval $(minikube -p minikube docker-env)`  
*directs current shell (terminal window) to store newly built docker images in a location minikube can access*
