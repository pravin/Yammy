/* Yammy 0.9 Language Resource File
 * (http://yammy.sourceforge.net)
 * 
 * Note to Translators:
 * - Please save this file in utf-8 format. To learn more about saving a file in utf-8, visit [TODO].
 * - & cause the next character to be underlined (Only for TrayMenuOpen, TrayMenuSettings, TraryMenuExit).
 * - {0}, {1}, {2}, etc are place holders which will be replaced by some data. Where ever they occur, an
 *   explaination is given with an example.
 * - Do fill in the Language, Name and Contact details.
 *
 * Language: Deutsch (German)
 * Translator: Denis Scollie
 * Contact: densco@users.sourceforge.net
 *
 */

var AppName    = "Yammy"; // Do not edit
var AppVersion = "0.9"; // Do not edit

var TrayMenuOpen     = "&Öffnen";
var TrayMenuSettings = "&Einstellungen";
var TrayMenuExit     = "&Beenden";

// ConversationBetween
// {0} -> local user-id
// {1} -> remote user-id.
// ex: Conversation between jack and jill
var ConversationBetween = "Unterhaltung zwischen {0} und {1}"; 

// ConversationStarted
// {0} -> date
// ex: Conversation started on January 26, 2007
var ConversationStarted = "Unterhaltung vom {0}";

// NumSearchResults
// {0} -> starting number
// {1} -> total number
// ex. 11 of 2154 search results
var NumSearchResults = "{0} von {1} Ergebnissen";

// SearchingFor
// {0} -> search term
// ex. Searching for apple
// TotalConvos
// {0} -> number
var TotalConvos = "Gesamt: {0}";

// LastConvo
// {0} -> Date
var LastConvo = "Letzte Unterhaltung: {0}";

// Archiving
// {0} -> this will be one of 'Enabled' or 'Disabled' depending on status
var Archiving = "Archivierung: {0}";

// ShowingConvoFor
// {0} -> user-id
// ex. Showing conversations for Jack
var ShowingConvoFor = "Zeige Unterhaltungen von {0}";

var Error  = "Fehler"; // Generic error string
var Home   = "Home"; // Main page title
var More   = "Mehr"; // Lets you view the whole conversation
var Hours  = "Std."; // Settings: Lets you set the indexing frequency
var Users  = "Benutzer"; // Local users on this system
var Search = "Suche"; // Search button text
var Help   = "Hilfe"; // Navigation: Takes you to the help page

var ViewLog  = "Zeige Log"; // Navigation: Displays the log file
var Language = "Sprache"; // Option in Settings: Lets you select your display language
var PrevPage = "Letzte Seite"; // Takes you to the previous page while Searching or while browsing conversations
var NextPage = "Nächste Seite"; 
var Settings = "Einstellungen"; // Navigation: Takes you to the settings page

var UpdateFreq   = "Aktualisierung";
var SaveSettings = "Einstellungen speichern";
var ExportConvos = "Exportieren";
var NoIndexFound = "Kein Index gefunden!";
var FileNotFound = "Keine Datei gefunden!";
var NoConvoFound = "Keine Unterhaltung gefunden!";
var SearchingFor = "Suche nach {0}"; // {0} -> search term
var VisitWebsite = "Website besuchen";

var NoResultsFound    = "Keine Ergebnisse"; // When searching for something returns no results
var ArchivingEnabled  = "Aktiviert";
var ArchivingEnable   = "Aktivieren";   // Different from the above. This denotes the act of enabling
var ArchivingDisabled = "Deaktiviert";
var ArchivingDisable  = "Deaktivieren";  // Different from the above. This denotes the act of disabling
var GeneratedByYammy  = "Erstellt von Yammy 0.9"; // The footer text
