time:tracker

Was ist das?
-------------------------------

Der time:tracker ist ein Programm mit dem Sie die Zeit die 
Sie f�r Aufgaben gebraucht haben festhalten k�nnen.

Sie erstellen also eine Aufgabe und stoppen nun die Zeit f�r
die entsprechende Aufgabe.

Verschiedene Benutzer k�nnen den time:tracker benutzen um die
Zeiten mitschreiben zu lassen. Jeder Benutzer kann f�r sich
Aufgaben erstellen, bearbeiten und l�schen. Und nat�rlich die
Zeit festhalten.

Zudem gibt es Administratoren die den �berblick �ber alle Benutzer
die den time:tracker benutzt haben. Sie k�nnen die mindestens geforderte 
Zeit die festgehalten werden muss, bestimmen und �berpr�fen ob die Benutzer
diese Zeit auch erreichen. Zudem k�nnen sie die festgehaltenen Zeiten
in eine Excel Datei exportieren lassen.


Installationsanforderungen
-------------------------------
.Net Framework 4.5
Microsoft SQL Server 2008 oder h�her

Installationsanweisungen
-------------------------------
1.Erstellen Sie eine Datenbank f�r die Speicherung der Daten f�r den time:tracker
2.Erstellen Sie den Datenbankbenutzer um sich mit der time:trackerdatenbank zu verbinden
(Der Benutzer muss Erstellrechte haben damit Tabellen erstellt werden k�nnen)
3.F�hren Sie das heruntergeladene MSI-Paket aus
4.Im Laufe der Installation m�ssen Sie DataSource, Datenbankname, Benutzername sowie Passwort angeben
5.An diesem Punkt ist die Installation abgeschlossen


Der erste Start
-------------------------------
Beim ersten Start der Anwendung, gibt es nur einen Benutzer. Sein Name ist "Admin",
sein Passwort ist "admin". Sie sollten das Passwort �ndern. Danach k�nnen Sie neue Benutzer
erstellen. 

Viel Erfolg bei der Benutzung des time:trackers


Bekannte Probleme
------------------------------
Falsche Konfigurationsdatei wird geladen. Kann auftauchen wenn vor der Installation von time:tracker 
bereits eine andere Version von time:tracker installiert war

L�sung: Alte Konfigurationsdatei l�schen
C:\Benutzer\{Benutzername}\AppData\Local\VirtualStore\Program Files (x86)\CoastCom Consulting\TimeTracker\TimeTracker.exe.config


License
-------------------------------

time:tracker by Alexander Sommer

To the extent possible under law, the person who associated CC0 with
time:tracker has waived all copyright and related or neighboring rights
to time:tracker.

You should have received a copy of the CC0 legalcode along with this
work.  If not, see <http://creativecommons.org/publicdomain/zero/1.0/>.