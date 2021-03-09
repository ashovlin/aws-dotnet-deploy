// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;
using AWS.Deploy.Common;
using AWS.Deploy.Common.Recipes;

namespace AWS.Deploy.CLI.Commands.TypeHints
{
    public class DotnetPublishBuildConfigurationCommand : ITypeHintCommand
    {
        private readonly ConsoleUtilities _consoleUtilities;

        public DotnetPublishBuildConfigurationCommand(ConsoleUtilities consoleUtilities)
        {
            _consoleUtilities = consoleUtilities;
        }

        public async Task<object> Execute(Recommendation recommendation, OptionSettingItem optionSetting)
        {
            var settingValue = _consoleUtilities.AskUserForValue(string.Empty, recommendation.GetOptionSettingValue<string>(optionSetting), allowEmpty: false);
            recommendation.DeploymentBundle.DotnetPublishBuildConfiguration = settingValue;
            return settingValue;
        }
    }
}