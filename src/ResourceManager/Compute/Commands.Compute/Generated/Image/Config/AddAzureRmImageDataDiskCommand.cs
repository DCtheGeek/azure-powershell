//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

// Warning: This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("Add", "AzureRmImageDataDisk", SupportsShouldProcess = true)]
    [OutputType(typeof(PSImage))]
    public partial class AddAzureRmImageDataDiskCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSImage Image { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        public int Lun { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true)]
        public string BlobUri { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true)]
        public CachingTypes? Caching { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public int DiskSizeGB { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public PSStorageAccountTypes? StorageAccountType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string SnapshotId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string ManagedDiskId { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Image", "Add"))
            {
                Run();
            }
        }

        private void Run()
        {
            // StorageProfile
            if (this.Image.StorageProfile == null)
            {
                this.Image.StorageProfile = new Microsoft.Azure.Management.Compute.Models.ImageStorageProfile();
            }

            // DataDisks
            if (this.Image.StorageProfile.DataDisks == null)
            {
                this.Image.StorageProfile.DataDisks = new List<Microsoft.Azure.Management.Compute.Models.ImageDataDisk>();
            }

            var vDataDisks = new Microsoft.Azure.Management.Compute.Models.ImageDataDisk();

            vDataDisks.Lun = this.Lun;
            vDataDisks.BlobUri = this.MyInvocation.BoundParameters.ContainsKey("BlobUri") ? this.BlobUri : null;
            vDataDisks.Caching = this.MyInvocation.BoundParameters.ContainsKey("Caching") ? this.Caching : (CachingTypes?) null;
            vDataDisks.DiskSizeGB = this.MyInvocation.BoundParameters.ContainsKey("DiskSizeGB") ? this.DiskSizeGB : (int?) null;
            if (this.MyInvocation.BoundParameters.ContainsKey("StorageAccountType"))
            {
                WriteWarning("Add-AzureRmImageDataDisk: The accepted values for parameter StorageAccountType will change in an upcoming breaking change release " +
                             "from StandardLRS and PremiumLRS to Standard_LRS and Premium_LRS, respectively.");
            }

            vDataDisks.StorageAccountType = this.MyInvocation.BoundParameters.ContainsKey("StorageAccountType") ? this.StorageAccountType.ToSerializedValue() : null;
            if (this.MyInvocation.BoundParameters.ContainsKey("SnapshotId"))
            {
                // Snapshot
                vDataDisks.Snapshot = new Microsoft.Azure.Management.Compute.Models.SubResource();
                vDataDisks.Snapshot.Id = this.SnapshotId;
            }
            if (this.MyInvocation.BoundParameters.ContainsKey("ManagedDiskId"))
            {
                // ManagedDisk
                vDataDisks.ManagedDisk = new Microsoft.Azure.Management.Compute.Models.SubResource();
                vDataDisks.ManagedDisk.Id = this.ManagedDiskId;
            }
            this.Image.StorageProfile.DataDisks.Add(vDataDisks);
            WriteObject(this.Image);
        }
    }
}

