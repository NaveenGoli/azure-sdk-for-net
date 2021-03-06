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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.DataFactories
{
    /// <summary>
    /// Operations for managing data slices.
    /// </summary>
    internal partial class DataSliceOperations : IServiceOperations<DataPipelineManagementClient>, IDataSliceOperations
    {
        /// <summary>
        /// Initializes a new instance of the DataSliceOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal DataSliceOperations(DataPipelineManagementClient client)
        {
            this._client = client;
        }
        
        private DataPipelineManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.DataFactories.DataPipelineManagementClient.
        /// </summary>
        public DataPipelineManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Gets the first page of data slice instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='tableName'>
        /// Required. A unique table instance name.
        /// </param>
        /// <param name='dataSliceRangeStartTime'>
        /// Required. The data slice range start time in round-trip ISO 8601
        /// format.
        /// </param>
        /// <param name='dataSliceRangeEndTime'>
        /// Required. The data slice range end time in round-trip ISO 8601
        /// format.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List data slices operation response.
        /// </returns>
        public async Task<DataSliceListResponse> ListAsync(string resourceGroupName, string dataFactoryName, string tableName, string dataSliceRangeStartTime, string dataSliceRangeEndTime, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (resourceGroupName != null && resourceGroupName.Length > 1000)
            {
                throw new ArgumentOutOfRangeException("resourceGroupName");
            }
            if (Regex.IsMatch(resourceGroupName, "^[-\\w\\._\\(\\)]+$") == false)
            {
                throw new ArgumentOutOfRangeException("resourceGroupName");
            }
            if (dataFactoryName == null)
            {
                throw new ArgumentNullException("dataFactoryName");
            }
            if (dataFactoryName != null && dataFactoryName.Length > 63)
            {
                throw new ArgumentOutOfRangeException("dataFactoryName");
            }
            if (Regex.IsMatch(dataFactoryName, "^[A-Za-z0-9]+(?:-[A-Za-z0-9]+)*$") == false)
            {
                throw new ArgumentOutOfRangeException("dataFactoryName");
            }
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }
            if (tableName != null && tableName.Length > 260)
            {
                throw new ArgumentOutOfRangeException("tableName");
            }
            if (Regex.IsMatch(tableName, "^[A-Za-z0-9_][^<>*#.%&:\\\\+?/]*$") == false)
            {
                throw new ArgumentOutOfRangeException("tableName");
            }
            if (dataSliceRangeStartTime == null)
            {
                throw new ArgumentNullException("dataSliceRangeStartTime");
            }
            if (dataSliceRangeEndTime == null)
            {
                throw new ArgumentNullException("dataSliceRangeEndTime");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("dataFactoryName", dataFactoryName);
                tracingParameters.Add("tableName", tableName);
                tracingParameters.Add("dataSliceRangeStartTime", dataSliceRangeStartTime);
                tracingParameters.Add("dataSliceRangeEndTime", dataSliceRangeEndTime);
                TracingAdapter.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "/subscriptions/" + (this.Client.Credentials.SubscriptionId == null ? "" : Uri.EscapeDataString(this.Client.Credentials.SubscriptionId)) + "/resourcegroups/" + Uri.EscapeDataString(resourceGroupName) + "/providers/Microsoft.DataFactory/datafactories/" + Uri.EscapeDataString(dataFactoryName) + "/tables/" + Uri.EscapeDataString(tableName) + "/slices?";
            url = url + "start=" + Uri.EscapeDataString(dataSliceRangeStartTime);
            url = url + "&end=" + Uri.EscapeDataString(dataSliceRangeEndTime);
            url = url + "&api-version=2015-01-01-preview";
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-client-request-id", Guid.NewGuid().ToString());
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    DataSliceListResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new DataSliceListResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken valueArray = responseDoc["value"];
                            if (valueArray != null && valueArray.Type != JTokenType.Null)
                            {
                                foreach (JToken valueValue in ((JArray)valueArray))
                                {
                                    DataSlice dataSliceInstance = new DataSlice();
                                    result.DataSlices.Add(dataSliceInstance);
                                    
                                    JToken startValue = valueValue["start"];
                                    if (startValue != null && startValue.Type != JTokenType.Null)
                                    {
                                        DateTime startInstance = ((DateTime)startValue);
                                        dataSliceInstance.Start = startInstance;
                                    }
                                    
                                    JToken endValue = valueValue["end"];
                                    if (endValue != null && endValue.Type != JTokenType.Null)
                                    {
                                        DateTime endInstance = ((DateTime)endValue);
                                        dataSliceInstance.End = endInstance;
                                    }
                                    
                                    JToken statusValue = valueValue["status"];
                                    if (statusValue != null && statusValue.Type != JTokenType.Null)
                                    {
                                        string statusInstance = ((string)statusValue);
                                        dataSliceInstance.Status = statusInstance;
                                    }
                                    
                                    JToken latencyStatusValue = valueValue["latencyStatus"];
                                    if (latencyStatusValue != null && latencyStatusValue.Type != JTokenType.Null)
                                    {
                                        string latencyStatusInstance = ((string)latencyStatusValue);
                                        dataSliceInstance.LatencyStatus = latencyStatusInstance;
                                    }
                                    
                                    JToken retryCountValue = valueValue["retryCount"];
                                    if (retryCountValue != null && retryCountValue.Type != JTokenType.Null)
                                    {
                                        int retryCountInstance = ((int)retryCountValue);
                                        dataSliceInstance.RetryCount = retryCountInstance;
                                    }
                                    
                                    JToken longRetryCountValue = valueValue["longRetryCount"];
                                    if (longRetryCountValue != null && longRetryCountValue.Type != JTokenType.Null)
                                    {
                                        int longRetryCountInstance = ((int)longRetryCountValue);
                                        dataSliceInstance.LongRetryCount = longRetryCountInstance;
                                    }
                                }
                            }
                            
                            JToken odatanextLinkValue = responseDoc["@odata.nextLink"];
                            if (odatanextLinkValue != null && odatanextLinkValue.Type != JTokenType.Null)
                            {
                                string odatanextLinkInstance = ((string)odatanextLinkValue);
                                result.NextLink = odatanextLinkInstance;
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Gets the next page of data slice instances with the link to the
        /// next page.
        /// </summary>
        /// <param name='nextLink'>
        /// Required. The url to the next data slices page.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List data slices operation response.
        /// </returns>
        public async Task<DataSliceListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            // Validate
            if (nextLink == null)
            {
                throw new ArgumentNullException("nextLink");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("nextLink", nextLink);
                TracingAdapter.Enter(invocationId, this, "ListNextAsync", tracingParameters);
            }
            
            // Construct URL
            string url = nextLink;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-client-request-id", Guid.NewGuid().ToString());
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    DataSliceListResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new DataSliceListResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken valueArray = responseDoc["value"];
                            if (valueArray != null && valueArray.Type != JTokenType.Null)
                            {
                                foreach (JToken valueValue in ((JArray)valueArray))
                                {
                                    DataSlice dataSliceInstance = new DataSlice();
                                    result.DataSlices.Add(dataSliceInstance);
                                    
                                    JToken startValue = valueValue["start"];
                                    if (startValue != null && startValue.Type != JTokenType.Null)
                                    {
                                        DateTime startInstance = ((DateTime)startValue);
                                        dataSliceInstance.Start = startInstance;
                                    }
                                    
                                    JToken endValue = valueValue["end"];
                                    if (endValue != null && endValue.Type != JTokenType.Null)
                                    {
                                        DateTime endInstance = ((DateTime)endValue);
                                        dataSliceInstance.End = endInstance;
                                    }
                                    
                                    JToken statusValue = valueValue["status"];
                                    if (statusValue != null && statusValue.Type != JTokenType.Null)
                                    {
                                        string statusInstance = ((string)statusValue);
                                        dataSliceInstance.Status = statusInstance;
                                    }
                                    
                                    JToken latencyStatusValue = valueValue["latencyStatus"];
                                    if (latencyStatusValue != null && latencyStatusValue.Type != JTokenType.Null)
                                    {
                                        string latencyStatusInstance = ((string)latencyStatusValue);
                                        dataSliceInstance.LatencyStatus = latencyStatusInstance;
                                    }
                                    
                                    JToken retryCountValue = valueValue["retryCount"];
                                    if (retryCountValue != null && retryCountValue.Type != JTokenType.Null)
                                    {
                                        int retryCountInstance = ((int)retryCountValue);
                                        dataSliceInstance.RetryCount = retryCountInstance;
                                    }
                                    
                                    JToken longRetryCountValue = valueValue["longRetryCount"];
                                    if (longRetryCountValue != null && longRetryCountValue.Type != JTokenType.Null)
                                    {
                                        int longRetryCountInstance = ((int)longRetryCountValue);
                                        dataSliceInstance.LongRetryCount = longRetryCountInstance;
                                    }
                                }
                            }
                            
                            JToken odatanextLinkValue = responseDoc["@odata.nextLink"];
                            if (odatanextLinkValue != null && odatanextLinkValue.Type != JTokenType.Null)
                            {
                                string odatanextLinkInstance = ((string)odatanextLinkValue);
                                result.NextLink = odatanextLinkInstance;
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Sets status of data slices over a time range for a specific table.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='tableName'>
        /// Required. A unique table instance name.
        /// </param>
        /// <param name='parameters'>
        /// Required. The parameters required to set status of data slices.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async Task<AzureOperationResponse> SetStatusAsync(string resourceGroupName, string dataFactoryName, string tableName, DataSliceSetStatusParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (resourceGroupName != null && resourceGroupName.Length > 1000)
            {
                throw new ArgumentOutOfRangeException("resourceGroupName");
            }
            if (Regex.IsMatch(resourceGroupName, "^[-\\w\\._\\(\\)]+$") == false)
            {
                throw new ArgumentOutOfRangeException("resourceGroupName");
            }
            if (dataFactoryName == null)
            {
                throw new ArgumentNullException("dataFactoryName");
            }
            if (dataFactoryName != null && dataFactoryName.Length > 63)
            {
                throw new ArgumentOutOfRangeException("dataFactoryName");
            }
            if (Regex.IsMatch(dataFactoryName, "^[A-Za-z0-9]+(?:-[A-Za-z0-9]+)*$") == false)
            {
                throw new ArgumentOutOfRangeException("dataFactoryName");
            }
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }
            if (tableName != null && tableName.Length > 260)
            {
                throw new ArgumentOutOfRangeException("tableName");
            }
            if (Regex.IsMatch(tableName, "^[A-Za-z0-9_][^<>*#.%&:\\\\+?/]*$") == false)
            {
                throw new ArgumentOutOfRangeException("tableName");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("dataFactoryName", dataFactoryName);
                tracingParameters.Add("tableName", tableName);
                tracingParameters.Add("parameters", parameters);
                TracingAdapter.Enter(invocationId, this, "SetStatusAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "/subscriptions/" + (this.Client.Credentials.SubscriptionId == null ? "" : Uri.EscapeDataString(this.Client.Credentials.SubscriptionId)) + "/resourcegroups/" + Uri.EscapeDataString(resourceGroupName) + "/providers/Microsoft.DataFactory/datafactories/" + Uri.EscapeDataString(dataFactoryName) + "/tables/" + Uri.EscapeDataString(tableName) + "/slices/setstatus?";
            if (parameters.DataSliceRangeStartTime != null)
            {
                url = url + "start=" + Uri.EscapeDataString(parameters.DataSliceRangeStartTime);
            }
            if (parameters.DataSliceRangeEndTime != null)
            {
                url = url + "&end=" + Uri.EscapeDataString(parameters.DataSliceRangeEndTime);
            }
            url = url + "&api-version=2015-01-01-preview";
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Put;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-client-request-id", Guid.NewGuid().ToString());
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Serialize Request
                string requestContent = null;
                JToken requestDoc = null;
                
                JObject dataSliceSetStatusParametersValue = new JObject();
                requestDoc = dataSliceSetStatusParametersValue;
                
                if (parameters.SliceStatus != null)
                {
                    dataSliceSetStatusParametersValue["SliceStatus"] = parameters.SliceStatus;
                }
                
                if (parameters.UpdateType != null)
                {
                    dataSliceSetStatusParametersValue["UpdateType"] = parameters.UpdateType;
                }
                
                requestContent = requestDoc.ToString(Newtonsoft.Json.Formatting.Indented);
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    AzureOperationResponse result = null;
                    // Deserialize Response
                    result = new AzureOperationResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
