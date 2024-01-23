@echo off

SET mysql_tool="G:\graphQL\src\mysqli\App\Reflector.exe"
SET current="./yilia_current.sql"
SET upgrade_to="./yilia.sql"

%mysql_tool% --compares /current %current% /updates %upgrade_to% /output "./upgrade_notes.md"