# Project Title:
SimpleDapperVsDapperQueryMultiple.ConsoleApp

# Description:
A simple console application to compare performance between a simple Dapper Query method and a Dapper QueryMultiple method interacting with many queries.

# Setup Instructions:
Prerequisites:
- Visual studio 2022 (VS2022) whit the ASP.NET and Web Development workload; [https://visualstudio.microsoft.com/pt-br/downloads/]
- .NET 8 SDK; [https://dotnet.microsoft.com/pt-br/download/dotnet/8.0]
- Git (optional but recommended). [https://www.git-scm.com/downloads]
- Docker: [https://www.docker.com/get-started/]

# Docker scripts
Execute this steps to setup database.
- Get image from docker hub:
<pre>docker pull mcr.microsoft.com/mssql/server:2019-latest</pre>

- Run image:
<pre>docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourPassword@123" -e "MSSQL_PID=Evaluation" -p 1433:1433  --name sql2019 --hostname sql2019 -d mcr.microsoft.com/mssql/server:2019-latest</pre>

- Exec (not required):
<pre>docker exec -it sql2019 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'YourPassword@123'</pre>

# Running Benchmark
- Open de project with VS2022;
- Build the solution;
- Setup project execution to Release;
- Execute project with the option "Start Without Debugging";

