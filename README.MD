# Trust local https certificate
* dotnet dev-certs https --clean
* dotnet dev-certs https --trust

## fix Git Warning: LF will be replaced by CRLF
* run git rm --cached
* git config --global core.autocrlf false
* git config --local core.autocrlf false

### run backend api, run command : yarn nswag-admin -> auto gen api in angualar