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
 * Language: Romanian
 * Translator: Pravin Paratey
 * Contact: pravinp at gmail dot com
 *
 */

var AppName    = "Yammy"; // Do not edit
var AppVersion = "0.9"; // Do not edit

var TrayMenuOpen     = "&Deschide";
var TrayMenuSettings = "&Setari";
var TrayMenuExit     = "I&esire";

// ConversationBetween
// {0} -> local user-id
// {1} -> remote user-id.
// ex: Conversation between jack and jill
var ConversationBetween = "Conversatie intre {0} si {1}"; 

// ConversationStarted
// {0} -> date
// ex: Conversation started on January 26, 2007
var ConversationStarted = "Conversatia a inceput la {0}";

// NumSearchResults
// {0} -> starting number
// {1} -> total number
// ex. 11 of 2154 search results
var NumSearchResults = "{0} din {1} rezultate";

// SearchingFor
// {0} -> search term
// ex. Searching for apple
// TotalConvos
// {0} -> number
var TotalConvos = "Conversatii: {0}";

// LastConvo
// {0} -> Date
var LastConvo = "Ultima Conversatie : {0}";

// Archiving
// {0} -> this will be one of 'Enabled' or 'Disabled' depending on status
var Archiving = "Arhivare:{0}";

// ShowingConvoFor
// {0} -> user-id
// ex. Showing conversations for Jack
var ShowingConvoFor = "Comversatiile lui {0}";

var Error  = "Eroare"; // Generic error string
var Home   = "Acasa"; // Main page title
var More   = "Mai Mult"; // Lets you view the whole conversation
var Hours  = "ore"; // Settings: Lets you set the indexing frequency
var Users  = "Useri"; // Local users on this system
var Search = "Cauta"; // Search button text
var Help   = "Ajutor"; // Navigation: Takes you to the help page

var ViewLog  = "Vezi Jurnalul"; // Navigation: Displays the log file
var Language = "Limba"; // Option in Settings: Lets you select your display language
var PrevPage = "Pagina Anterioara"; // Takes you to the previous page while Searching or while browsing conversations
var NextPage = "Pagina Urmatoare"; 
var Settings = "Setari"; // Navigation: Takes you to the settings page

var UpdateFreq   = "Frecventa Updatarii";
var SaveSettings = "Salveaza setarile";
var ExportConvos = "Exporta Conversatiile";
var NoIndexFound = "Nu s-a gasit index!";
var FileNotFound = "Fila nu a fost gasita";
var NoConvoFound = "Nu s-a gasit nici o conversatie";
var SearchingFor = "Cauta {0}"; // {0} -> search term
var VisitWebsite = "Viziteaza Site-ul";

var NoResultsFound    = "Nu sunt rezultate"; // When searching for something returns no results
var ArchivingEnabled  = "Activata";
var ArchivingEnable   = "Activeaza";   // Different from the above. This denotes the act of enabling
var ArchivingDisabled = "Dezactivata";
var ArchivingDisable  = "Dezactiveaza";  // Different from the above. This denotes the act of disabling
var GeneratedByYammy  = "Generat de Yammy 0.9"; // The footer text
