# gracefullshutdownworker

Test project to handle SIGTERM notifications gracefully
The worker will try and finish the work it's doing by delaying the shutdown of the application and not dequeue more messages

*Tested*
Local (handle CTRL-C)
Docker Desktop 
Kubernetes / Container Apps -> KEDA Autoscaling will shutdown the POD
