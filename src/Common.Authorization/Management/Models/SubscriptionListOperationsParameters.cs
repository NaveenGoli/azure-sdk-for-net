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

using System;

namespace Microsoft.WindowsAzure.Management.Models
{
    /// <summary>
    /// Parameters supplied to the List Subscription Operations operation.
    /// </summary>
    public partial class SubscriptionListOperationsParameters
    {
        private string _continuationToken;
        
        /// <summary>
        /// Optional. When there are too many operations to list, such as when
        /// the requested timeframe is very large, the response includes an
        /// incomplete list and a token that can be used to return the rest of
        /// the list. Subsequent requests must include this parameter to
        /// continue listing operations from where the last response left off.
        /// If no token is specified, a filter is not applied and the response
        /// will begin at the specified StartTime.
        /// </summary>
        public string ContinuationToken
        {
            get { return this._continuationToken; }
            set { this._continuationToken = value; }
        }
        
        private DateTime _endTime;
        
        /// <summary>
        /// Required. The end of the timeframe to begin listing subscription
        /// operations in UTC format. This parameter and the StartTime
        /// parameter indicate the timeframe to retrieve subscription
        /// operations.
        /// </summary>
        public DateTime EndTime
        {
            get { return this._endTime; }
            set { this._endTime = value; }
        }
        
        private string _objectIdFilter;
        
        /// <summary>
        /// Optional. Returns subscription operations only for the specified
        /// object type and object ID. This parameter must be set equal to the
        /// URL value for performing an HTTP GET on the object. If no object
        /// is specified, a filter is not applied.
        /// </summary>
        public string ObjectIdFilter
        {
            get { return this._objectIdFilter; }
            set { this._objectIdFilter = value; }
        }
        
        private Microsoft.Azure.OperationStatus? _operationStatus;
        
        /// <summary>
        /// Optional. Returns subscription operations only for the specified
        /// result status, either Succeeded, Failed, or InProgress. This
        /// filter can be combined with the ObjectIdFilter to select
        /// subscription operations for an object with a specific result
        /// status. If no result status is specified, a filter is not applied.
        /// </summary>
        public Microsoft.Azure.OperationStatus? OperationStatus
        {
            get { return this._operationStatus; }
            set { this._operationStatus = value; }
        }
        
        private DateTime _startTime;
        
        /// <summary>
        /// Required. The start of the timeframe to begin listing subscription
        /// operations in UTC format. This parameter and the EndTime parameter
        /// indicate the timeframe to retrieve subscription operations. This
        /// parameter cannot indicate a start date of more than 90 days in the
        /// past.
        /// </summary>
        public DateTime StartTime
        {
            get { return this._startTime; }
            set { this._startTime = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the
        /// SubscriptionListOperationsParameters class.
        /// </summary>
        public SubscriptionListOperationsParameters()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the
        /// SubscriptionListOperationsParameters class with required arguments.
        /// </summary>
        public SubscriptionListOperationsParameters(DateTime startTime, DateTime endTime)
            : this()
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}
