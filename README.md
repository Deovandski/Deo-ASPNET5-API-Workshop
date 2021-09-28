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


## Notes


NTier API Desiging.

Caching Data

Versioning