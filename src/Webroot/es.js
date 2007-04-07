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
 * Language: Spanish
 * Translator: Iñigo Goiri Presa & Aitor Gomez Goiri
 * Contact: inigoiri@telefonica.net & aitor@twolf.eu
 *
 */

var AppName    = "Yammy"; // Do not edit
var AppVersion = "0.9"; // Do not edit

var TrayMenuOpen     = "&Abrir";
var TrayMenuSettings = "&Preferencias";
var TrayMenuExit     = "&Salir";

// ConversationBetween
// {0} -> local user-id
// {1} -> remote user-id.
// ex: Conversation between jack and jill
var ConversationBetween = "Conversación entre {0} y {1}"; 

// ConversationStarted
// {0} -> date
// ex: Conversation started on January 26, 2007
var ConversationStarted = "Conversación comenzada en {0}";

// NumSearchResults
// {0} -> starting number
// {1} -> total number
// ex. 11 of 2154 search results
var NumSearchResults = "{0} de {1} resultados de busqueda";

// SearchingFor
// {0} -> search term
// ex. Searching for apple
// TotalConvos
// {0} -> number
var TotalConvos = "Conversaciones totales: {0}";

// LastConvo
// {0} -> Date
var LastConvo = "Última conversación: {0}";

// Archiving
// {0} -> this will be one of 'Enabled' or 'Disabled' depending on status
var Archiving = "Almacenamiento: {0}";

// ShowingConvoFor
// {0} -> user-id
// ex. Showing conversations for Jack
var ShowingConvoFor = "Mostrando las conversaciones con {0}";

var Error  = "Error"; // Generic error string
var Home   = "Principal"; // Main page title
var More   = "Más"; // Lets you view the whole conversation
var Hours  = "horas"; // Settings: Lets you set the indexing frequency
var Users  = "Usuarios"; // Local users on this system
var Search = "Buscar"; // Search button text
var Help   = "Ayuda"; // Navigation: Takes you to the help page

var ViewLog  = "Ver Log"; // Navigation: Displays the log file
var Language = "Idioma"; // Option in Settings: Lets you select your display language
var PrevPage = "Página anterior"; // Takes you to the previous page while Searching or while browsing conversations
var NextPage = "Siguiente página"; 
var Settings = "Preferencias"; // Navigation: Takes you to the settings page

var UpdateFreq   = "Frecuencia de actualización";
var SaveSettings = "Guardar preferencias";
var ExportConvos = "Exportar conversaciones";
var NoIndexFound = "No se ha encontrado ningún índice!";
var FileNotFound = "No se ha encontrado ningún fichero";
var NoConvoFound = "No se han encontrado conversaciones";
var SearchingFor = "Buscando por {0}"; // {0} -> search term
var VisitWebsite = "Visitar sitio web";

var NoResultsFound    = "No se han encontrado resultados"; // When searching for something returns no results
var ArchivingEnabled  = "Habilitado";
var ArchivingEnable   = "Habilitar";   // Different from the above. This denotes the act of enabling
var ArchivingDisabled = "Deshabilitado";
var ArchivingDisable  = "Deshabilitar";  // Different from the above. This denotes the act of disabling
var GeneratedByYammy  = "Generado con Yammy 0.9"; // The footer text
