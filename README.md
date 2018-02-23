Timetracker REST API Sample Code
===================

This repo contains code samples for using the REST API's in Timetracker. The code is optimized to be simple and easy to understand.

The OData Connected Service Extension (http://odata.github.io/odata.net/#OData-Client-Code-Generation-Tool) has been used to build this code sample.
The T4 templates (ServiceReferences\Timetracker\TimetrackerProxy.tt, ServiceReferences\Timetracker\TimetrackerProxy.ttinclude) were modified since the original OData Connected Service Extension does not support spaces in the naming of entity members.

## TimetrackerOdataClient usage

This is a sample of the console application which connects to VSTS or On-premise version of Timetracker and returns all time records for last 3 months.
Command line parameters:

VSTS usage (token auth): 
```
TimetrackerOdataClient.exe ServiceURI -t Token -f VSTS_ACCOUNT_URL -v VSTS_TOKEN -a System.Tags,System.Title -x json
```

On-premise usage (NTLM auth):
```
TimetrackerOdataClient.exe ServiceURI -w -f TFS_URL_WITH_COLLECTION -a System.Tags,System.Title -x json
```
