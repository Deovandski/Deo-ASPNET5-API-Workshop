# Deo-ASPNET5-API-Workshop

## Info
Result from a VS Live! 2021 workshop I attended regarding .NET 5 Api Course.

## SQL Server Notice

The guy who created the workshop instructions forgot the small fact that you need to spin up a SQL Server instance... A small detail (not).

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

I still have to see if I can connect through the ODBC... Might be a pain in the arse if I did not setup ODBC configs, if there are any to do.
