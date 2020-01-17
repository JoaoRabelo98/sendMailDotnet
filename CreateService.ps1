

$workdir = "C:\SendMail"

# Create the new service.
New-Service -name SendMail `
  -displayName SendMail `
  -binaryPathName "`"$workdir\sendMailDotnet.exe`"  -path.home `"$workdir`""

# Attempt to set the service to delayed start using sc config.
Try {
  Start-Process -FilePath sc.exe -ArgumentList 'config SendMail start= manual'
}
Catch { Write-Host -f red "An error occured setting the service to delayed start." }
