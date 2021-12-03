Developer: Ilan Cherniavsky
ID: 211818414
Email: Omnislasher1808@gmail.com

Project title: Gym UI
Project description:
This is a simple UI - Supposed to represent a GYM website (I don't really know HTML).
In this project there are simple actions mostly button clicks but everything will be
Explained here in this .txt file about all the functionality of the program.

Included subjects:
Design patterns and interfaces (State & Singleton)

Excluded subjects:
Paypal navigation
Gmail navigation
======================================================================================

MainWindow:

The main window is a login window which connects to the GYMDB database and validate
if the ID is exists and if true, validate the password.
If all tests ended successfully - the window closes and the main UI opens up.
If the tests returned falsive answer the user need to be registered or recover password
via Register button or Forgot Password? button.

See code behind at MainWindow.xaml and MainWindow.xaml > MainWindow.xaml.cs

======================================================================================

Register window:

The register window requires from the user to give his own personal data so the
program can manipulate the data and proceed with progress.

The programs data requirements have several validation codes which checks for each
content such as Email, Password, min-max age.

Since this is a Prototype program I've skipped the validation of the ID due no knowledge
on connecting to govermental databases.
Same idea about the Email and addresses.

After the users inserted the data and clicked register button the program starts Validation
proccess to all its data requirements.
If the test ended successfully the program inserts the users data to SQL database and then
navigates to Login window.

The data stored in the Utilities > Utilities.cs class to pervent repeating long code and
connection to the database.

See code behind at UserInterface >  Register.xaml and UserInterface >  Register.xaml > Register.xaml.cs

Half of the validation methods are stored in the register.cs class and some of them in the Validation
Folder
See at UserInterface > Validation > ValidationControl.cs

======================================================================================

Password recovery: 

Password recovery proccess built from 2 windows:
First one validates the email on the database. If the email exists the current
Window closes and the Password recovery window shows up.

As i said.
Since this is a prototype program i've skipped the Email connection and validation on
Google database.
So basically anyone can hack into anyones account and change things easly.

 In the password recovery window the user overrides the data inside the SQL database
 and sets to the new desired password.

 See code at UserInterface > ForgotPasswordEmail and UserInterface > ForgotPasswordEmail > ForgotPasswordEmail.cs
 UserInterface > ForgotPasswordRecovery and UserInterface > ForgotPasswordRecovery > ForgotPasswordRecovery.cs

 ======================================================================================

 MainUI:

