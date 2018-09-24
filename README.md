# SmallestNumberTrifon
Find the smallest number that can be divided by a sequential set of numbers
2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
360360 is the smallest number that can be divided by each of the numbers from 1 to 15 without any remainder.
And so on..
What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 25?
The application should be wrapped around two REST controllers, one to set the upper number to check(e.g. 25).

Download the application and unzip in some folder.
open cmd (the console) 
Navigate to that folder
e.g. c:\users\your name\
if it is unzipped on the desktop
go to:
c:\users\uour name\desktop\smallestnumbertrifon\smallestnumbertrifon
write:
dotnet restore  => click enter
dotnet run => click enter

you will see a screen and at the end:
Now listening on: https://localhost:5001
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.
coppy the link https://localhost:5001 and add swagger or the other below and add in Chrome or Firefox URL : e.g. : https://localhost:5001/swagger and click enter
probabbly you will see 
Your connection is not private
Attackers might be trying to steal your information from localhost (for example, passwords, messages, or credit cards). Learn more
NET::ERR_CERT_AUTHORITY_INVALID
 
Automatically send some system information and page content to Google to help detect dangerous apps and sites. Privacy policy
Click on ADVANCED and then click on Proceed to localhost (unsafe)

click on POST
/api/Settings/LimitSet
then click on Try it out and fill id = 1, limit = 25
{
  "messageBody": {
    "upperLimit": {
      "id": 1,
      "limit": 25
    }
  }
}
click Execute to see the result
Response body
{
  "id": 1,
  "limit": 25
}

You can play with different numbers
then do the same with GET
/api/Settings/FetchLimit
here there are no parameters. Click Try it out and Execute.

Play with the other services ...

If you want to see the code, unzip the file, open with Visual Studio or Visual Studio Code or Notepad++ and enjoy


