# MVCCoreStarterKit
## Overview

### Q. What is in this repository?

### A. This is a simple example using an MVC Visual Studio project template with Izenda Embedded into it. This repository is only an example of integrating Izenda into another application. The Visual Studio project template used in this scenario is used as a substitute for your application. This repository shows examples of how you might embed Izenda into your application.

 :warning: **The MVC Kit is designed for demonstration purposes and should not be used as an “as-is” fully-integrated solution. You can use the kit for reference or a baseline but ensure that security and customization meet the standards of your company.**
 
## Getting Started 
### Files and Folders
Download the v2.19.0 (https://downloads.izenda.com/v2.19.0/) of the API and EmbeddedUI and copy the following:

All files & folders inside (Exclude: Resources, Content, EmailTemplates, Export, Themes):
- API -> MVCCoreStarterKit\IzendaReferences

The folder itself for:
- API\Content -> MVCCoreStarterKit\IzendaResources
- API\EmailTemplates -> MVCCoreStarterKit\IzendaResources
- API\Export -> MVCCoreStarterKit\IzendaResources
- API\Themes -> MVCCoreStarterKit\IzendaResources
- All files & folders inside EmbeddedUI -> MVCCoreStarterKit\MVCCoreStarterKit\wwwroot\js\izenda

Deploy:
The folder itself for:
- API\Resources -> root folder of application
- API\Content -> root folder of application
- API\EmailTemplates -> root folder of application
- API\Export -> root folder of application
- API\Themes -> root folder of application
- All files & folders inside EmbeddedUI -> <root folder of application>\wwwroot\js\izenda

### Databases
Creating the Izenda database
This is the database for the Izenda configuration. It contains report definitions, dashboards,etc.
- Create a database named 'IzendaMVC'. You may use any name of your choosing, just be sure to modify the script below to use the new database name.
- Download and execute the <a href="https://github.com/Izenda7Series/MVCCoreStarterKit/blob/master/SQLScript/MSSQL/IzendaMVC.sql">IzendaMVC.sql</a> script.
- Upgrade database version from v2.6.20 to v2.19.0 (https://tools.izenda.com/)
- Modify the <a href="https://github.com/Izenda7Series/MVCCoreStarterKit/blob/master/MVCCoreStarterKit/izendadb.config">izendadb.config</a> file with a valid connection string to this new database.

```json
{"ServerTypeId":"572bd576-8c92-4901-ab2a-b16e38144813","ServerTypeName":"[MSSQL] SQLServer","ConnectionString":"[Your Izenda Configuration Database Connection String Here]","ConnectionId":"00000000-0000-0000-0000-000000000000"}

``` 

Creating the MVCCoreStarterKit database
This is the database for the Mvc Core application. It contains the users, roles, tenants used to login.
- Create a database named 'MVCCoreStarterKit'. You may use any name of your choosing, just be sure to modify the script below to use the new database name.
- Download and execute the <a href="https://github.com/Izenda7Series/MVCCoreStarterKit/blob/master/SQLScript/MSSQL/MVCCoreStarterKit.sql">MVCCoreStarterKit.sql</a> script.

- Modify the appsettings.config file with a valid connection string to this new database.

```
{
	"ConnectionStrings": {
		"DefaultConnection": "[your MVC Database Connection String here]"
	}
	// others
}
``` 

Examle client database
This is the database which we will be a resoure for creating reports,...
- Create a new database named 'Retail' or anything which you like.
- Run script located at MVCCoreStarterKit\SQLScript\MSSQL\RetailDbScript.sql

### Application Settings
Run Application and login by System Admin Account below:
- Tenant : System
- Username: IzendaAdmin@system.com
- Password: Izenda@123

After start up and logging in as Admin Go to Settings on top Nav
- Add Izenda License Key and Token
- Go to Data Setup > Connection String  add the connection string to the Retail database created above for system and all tenants and move tables/views to visible
   More Info here:<a href="https://www.izenda.com/docs/ui/doc_connection_string.html?highlight=connection%20string" /> How To Set Up A Connection String</a>
   
- In Data Setup > Advanced Settings > Security Set the Tenant Field to [CustomerID] (please ensure you use the brackets) for each Tenant / CustomerID in the Retail Database are the tenants  (DELDG/NATWR/RETCL) and this will filter data
   based on the current user's TenantID
   More Info here: <a href = "https://www.izenda.com/docs/ui/doc_advanced_settings.html?highlight=set%20tenant%20field#update-settings-in-security-tenant-group"/> Updating settings in Performance, Security/Additive Fields and Others group </a> 

- For each Role in the tenant set datamodel access (what tables / views each role can access)
  More Info here: <a href = "https://www.izenda.com/wiki7/ui/doc_role_setup.html?highlight=role%20setup" /> How To Set Up A Role</a>

### Tenants, Users, and Roles
For each Tenant the following users / roles are configured all use the same password: Izenda@123

Tenant: DELDG <br />
User: employee@deldg.com        Role: employee <br />
User: manager@deldg.com         Role: manager <br />
User: vp@deldg.com              Role: VP <br />

Tenant: NATWR <br />
User: employee@natwr.com        Role: employee <br />
User: manager@natwr.com         Role: manager <br />
User: VP@natwr.com              Role: VP <br />

Tenant: RETCL <br />
User: employee@retcl.com        Role: employee <br />
User: manager@retcl.com         Role: manager <br />
User: vp@retcl.com              Role: VP <br />

When registering a new user in this sample all users are hardcoded to the manager role here:
~\MVCCoreStarterKit\MVCCoreStarterKit\Areas\Identity\Pages\Account\Register.cshtml.cs (Line 75)	

Please review the following file:
~\MVCCoreStarterKit\MVCCoreStarterKit\IzendaBoundary\CustomAdhocReport.cs
This is where you can find samples for:
Hidden Filters
Filter Dropdown Overrides
See more information here: <a href="https://www.izenda.com/wiki7/dev/ref_iadhocextension.html?highlight=iadhocextension" /> All About IAdhocExtension, Hidden Filters, and Filter Dropdown Overrides </a>


The CSS can be configured per tenant and an example is provided see below:
This is configured here ~\MVCCoreStarterKit\MVCCoreStarterKit\Views\_Layout.cshtml
And folder structures are located here ~\MVCCoreStarterKit\MVCCoreStarterKit\wwwroot\Content


## Post Installation

 :warning: In order to ensure smooth operation of this kit, the items below should be reviewed.
 
 
### Exporting

Update the WebUrl value in the IzendaSystemSetting table with the URL for your front-end. You can use the script below to accomplish this. As general best practice, we recommend backing up your database before making any manual updates.

```sql

UPDATE [IzendaSystemSetting]
SET [Value] = '<your url here including the trailing slash>'
WHERE [Name] = 'WebUrl'

``` 

If you do not update this setting, charts and other visualizations may not render correctly when emailed or exported. This will also be evident in the log files as shown below:

`[ERROR][ExportingLogic ] Convert to image:
System.Exception: HTML load error. The remote content was not found at the server - HTTP error 404`
