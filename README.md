# Searchfight

Console App that queries search engines and compares how many results they return, for example:

```
C:\SearchFight.exe .net java python
```

```
.net:
        Google: 227000000
        Bing: 72100000
        Ecosia: 72500000
java:
        Google: 1330000000
        Bing: 77600000
        Ecosia: 77700000
python:
        Google: 384000000
        Bing: 68200000
        Ecosia: 68200000

Google winner: java
Bing winner: java
Ecosia winner: java

Total winner: java
```
### Requirements

* .NET Framework 4.7.2

## How to add new Search Engine

You will need to edit the App.config file of the project in order to add a new search engine. For that you will need to provide

* name: Name of the search engine
* address: Url and path of the search engine
* queryParam: Query parameter that is used by the engine to perform a seach
* tagRegex: Regular expression that returns the html container of the total results
* valueRegex: Regular expression that returns the total result count

## Deployment

Compile the solution with visual studio and the exe will be generated.
