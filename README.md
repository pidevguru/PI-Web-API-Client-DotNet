PI Web API client for .NET
===

## Overview
This repository has the source code package of the PI Web API client for .NET, which compiles for .NET Standard 2.0 and .NET Framework 4.5.2. PI Web API 2018 swagger specification was used to create this package.

## Requirements

 - PI Web API 2018+ instance available on your domain or a public network.


## Compability

This library is compatible with:

- .NET Framework 4.5.2+
- .NET 6+

## Installation

 - Search for "PIDevGuru.PIWebApiClient" on NuGet and download the latest version.

 
## Documentation

All PI Web API server methods are mapped on this client. Please refer to [PI Web API help page](https://docs.aveva.com/bundle/pi-web-api-reference/page/help). 

 ### Create an instance of the PI Web API top level object using Kerberos authentication.

```cs
	PIWebAPI client = new PIWebAPI("https://mywebserver/piwebapi/");  
``` 

If you want to use basic authentication instead of Kerberos:

```cs
	client.SetBasicAuth("username", "password"); 
``` 


### Get the PI Data Archive WebId

```cs
	PWADataServer dataServer = client.DataServer.GetByPath("\\\\PISERVER");
```

### Create a new PI Point

```cs
	PWAPoint newPIPoint = new PWAPoint();
	newPIPoint.Name = "NewPoint"
	newPIPoint.Descriptor = "PointDescription"
	newPIPoint.PointClass = "classic"
	newPIPoint.PointType = "Float32"
	var httpResponse = client.dataServer.CreatePointWithHttp(dataServer.webId, newPIPoint)
```

### Get PI Point Web ID using the path using Async or Sync methods

```cs
	PWAPoint point1 = client.Point.GetByPath("\\\\PISERVER\\sinusoid");
	PWAPoint point2 = await client.Point.GetByPathAsync("\\\\PISERVER\\sinusoidu");
```

### Get recorded values in bulk using the StreamSet/GetRecordedAdHoc

```cs
	List<string> webIds = new List<string>() { point1.WebId, point2.WebId };
	PWAItemsStreamValues piItemsStreamValues = client.StreamSet.GetRecordedAdHoc(webIds, startTime: "*-3d", endTime: "*");
```


### Get element and its attributes given an AF Element path

```cs
	PWAElement element = client.Element.GetByPath("ElementPath");
	PWAItemsAttribute attributes = client.Element.GetAttributes(element.WebId, null, 1000, null, false);
```

### Generating WebID 2.0 in the client

```cs
	WebIdGenerator webIdGenerator = new WebIdGenerator();
	string webId1 = webIdGenerator.GenerateWebIdByPath("AttributePath", typeof(PWAAttribute), typeof(PWAElement));
	string webId2 = webIdGenerator.GenerateWebIdByPath("DataServerPath", typeof(PWADataServer));
```




## Licensing
Copyright 2023 PIDevGuru.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   
Please see the file named [LICENSE.md](LICENSE.md).
