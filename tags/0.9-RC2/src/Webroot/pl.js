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
 * Language: Polish
 * Translator: Piotr Kwiliński
 * Contact: euvcp at hotmail dot com
 *
 */

var AppName    = "Yammy"; // Do not edit
var AppVersion = "0.9"; // Do not edit

var TrayMenuOpen     = "&Otwórz";
var TrayMenuSettings = "&Ustawienia";
var TrayMenuExit     = "Zak&ończ";

// ConversationBetween
// {0} -> local user-id
// {1} -> remote user-id.
// ex: Conversation between jack and jill
var ConversationBetween = "Rozmowy pomiędzy {0} i {1}"; 

// ConversationStarted
// {0} -> date
// ex: Conversation started on January 26, 2007
var ConversationStarted = "Rozmowa rozpoczęta o {0}";

// NumSearchResults
// {0} -> starting number
// {1} -> total number
// ex. 11 of 2154 search results
var NumSearchResults = "{0} z {1} wyników wyszukiwania";

// SearchingFor
// {0} -> search term
// ex. Searching for apple
// TotalConvos
// {0} -> number
var TotalConvos = "Łącznie rozmów: {0}";

// LastConvo
// {0} -> Date
var LastConvo = "Ostatnia rozmowa: {0}";

// Archiving
// {0} -> this will be one of 'Enabled' or 'Disabled' depending on status
var Archiving = "Archwizowanie: {0}";

// ShowingConvoFor
// {0} -> user-id
// ex. Showing conversations for Jack
var ShowingConvoFor = "Pokazywanie rozmów {0}";

var Error  = "Błąd"; // Generic error string
var Home   = "Strona domowa"; // Main page title
var More   = "Więcej"; // Lets you view the whole conversation
var Hours  = "godz"; // Settings: Lets you set the indexing frequency
var Users  = "Użytkownicy"; // Local users on this system
var Search = "Szukaj"; // Search button text
var Help   = "Pomoc"; // Navigation: Takes you to the help page

var ViewLog  = "Zobacz Log"; // Navigation: Displays the log file
var Language = "Język"; // Option in Settings: Lets you select your display language
var PrevPage = "Poprzednia strona"; // Takes you to the previous page while Searching or while browsing conversations
var NextPage = "Następna strona"; 
var Settings = "Ustawienia"; // Navigation: Takes you to the settings page

var UpdateFreq   = "Częstotliwość uaktualnień";
var SaveSettings = "Zapisz ustawienia";
var ExportConvos = "Eksportuj rozmowy";
var NoIndexFound = "Nie znaleziono indeksu!";
var FileNotFound = "Nie znaleziono pliku";
var NoConvoFound = "Nie znaleziono rozmów";
var SearchingFor = "Szukanie {0}"; // {0} -> search term
var VisitWebsite = "Odwiedź stronę domową";

var NoResultsFound    = "Brak wyników wyszukiwania"; // When searching for something returns no results
var ArchivingEnabled  = "Włączono";
var ArchivingEnable   = "Włącz";   // Different from the above. This denotes the act of enabling
var ArchivingDisabled = "Wyłączono";
var ArchivingDisable  = "Wyłącz";  // Different from the above. This denotes the act of disabling
var GeneratedByYammy  = "Utworzone przez Yammy 0.9"; // The footer text