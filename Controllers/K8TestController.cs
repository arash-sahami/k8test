using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace K8Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class K8TestController : ControllerBase
    {
        private readonly ILogger<K8TestController> _logger;
        private readonly IKubernetes _kubernetes;

        public K8TestController(ILogger<K8TestController> logger, IKubernetes kubernetes)
        {
            _logger = logger;
            _kubernetes = kubernetes;
        }

        [HttpGet]
        public async Task<JsonResult> GetPodStatus(string podDnsName, string podNamespace)
        {
            _logger.LogInformation($"Get pod status for {podDnsName}.");

            k8s.Models.V1Pod v1Pod  = await _kubernetes.ReadNamespacedPodStatusAsync(podDnsName, podNamespace);
            return new JsonResult(v1Pod);
        }

        [HttpDelete]
        public async Task<JsonResult> DeletePod(string podDnsName, string podNamespace)
        {
            _logger.LogInformation($"Deleting pod status for {podDnsName}.");

            k8s.Models.V1Pod v1Pod = await _kubernetes.DeleteNamespacedPodAsync(podDnsName, podNamespace);
            return new JsonResult(v1Pod);
        }
    }
}
