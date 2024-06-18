# Project Title:
SimpleDapperVsDapperQueryMultiple.ConsoleApp

# Description:
A simple console application to compate the performance between a simple dapper query method and dapper QueryMultiple method interactinf with many queries.

# Docker scripts
- Get image from docker hub:
docker pull mcr.microsoft.com/mssql/server:2019-latest

- Run image:
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourPassword@123" -e "MSSQL_PID=Evaluation" -p 1433:1433  --name sql2019 --hostname sql2019 -d mcr.microsoft.com/mssql/server:2019-latest

- Exec (not required):
docker exec -it sql2019 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'YourPassword@123'
