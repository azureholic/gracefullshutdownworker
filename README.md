# Shut down a background worker gracefully (test project)

Azure Containers Apps supports scaling to zero instances, using KEDA.
When running a background worker, KEDA might shutdown your POD while it's still handling a message.

This project was setup to handle a shutdown request, and delays it (in this case with 10 seconds). This gives the worker a chance to finish the work and prevent the application to dequeue another message.

**Tested with**

* Local (handle CTRL+C)
* Docker Desktop (shutdown container)
* Kubernetes/Container Apps (KEDA scale down POD eviction)


It seems to work, although when your background job takes longer than 30 seconds, you might want to consider not using auto-scaling and if you do, be idempotent.