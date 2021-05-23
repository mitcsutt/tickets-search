# Zendesk Coding Challenge

* [Running the app](#running-the-app)
* [Using the app](#using-the-app)
* [Assumptions](#assumptions)

## Running the app
The app can be run in two ways

### Docker
1. Clone the project
2. Navigate to the projects root directory
3. Build the docker image
```
docker build -t tickets-search -f Dockerfile .
```
4. Run the application
```
docker run -it --rm tickets-search
```
### .NET
1. Ensure you have dotnet cli installed on your computer
2. Navigate to the projects root directory
3. Change directory to the ./TicketsSearch directory
4. Run dotnet build
```
dotnet build
```
5. Run dotnet run
```
dotnet run
```

## Using the app
The app search across all 3 data sets on all fields. There are 2 commands you can use in the app
```
search: runs the search command
  input: The raw text to be searched for
  example: >search Mitchell Sutton
  
q: exits the app
```

## Assumptions
1. The submitter_id and assignee_id fields on the Ticket object refer to the User
