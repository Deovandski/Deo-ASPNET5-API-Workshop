# Deo-ASPNET5-API-Workshop
Result from a workshop I attended.

The guy who created the workshop instructions forgot the small fact that you need to spin up a SQL Server instance... Ops.

Grab the express from here (which is the counterpart for the SMSS)

https://www.microsoft.com/en-us/sql-server/sql-server-downloads


Then setup the Local Database Engine

*You have to find where SqlLocalDb ended up.

C:\Program Files\Microsoft SQL Server\130\Tools\Binn

*This is where I found mine. Now run:

SqlLocalDb create "MyInstance"
SqlLocalDb info "MyInstance"
SqlLocalDb start "MyInstance"

https://www.mssqltips.com/sqlservertip/5612/getting-started-with-sql-server-2017-express-localdb/

Now go back to SMSS

(localdb)\MyInstance is the serverName

and follow the rest of the instructions