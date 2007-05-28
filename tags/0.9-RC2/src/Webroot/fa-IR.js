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
 * Language: Persian
 * Translator: Amin N.Karimi
 * Contact: amin.karimi@gmail.com
 *
 */

var AppName    = "Yammy"; // Do not edit
var AppVersion = "0.9"; // Do not edit

var TrayMenuOpen     = "&بازکردن";
var TrayMenuSettings = "&تنظیمات";
var TrayMenuExit     = "&خروج";

// ConversationBetween
// {0} -> local user-id
// {1} -> remote user-id.
// ex: Conversation between jack and jill
var ConversationBetween = "گفتگو بین {0}و{1} "; 

// ConversationStarted
// {0} -> date
// ex: Conversation started on January 26, 2007
var ConversationStarted = "گفتگو در {0}";

// NumSearchResults
// {0} -> starting number
// {1} -> total number
// ex. 11 of 2154 search results
var NumSearchResults = "{1}از  {0} نتایج جستجو";

// SearchingFor
// {0} -> search term
// ex. Searching for apple
// TotalConvos
// {0} -> number
var TotalConvos = "تعداد گفتگوها: {0}";

// LastConvo
// {0} -> Date
var LastConvo = "آخرین گفتگو: {0}";

// Archiving
// {0} -> this will be one of 'Enabled' or 'Disabled' depending on status
var Archiving = "در حال آرشیو: {0}";

// ShowingConvoFor
// {0} -> user-id
// ex. Showing conversations for Jack
var ShowingConvoFor = "مشاهده گفتگوهای {0}";

var Error  = "خطا"; // Generic error string
var Home   = "خانه"; // Main page title
var More   = "بیشتر"; // Lets you view the whole conversation
var Hours  = "ساعت"; // Settings: Lets you set the indexing frequency
var Users  = "کاربران"; // Local users on this system
var Search = "جستجو"; // Search button text
var Help   = "کمک"; // Navigation: Takes you to the help page

var ViewLog  = "رویدادها"; // Navigation: Displays the log file
var Language = "زبان"; // Option in Settings: Lets you select your display language
var PrevPage = "صفحه قبل"; // Takes you to the previous page while Searching or while browsing conversations
var NextPage = "صفحه بعد"; 
var Settings = "تنظیمات"; // Navigation: Takes you to the settings page

var UpdateFreq   = "مراتب بروزرسانی";
var SaveSettings = "ذخیره تنظیمات";
var ExportConvos = "صدور مکالمات";
var NoIndexFound = "ایندکسی یافت نشد";
var FileNotFound = "فایل پیدا نشد";
var NoConvoFound = "هیچ گفتگویی یافت نشد";
var SearchingFor = "جستجوی {0}"; // {0} -> search term
var VisitWebsite = "مشاهده وب سایت";

var NoResultsFound    = "نتیجه ای یافت نشد"; // When searching for something returns no results
var ArchivingEnabled  = "فعال";
var ArchivingEnable   = "فعال کردن";   // Different from the above. This denotes the act of enabling
var ArchivingDisabled = "غیرفعال";
var ArchivingDisable  = "غیرفعال کردن";  // Different from the above. This denotes the act of disabling
var GeneratedByYammy  = "تولید شده توسط Yammy 0.9"; // The footer text
