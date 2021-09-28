# Deo-ASPNET5-API-Workshop

## Info
Result from a VS Live! 2021 workshop I attended regarding .NET 5 Api Course.

https://github.com/cwoodruff/aspnet-5-web-api-workshop

https://woodruff.dev/aspnet-5-web-api-workshop/

## SQL Server Notice

Setting up localdb

Grab the SQL Server 2019 from here (which is the counterpart for the SMSS)

https://www.microsoft.com/en-us/sql-server/sql-server-downloads
**Make sure to select LOCAlDB Under feature selection, and that you are installing 2019**

Then setup & start the Local Database Engine

*You have to find where SqlLocalDb ended up.

    C:\Program Files\Microsoft SQL Server\150\Tools\Binn

*You have to be at v150 as that is the version the bak file was created against. Now run:

    SqlLocalDb create "MyInstance"
    SqlLocalDb start "MyInstance"
    SqlLocalDb info "MyInstance"

**Make sure it is running**

Now go back to SMSS

(localdb)\MyInstance is the serverName

and follow the rest of the instructions using the bak file.

## Testing ODBC
On VS, Open Server Explorer and add Server. Select Microsoft SQL Server.

Server Name

    (LocalDb)\MyInstance

    
Authentication

    Windows Authentication

Database Name

    Chinook

Now test connection. If it worked, then you good. Otherwise, you're SOL.

Now right click the db on VS Server Explorer and run this SQL

    CREATE LOGIN [Hue] WITH PASSWORD = 'topsecret';
    CREATE USER [Hue] FOR LOGIN [Hue];
    exec sp_addrolemember 'db_owner', 'Hue'


This is the user C# is using to do do stuff... Also ConfigureConnection has a nice modifier with RuntimeConfiguration to distinguish between Windows vs Linux. That helps some, but because we have to deal with the AS400, we will still need to play chair games between db2 vs db2-lnx nugets

## Notes

HEAD HTTP Method

Insert POST resulting 201 which we do.
DELETE as 204, no content.
PUT do need to use 304 (Not modified) when update did not change anything.

NTier API Desiging. The name behind the .Domain, .Data, etc.

Why entities and interface are on Domain? Because it makes it easier to have multiple "Data" type projects such as DataEf/DataJson, etc. So no more .Services type of project.

Code On Demand... Metadata for callback links. The actual name for the process to return 201 on inserts.

Caching Data vs Reliability. Not really an issue since we go full stateless.
https://woodruff.dev/aspnet-5-web-api-workshop/Standing%20Up%20an%20ASP.NET%20Core%20Web%20API/caching-data/




Really nice website.
https://www.connectionstrings.com/

See Produce/Consume. Preferable to set it on a Controller level for all HTTP Body Content.

Manual "Automapper" is a thing, but AutoMapper is better.

Partial Class --> See ChinookSupervisor

Supervisor Concept. Insead of DI'ing repositories, we would have this layer above that is the main connective. He also used it due to the supervisor also holding the Validators. For my use case, since we use the decorators validation & modelState, we do not seem to need it.

Versioning.. To be discussed

FluentValidation is not bad, but the built-in validation with decorators pattern (modelState validation) we use is more straight forward. The excuse to avoid Decorators is because testing against them is difficult. I clearly remember seeing 400s because of bad mock data I was randomly generating through NUnit.
 Note to Self -- Check if NUnit is giving metadata (test passed, etc) on the decorators themselves

## Bad Habit Notes

Calling Data Access from Controllers. Repositories fix that, so we should be good.

Break up into projects of a solution. .API, .Domain, .Data, .Tests. .Shared does not seem standard, but rather a folder in the .Domain.

Coupling Data Access to Domain... Again, Repositories fix that.


## Additional Content

Dapper is a thing. Had no idea.

EF Core It is not good for a huge domain model. This means that Sales Reports Engine, and other thigns on the AS400 we have will be harder to deal with.
https://entityframework.net/ef-vs-dapper
