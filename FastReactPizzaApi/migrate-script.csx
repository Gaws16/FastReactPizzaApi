using System.Diagnostics;

var host = Environment.GetEnvironmentVariable("SUPABASE_DB_HOST");
var port = Environment.GetEnvironmentVariable("SUPABASE_DB_PORT");
var dbName = Environment.GetEnvironmentVariable("SUPABASE_DB_NAME");
var user = Environment.GetEnvironmentVariable("SUPABASE_DB_USER");
var password = Environment.GetEnvironmentVariable("SUPABASE_DB_PASSWORD");

// Step 1: Generate SQL migration script
var efProcess = Process.Start(new ProcessStartInfo("dotnet", "ef migrations script -o migrations.sql") 
{
    RedirectStandardOutput = true,
    RedirectStandardError = true
});
efProcess.WaitForExit();

// Step 2: Apply script using psql
var psqlCommand = $"\"host={host} port={port} dbname={dbName} user={user} password={password} sslmode=require\" -f migrations.sql";
var psqlProcess = Process.Start(new ProcessStartInfo("psql", psqlCommand)
{
    RedirectStandardOutput = true,
    RedirectStandardError = true
});
psqlProcess.WaitForExit();
