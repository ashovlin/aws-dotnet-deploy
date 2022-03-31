// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
// SPDX-License-Identifier: Apache-2.0

using AWS.Deploy.CLI.ServerMode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Annotations;

namespace AWS.Deploy.CLI.ServerMode.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IHostApplicationLifetime _applicationLifetime;

        public HealthController(IHostApplicationLifetime applicationLifetime)
        {
            _applicationLifetime = applicationLifetime;
        }

        /// <summary>
        /// Gets the health of the deployment tool. Use this API after starting the command line to see if the tool is ready to handle requests.
        /// </summary>
        [HttpGet]
        public HealthStatusOutput Get()
        {
            return new HealthStatusOutput
            {
                Status = SystemStatus.Ready
            };
        }

        /// <summary>
        /// Requests to stop the deployment tool. Any open sessions are implicitly closed.
        /// </summary>
        [HttpPost("Shutdown")]
        [SwaggerOperation(OperationId = "Shutdown")]
        public IActionResult Shutdown()
        {
            _applicationLifetime.StopApplication();
            return Ok();
        }
    }
}
