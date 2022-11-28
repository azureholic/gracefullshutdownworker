# Shut down a background worker gracefully (test project)

Azure Containers Apps supports scaling to zero instances, using KEDA.
When running a background worker, KEDA might shutdown your POD while it's still handling a message.

This project was setup to handle a shutdown request, and delays it (in this case with 10 seconds). This gives the worker a chance to finish the work and prevent the application to dequeue another message.

**Tested with**

* Local (handle CTRL+C)
* Docker Desktop (shutdown container)
* Kubernetes/Container Apps (KEDA scale down POD eviction)

It seems to work, although when your background job takes longer than 30 seconds, you might want to consider not using auto-scaling and if you do, be idempotent.

References to documentation
[https://learn.microsoft.com/en-us/azure/container-apps/scale-app](https://learn.microsoft.com/en-us/azure/container-apps/scale-app)

* Container Apps implements the KEDA [ScaledObject](https://keda.sh/docs/concepts/scaling-deployments/#details) and HTTP scaler with the following default settings.
    * pollingInterval: 30 seconds
    * cooldownPeriod: 300 seconds


