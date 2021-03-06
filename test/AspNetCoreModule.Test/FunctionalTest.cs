﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AspNetCoreModule.Test.Framework;
using Microsoft.AspNetCore.Testing.xunit;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreModule.Test
{
    public class FunctionalTest : FunctionalTestHelper, IClassFixture<InitializeTestMachine>
    {
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        public async void BasicTest(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            await DoBasicTest(appPoolBitness);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, 5)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, 5)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, 1)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, 0)]
        public Task RapidFailsPerMinuteTest(IISConfigUtility.AppPoolBitness appPoolBitness, int valueOfRapidFailsPerMinute)
        {
            return DoRapidFailsPerMinuteTest(appPoolBitness, valueOfRapidFailsPerMinute);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, 25, 19)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, 25, 19)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, 5, 4)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, 5, 4)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, 0, 0)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, 0, 0)]
        public Task ShutdownTimeLimitTest(IISConfigUtility.AppPoolBitness appPoolBitness, int valueOfshutdownTimeLimit, int expectedClosingTime)
        {
            return DoShutdownTimeLimitTest(appPoolBitness, valueOfshutdownTimeLimit, expectedClosingTime);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, 10)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, 10)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, 1)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, 1)]
        public Task StartupTimeLimitTest(IISConfigUtility.AppPoolBitness appPoolBitness, int starupTimeLimit)
        {
            return DoStartupTimeLimitTest(appPoolBitness, starupTimeLimit);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        public Task RecycleApplicationAfterBackendProcessBeingKilled(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoRecycleApplicationAfterBackendProcessBeingKilled(appPoolBitness);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        public Task RecycleApplicationAfterW3WPProcessBeingKilled(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoRecycleApplicationAfterW3WPProcessBeingKilled(appPoolBitness);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        public Task RecycleApplicationAfterWebConfigUpdated(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoRecycleApplicationAfterWebConfigUpdated(appPoolBitness);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        public Task RecycleApplicationWithURLRewrite(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoRecycleApplicationWithURLRewrite(appPoolBitness);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        public Task RecycleParentApplicationWithURLRewrite(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoRecycleParentApplicationWithURLRewrite(appPoolBitness);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData("ANCMTestBar", "bar", "bar", IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData("ASPNETCORE_HOSTINGSTARTUPASSEMBLIES", "NA", "Microsoft.AspNetCore.Server.IISIntegration", IISConfigUtility.AppPoolBitness.noChange)]
        [InlineData("ASPNETCORE_HOSTINGSTARTUPASSEMBLIES", "newValue", "newValue", IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData("ASPNETCORE_IIS_HTTPAUTH", "anonymous;", "anonymous;", IISConfigUtility.AppPoolBitness.noChange)]
        [InlineData("ASPNETCORE_IIS_HTTPAUTH", "basic;anonymous;", "basic;anonymous;", IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData("ASPNETCORE_IIS_HTTPAUTH", "windows;anonymous;", "windows;anonymous;", IISConfigUtility.AppPoolBitness.noChange)]
        [InlineData("ASPNETCORE_IIS_HTTPAUTH", "windows;basic;anonymous;", "windows;basic;anonymous;", IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData("ASPNETCORE_IIS_HTTPAUTH", "ignoredValue", "anonymous;", IISConfigUtility.AppPoolBitness.noChange)]
        public Task EnvironmentVariablesTest(string environmentVariableName, string environmentVariableValue, string expectedEnvironmentVariableValue, IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoEnvironmentVariablesTest(environmentVariableName, environmentVariableValue, expectedEnvironmentVariableValue, appPoolBitness);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        public Task AppOfflineTestWithRenaming(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoAppOfflineTestWithRenaming(appPoolBitness);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        public Task AppOfflineTestWithUrlRewriteAndDeleting(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoAppOfflineTestWithUrlRewriteAndDeleting(appPoolBitness);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, "abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789")]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, "a")]
        public Task PostMethodTest(IISConfigUtility.AppPoolBitness appPoolBitness, string testData)
        {
            return DoPostMethodTest(appPoolBitness, testData);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        public Task DisableStartUpErrorPageTest(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoDisableStartUpErrorPageTest(appPoolBitness);
        }

        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, 10)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, 2)]
        public Task ProcessesPerApplicationTest(IISConfigUtility.AppPoolBitness appPoolBitness, int valueOfProcessesPerApplication)
        {
            return DoProcessesPerApplicationTest(appPoolBitness, valueOfProcessesPerApplication);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, "00:02:00")]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, "00:02:00")]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, "00:01:00")]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, "00:01:00")]
        public Task RequestTimeoutTest(IISConfigUtility.AppPoolBitness appPoolBitness, string requestTimeout)
        {
            return DoRequestTimeoutTest(appPoolBitness, requestTimeout);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        public Task StdoutLogEnabledTest(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoStdoutLogEnabledTest(appPoolBitness);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, "dotnet.exe", "./")]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, "dotnet", @".\")]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, "$env", "")]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, "$env", "")]
        public Task ProcessPathAndArgumentsTest(IISConfigUtility.AppPoolBitness appPoolBitness, string processPath, string argumentsPrefix)
        {
            return DoProcessPathAndArgumentsTest(appPoolBitness, processPath, argumentsPrefix);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, true)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, false)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, true)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, false)]
        public Task ForwardWindowsAuthTokenTest(IISConfigUtility.AppPoolBitness appPoolBitness, bool enabledForwardWindowsAuthToken)
        {
            return DoForwardWindowsAuthTokenTest(appPoolBitness, enabledForwardWindowsAuthToken);
        }

        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, true, true)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, false, false)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, true, false)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, false, true)]
        public Task CompressionTest(IISConfigUtility.AppPoolBitness appPoolBitness, bool useCompressionMiddleWare, bool enableIISCompression)
        {
            return DoCompressionTest(appPoolBitness, useCompressionMiddleWare, enableIISCompression);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        public Task CachingTest(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoCachingTest(appPoolBitness);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        public Task SendHTTPSRequestTest(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoSendHTTPSRequestTest(appPoolBitness);
        }
        
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, true)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, true)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, false)]
        public Task ClientCertificateMappingTest(IISConfigUtility.AppPoolBitness appPoolBitness, bool useHTTPSMiddleWare)
        {
            return DoClientCertificateMappingTest(appPoolBitness, useHTTPSMiddleWare);
        }

        //////////////////////////////////////////////////////////
        // NOTE: below test scenarios are not valid for Win7 OS
        //////////////////////////////////////////////////////////
        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [OSSkipCondition(OperatingSystems.Windows, WindowsVersions.Win7, SkipReason = "IIS does not support Websocket on Win7")]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit, "abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789")]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange, "a")]
        public Task WebSocketTest(IISConfigUtility.AppPoolBitness appPoolBitness, string testData)
        {
            return DoWebSocketTest(appPoolBitness, testData);
        }

        [ConditionalTheory]
        [ANCMTestSkipCondition("RunAsAdministratorAndX64Bitness")]
        [OSSkipCondition(OperatingSystems.Linux)]
        [OSSkipCondition(OperatingSystems.MacOSX)]
        [OSSkipCondition(OperatingSystems.Windows, WindowsVersions.Win7, SkipReason = "WAS does not handle private memory limitation with Job object on Win7")]
        [InlineData(IISConfigUtility.AppPoolBitness.enable32Bit)]
        [InlineData(IISConfigUtility.AppPoolBitness.noChange)]
        public Task RecylingAppPoolTest(IISConfigUtility.AppPoolBitness appPoolBitness)
        {
            return DoRecylingAppPoolTest(appPoolBitness);
        }
    }
}
