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
 * Language: French
 * Translator: Groscask
 * Contact: groscask at gmail dot com
 *
 */

var AppName    = "Yammy"; // Do not edit
var AppVersion = "0.9"; // Do not edit

var TrayMenuOpen     = "&Ouvrir";
var TrayMenuSettings = "&Options";
var TrayMenuExit     = "&Quitter";

// ConversationBetween
// {0} -> local user-id
// {1} -> remote user-id.
// ex: Conversation between jack and jill
var ConversationBetween = "Conversation entre {0} et {1}"; 

// ConversationStarted
// {0} -> date
// ex: Conversation started on January 26, 2007
var ConversationStarted = "Conversation débutée le {0}";

// NumSearchResults
// {0} -> starting number
// {1} -> total number
// ex. 11 of 2154 search results
var NumSearchResults = "{0} sur {1} résultats de recherche";

// SearchingFor
// {0} -> search term
// ex. Searching for apple
// TotalConvos
// {0} -> number
var TotalConvos = "Conversations totales: {0}";

// LastConvo
// {0} -> Date
var LastConvo = "Dernière conversation: {0}";

// Archiving
// {0} -> this will be one of 'Enabled' or 'Disabled' depending on status
var Archiving = "Archivage: {0}";

// ShowingConvoFor
// {0} -> user-id
// ex. Showing conversations for Jack
var ShowingConvoFor = "Affichage des conversations de {0}";

var Error  = "Erreur"; // Generic error string
var Home   = "Page principale"; // Main page title
var More   = "Plus"; // Lets you view the whole conversation
var Hours  = "h"; // Settings: Lets you set the indexing frequency
var Users  = "Utilisateurs"; // Local users on this system
var Search = "Rechercher"; // Search button text
var Help   = "Aide"; // Navigation: Takes you to the help page

var ViewLog  = "Log"; // Navigation: Displays the log file
var Language = "Langue"; // Option in Settings: Lets you select your display language
var PrevPage = "Page précédente"; // Takes you to the previous page while Searching or while browsing conversations
var NextPage = "Page suivante"; 
var Settings = "Options"; // Navigation: Takes you to the settings page

var UpdateFreq   = "Fréquence de mise à jour";
var SaveSettings = "Enregistrer les options";
var ExportConvos = "Exporter les Conversations";
var NoIndexFound = "Aucun index trouvé !";
var FileNotFound = "Aucun fichier trouvé";
var NoConvoFound = "Aucune conversation trouvée";
var SearchingFor = "Recherche de {0}"; // {0} -> search term
var VisitWebsite = "Visiter le site web";

var NoResultsFound    = "Aucun résultat de recherche"; // When searching for something returns no results
var ArchivingEnabled  = "Activé";
var ArchivingEnable   = "Activation";   // Different from the above. This denotes the act of enabling
var ArchivingDisabled = "Désactivé";
var ArchivingDisable  = "Désactivation";  // Different from the above. This denotes the act of disabling
var GeneratedByYammy  = "Créé par Yammy 0.9"; // The footer text
