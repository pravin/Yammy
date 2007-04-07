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
 * Language: Hebrew
 * Translator: Nuvax
 * Contact: 
 *
 */

var AppName    = "Yammy"; // Do not edit
var AppVersion = "0.9"; // Do not edit

var TrayMenuOpen     = "&פתח";
var TrayMenuSettings = "&הגדרות";
var TrayMenuExit     = "&יציאה";

// ConversationBetween
// {0} -> local user-id
// {1} -> remote user-id.
// ex: Conversation between jack and jill
var ConversationBetween = "שיחה בין {0} ל {1}"; 

// ConversationStarted
// {0} -> date
// ex: Conversation started on January 26, 2007
var ConversationStarted = "שיחה החלה ב{0}";

// NumSearchResults
// {0} -> starting number
// {1} -> total number
// ex. 11 of 2154 search results
var NumSearchResults = "{0} מתוך {1} תוצאות חיפוש";

// SearchingFor
// {0} -> search term
// ex. Searching for apple
// TotalConvos
// {0} -> number
var TotalConvos = "סך כל השיחות: {0}";

// LastConvo
// {0} -> Date
var LastConvo = "שיחה אחרונה: {0}";

// Archiving
// {0} -> this will be one of 'Enabled' or 'Disabled' depending on status
var Archiving = "שמירה בארכיב: {0}";

// ShowingConvoFor
// {0} -> user-id
// ex. Showing conversations for Jack
var ShowingConvoFor = "מראה שיחוב עבור  {0}";

var Error  = "תקלה"; // Generic error string
var Home   = "דף בית"; // Main page title
var More   = "עוד"; // Lets you view the whole conversation
var Hours  = "שעות"; // Settings: Lets you set the indexing frequency
var Users  = "משתמשים"; // Local users on this system
var Search = "חפש"; // Search button text
var Help   = "עזרה"; // Navigation: Takes you to the help page

var ViewLog  = "הצג לוג"; // Navigation: Displays the log file
var Language = "שפה"; // Option in Settings: Lets you select your display language
var PrevPage = "עמוד קודם"; // Takes you to the previous page while Searching or while browsing conversations
var NextPage = "עמוד הבא"; 
var Settings = "הגדרות"; // Navigation: Takes you to the settings page

var UpdateFreq   = "קצב עידכון";
var SaveSettings = "שמור הגדרות";
var ExportConvos = "יצא שיחות";
var NoIndexFound = "אינדקס לא נמצא!";
var FileNotFound = "קובץ לא נמצא!";
var NoConvoFound = "לא נמצאו שיחות";
var SearchingFor = "מחפש {0}"; // {0} -> search term
var VisitWebsite = "בקר באתר";

var NoResultsFound    = "לא נמצאו תוצאות"; // When searching for something returns no results
var ArchivingEnabled  = "מופעל";
var ArchivingEnable   = "הפעל";   // Different from the above. This denotes the act of enabling
var ArchivingDisabled = "כבוי";
var ArchivingDisable  = "כבה";  // Different from the above. This denotes the act of disabling
var GeneratedByYammy  = "יוצר על ידי Yammy 0.9"; // The footer text
