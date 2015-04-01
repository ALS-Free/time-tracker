#time:tracker

time:tracker is a free open source software you can track your time with.  
It is a WindowsForms Application and requires a SQL-Server.

#How to install

##1. Create Database/Database User

time:tracker needs a database to save it's data to. So first we will have to create this database. After that you will have to create a database user to connect time:tracker to this database. This data will be also required in the installation by the wizard

##2. Installation

###2a Automatic

Download the .msi package from http://gettimetracker.de and execute it. When you will be asked for your database information from step one enter it. Finished.

###2b Manual
Clone this repository <a>https://github.com/ALS-Free/time-tracker.git</a>. Load the project in your visual studio or IDE of your choice.

Copy the contents of the install.txt file located under /sqlscripts. Execute them in your created database to create the tables and the stored procedures you need for time:tracker

Navigate to the app.config file. Enter the database information under the section "connectionStrings". For example.

```xml
 <connectionStrings>
    <add name="SQLConnection" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=*YourDatabase*;User ID=*YourDatabaseUserId*;Password=*YourDatabaseUserPassword*" />
  </connectionStrings>
```
Compile it. Deploy it.


#How to use
  
##1. First things First... Logging In  
  
When you first start the time:tracker there will be a username and a password field.  
If you already have a user, enter your username and your password and hit enter.  
  
If you dont have a user, in the next step we discuss creating one.  

###1b. Creating a User  
So you don't have a user for yourself. That's no problem we create one.  
First click on the "New User"-Link in the login form. It will take you to the   
"New User"-Form.   
Enter a username and a password and click save.  
  
##2. Using time:tracker  
So now you are logged in and ready to use the time:tracker. That's great.  
On the left side you will seee some Buttons named "Logout", "Start", "Pause" and   
"Book it".  

Under these buttons is the overview over your tasks for the day. Curently it's empty  
but we will change that in a minute.  
  
Click the "Start"-Button to create a new task. A task named "In Progress" will appear  
in your overview. Currently its internal and there is no time logged for it.  
Over time the number in the field "Time in minutes" will increase.  
If you want to pause this task simply click the task and the click the "pause"-button,  
or click the "pause"-button in the same row as the task. 
  
There are 3 Buttons in the task row of your overview "Pause"/"Start", "Edit" and "Delete"  
The "pause" and "start" Button you can use to start and pause the task in the same row.  
The delete Button deletes the task from you overview.  
  
Now we want to change the name of the task. Simply press the "Edit"-Button in the same row  
as the task you want to change. The Form "Booking" will appear where you can change the name,  
if the task is internal and the date of the task.  
  
So now we are finished with our first task. So we want to finish it.  
We click the task we want to finish and click "Book it". The form "Booking" will appear again,  
but now we can also change the time in minutes we needed for this task. If you click save   
the task will be finished. You can't start the task again but you can edit the time anytime   
you like.  
  
##3. Other Things  
  
###3a Only show active tasks  
On the right side you will see a checkbox named "Only active tasks". If you check it only the active  
and all not finished tasks will appear in your overview.  
  
###3b Critical days  
Right in the upper middle you will see a list with the title "critical days". Whenever there is an entry  
there means you did not log enough time on this day to break the requiered logged time which was  
chosen by the administrator.  
Double click on an entry to jump to the specified date.  
  
###3c Change Password  
Click on this button to change your password. A form similar to the "New User"-Form will appear. 
Enter your old password and your new password. Click save. Now you have a new password.  



#License

time:tracker by Alexander Sommer

To the extent possible under law, the person who associated CC0 with
time:tracker has waived all copyright and related or neighboring rights
to time:tracker.

You should have received a copy of the CC0 legalcode along with this
work.  If not, see <http://creativecommons.org/publicdomain/zero/1.0/>.

