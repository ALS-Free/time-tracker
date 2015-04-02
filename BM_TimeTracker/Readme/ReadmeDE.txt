time:tracker

Was ist das?
-------------------------------

Der time:tracker ist ein Programm mit dem Sie die Zeit die 
Sie für Aufgaben gebraucht haben festhalten können.

Sie erstellen also eine Aufgabe und stoppen nun die Zeit für
die entsprechende Aufgabe.

Verschiedene Benutzer können den time:tracker benutzen um die
Zeiten mitschreiben zu lassen. Jeder Benutzer kann für sich
Aufgaben erstellen, bearbeiten und löschen. Und natürlich die
Zeit festhalten.

Zudem gibt es Administratoren die den Überblick über alle Benutzer
die den time:tracker benutzt haben. Sie können die mindestens geforderte 
Zeit die festgehalten werden muss, bestimmen und überprüfen ob die Benutzer
diese Zeit auch erreichen. Zudem können sie die festgehaltenen Zeiten
in eine Excel Datei exportieren lassen.


Installationsanforderungen
-------------------------------
.Net Framework 4.5
Microsoft SQL Server 2008 oder höher

Installationsanweisungen
-------------------------------
1.Erstellen Sie eine Datenbank für die Speicherung der Daten für den time:tracker
2.Erstellen Sie den Datenbankbenutzer um sich mit der time:trackerdatenbank zu verbinden
(Der Benutzer muss Erstellrechte haben damit Tabellen erstellt werden können)
3.Führen Sie das heruntergeladene MSI-Paket aus
4.Im Laufe der Installation müssen Sie DataSource, Datenbankname, Benutzername sowie Passwort angeben
5.An diesem Punkt ist die Installation abgeschlossen


Der erste Start
-------------------------------
Beim ersten Start der Anwendung, gibt es nur einen Benutzer. Sein Name ist "Admin",
sein Passwort ist "admin". Sie sollten das Passwort ändern. Danach können Sie neue Benutzer
erstellen. 

Viel Erfolg bei der Benutzung des time:trackers


Bekannte Probleme
------------------------------
Falsche Konfigurationsdatei wird geladen. Kann auftauchen wenn vor der Installation von time:tracker 
bereits eine andere Version von time:tracker installiert war

Lösung: Alte Konfigurationsdatei löschen
C:\Benutzer\{Benutzername}\AppData\Local\VirtualStore\Program Files (x86)\CoastCom Consulting\TimeTracker\TimeTracker.exe.config


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