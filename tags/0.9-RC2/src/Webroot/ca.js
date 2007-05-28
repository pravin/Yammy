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
 * Language: Catalan
 * Translator: Iñigo Goiri Presa
 * Contact: inigoiri@telefonica.net
 *
 */

var AppName    = "Yammy"; // Do not edit
var AppVersion = "0.9"; // Do not edit

var TrayMenuOpen     = "&Obrir";
var TrayMenuSettings = "&Preferències";
var TrayMenuExit     = "&Sortir";

// ConversationBetween
// {0} -> local user-id
// {1} -> remote user-id.
// ex: Conversation between jack and jill
var ConversationBetween = "Conversació entre {0} i {1}"; 

// ConversationStarted
// {0} -> date
// ex: Conversation started on January 26, 2007
var ConversationStarted = "Conversació començada el {0}";

// NumSearchResults
// {0} -> starting number
// {1} -> total number
// ex. 11 of 2154 search results
var NumSearchResults = "{0} de {1} resultats de la cerca";

// SearchingFor
// {0} -> search term
// ex. Searching for apple
// TotalConvos
// {0} -> number
var TotalConvos = "Conversacions totals: {0}";

// LastConvo
// {0} -> Date
var LastConvo = "Última conversa: {0}";

// Archiving
// {0} -> this will be one of 'Enabled' or 'Disabled' depending on status
var Archiving = "Emmagatzemament: {0}";

// ShowingConvoFor
// {0} -> user-id
// ex. Showing conversations for Jack
var ShowingConvoFor = "Mostrant les converses amb {0}";

var Error  = "Error"; // Generic error string
var Home   = "Principal"; // Main page title
var More   = "Més"; // Lets you view the whole conversation
var Hours  = "hores"; // Settings: Lets you set the indexing frequency
var Users  = "Usuaris"; // Local users on this system
var Search = "Cercar"; // Search button text
var Help   = "Ajuda"; // Navigation: Takes you to the help page

var ViewLog  = "Veure Log"; // Navigation: Displays the log file
var Language = "Idioma"; // Option in Settings: Lets you select your display language
var PrevPage = "Pàgina anterior"; // Takes you to the previous page while Searching or while browsing conversations
var NextPage = "Pàgina següent"; 
var Settings = "Preferències"; // Navigation: Takes you to the settings page

var UpdateFreq   = "Freqüència d'actualització";
var SaveSettings = "Desar preferències";
var ExportConvos = "Exportar converses";
var NoIndexFound = "No s'ha trobat cap índex!";
var FileNotFound = "No s'ha trobat cap fitxer";
var NoConvoFound = "No s'han trobat converses";
var SearchingFor = "Cercant {0}"; // {0} -> search term
var VisitWebsite = "Visitar lloc web";

var NoResultsFound    = "No s'han trobat resultats"; // When searching for something returns no results
var ArchivingEnabled  = "Habilitat";
var ArchivingEnable   = "Habilitar";   // Different from the above. This denotes the act of enabling
var ArchivingDisabled = "Deshabilitat";
var ArchivingDisable  = "Deshabilitar";  // Different from the above. This denotes the act of disabling
var GeneratedByYammy  = "Generat amb Yammy 0.9"; // The footer text
