try
{
    $response = Invoke-WebRequest -Uri "https://gooogle.com.br" -ErrorAction Stop
    # This will only execute if the Invoke-WebRequest is successful.
    $StatusCode = $Response.StatusCode
}
catch
{
    dotnet run
}