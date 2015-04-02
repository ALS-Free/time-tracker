time:tracker


What is it?
-------------------------------

time:tracker is a free program you can track your time with.
Create a task, than stop the time for it.

Multiple Users for the time:tracker application can be created.
Each user can create, edit and delete task and also track the 
time for these tasks.

There are also Admins which can overwatch all users. They can
set the requierd logging time and can check if the users are exceeding
this time. Finally they can export these statistics into 
an excel spreadsheet. 



What do you need to install it?
-------------------------------
.Net Framework 4.5
MS Sql Server

How do i install it?
-------------------------------
1.Create the Database you want the time:tracker installed
2.Create the Database user to connect to the Database 
(The user must have create rights to create the tables time:tracker will use)
3.Execute the msi package you downloaded
4.When there is a dialoge prompt asking you to input your database information input 
the DataSource, Database name, Username and password to connect to the database
5.When you get here the installation is finished


How to set it up
-------------------------------
On the first run there will be only one user. This users name is 
admin and this users password is also admin. You want to change that
immediately. Then you can create other users that can login.

Now you are good to go.


Known Problems
------------------------------
Wrong Configuration File gets loaded. The wrong configuartion file gets loaded when an older version of time:tracker was
installed on this machine before.

Solution: Delete the old configuration File
C:\Users\{Username}\AppData\Local\VirtualStore\Program Files (x86)\CoastCom Consulting\TimeTracker\TimeTracker.exe.config


License
-------------------------------

Copyright (c) 2015 Alexander Sommer

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.