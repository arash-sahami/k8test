# Problem
Event though we have assigned all kind of permission to the service account in the yaml file, the call to `ReadNamespacedPodStatusAsync`
fails probebly due to lack of previliges.

However the call to `DeleteNamespacedPodAsync` to delete an existing pod is successful.

What kind of configuration is needed for a successful call to `ReadNamespacedPodStatusAsync`?

Right now we are using the following configuration as a workaround.

```
shell kubectl create clusterrolebinding serviceaccounts-cluster-admin \
  --clusterrole=cluster-admin \
  --group=system:serviceaccounts
```
