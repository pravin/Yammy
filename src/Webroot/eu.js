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
 * Language: Basque
 * Translator: Aitor Gomez Goiri
 * Contact: aitor@twolf.eu
 *
 */

var AppName    = "Yammy"; // Do not edit
var AppVersion = "0.9"; // Do not edit

var TrayMenuOpen     = "I&reki";
var TrayMenuSettings = "E&zarpenak";
var TrayMenuExit     = "&Irten";

// ConversationBetween
// {0} -> local user-id
// {1} -> remote user-id.
// ex: Conversation between jack and jill
var ConversationBetween = "{0} eta {1}-(r)en arteko elkarrizketa"; 

// ConversationStarted
// {0} -> date
// ex: Conversation started on January 26, 2007
var ConversationStarted = "{0}n hasitako elkarrizketa";

// NumSearchResults
// {0} -> starting number
// {1} -> total number
// ex. 11 of 2154 search results
var NumSearchResults = "Bilaketa emaitzak: {1}tik {0}";

// SearchingFor
// {0} -> search term
// ex. Searching for apple
// TotalConvos
// {0} -> number
var TotalConvos = "Elkarrizketa kopurua: {0}";

// LastConvo
// {0} -> Date
var LastConvo = "Azken elkarrizketa: {0}";

// Archiving
// {0} -> this will be one of 'Enabled' or 'Disabled' depending on status
var Archiving = "Biltegiratzea: {0}";

// ShowingConvoFor
// {0} -> user-id
// ex. Showing conversations for Jack
var ShowingConvoFor = "{0}-(r)ekin edukitako elkarrizketak erakusten";

var Error  = "Errorea"; // Generic error string
var Home   = "Etxeko orrialdea"; // Main page title
var More   = "Gehiago"; // Lets you view the whole conversation
var Hours  = "ordutan"; // Settings: Lets you set the indexing frequency
var Users  = "Erabiltzaileak"; // Local users on this system
var Search = "Bilatu"; // Search button text
var Help   = "Laguntza"; // Navigation: Takes you to the help page

var ViewLog  = "Ikusi Log-a"; // Navigation: Displays the log file
var Language = "Hizkuntza"; // Option in Settings: Lets you select your display language
var PrevPage = "Aurreko orrialdea"; // Takes you to the previous page while Searching or while browsing conversations
var NextPage = "Hurrengo orrialdea"; 
var Settings = "Ezarpenak"; // Navigation: Takes you to the settings page

var UpdateFreq   = "Eguneraketa maiztasuna";
var SaveSettings = "Gorde ezarpenak";
var ExportConvos = "Esportatu elkarrizketak";
var NoIndexFound = "Ez da indizerik aurkitu!";
var FileNotFound = "Ez da fitxategirik aurkitu";
var NoConvoFound = "Ez da elkarrizketarik aurkitu";
var SearchingFor = "{0}-z bilatuz"; // {0} -> search term
var VisitWebsite = "Web gunea bisitatu";

var NoResultsFound    = "Ezin izan dira emaitzarik lortu"; // When searching for something returns no results
var ArchivingEnabled  = "Gaituta";
var ArchivingEnable   = "Gaitu";   // Different from the above. This denotes the act of enabling
var ArchivingDisabled = "Desgaituta";
var ArchivingDisable  = "Desgaitu";  // Different from the above. This denotes the act of disabling
var GeneratedByYammy  = "Yammy 0.9rekin sortuta"; // The footer text
