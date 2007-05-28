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
 * Language:Traditional Chinese (Taiwan)
 * Translator: hit1205
 * Contact: hit1205@users.sourceforge.net
 *
 */

var AppName    = "Yammy"; // Do not edit
var AppVersion = "0.9"; // Do not edit

var TrayMenuOpen     = "開啟(&O)";
var TrayMenuSettings = "設定(&S)";
var TrayMenuExit     = "離開(&E)";

// ConversationBetween
// {0} -> local user-id
// {1} -> remote user-id.
// ex: Conversation between jack and jill
var ConversationBetween = "{0} 與 {1} 的對話"; 

// ConversationStarted
// {0} -> date
// ex: Conversation started on January 26, 2007
var ConversationStarted = "對話從 {0} 開始";

// NumSearchResults
// {0} -> starting number
// {1} -> total number
// ex. 11 of 2154 search results
var NumSearchResults = "{1} 個搜尋結果中的第 {0} 個";

// SearchingFor
// {0} -> search term
// ex. Searching for apple
// TotalConvos
// {0} -> number
var TotalConvos = "所有的對話: {0}";

// LastConvo
// {0} -> Date
var LastConvo = "最新的對話: {0}";

// Archiving
// {0} -> this will be one of 'Enabled' or 'Disabled' depending on status
var Archiving = "彙整: {0}";

// ShowingConvoFor
// {0} -> user-id
// ex. Showing conversations for Jack
var ShowingConvoFor = "顯示與 {0} 的對話";

var Error  = "錯誤"; // Generic error string
var Home   = "首頁"; // Main page title
var More   = "繼續閱讀"; // Lets you view the whole conversation
var Hours  = "小時"; // Settings: Lets you set the indexing frequency
var Users  = "使用者"; // Local users on this system
var Search = "搜尋"; // Search button text
var Help   = "說明"; // Navigation: Takes you to the help page

var ViewLog  = "檢視紀錄"; // Navigation: Displays the log file
var Language = "語言"; // Option in Settings: Lets you select your display language
var PrevPage = "上一頁"; // Takes you to the previous page while Searching or while browsing conversations
var NextPage = "下一頁"; 
var Settings = "設定"; // Navigation: Takes you to the settings page

var UpdateFreq   = "更新頻率";
var SaveSettings = "儲存設定";
var ExportConvos = "匯出對話";
var NoIndexFound = "找不到索引！";
var FileNotFound = "找不到檔案！";
var NoConvoFound = "找不到對話";
var SearchingFor = "尋找 {0}"; // {0} -> search term
var VisitWebsite = "造訪網站";

var NoResultsFound    = "沒有搜尋結果"; // When searching for something returns no results
var ArchivingEnabled  = "已啟用";
var ArchivingEnable   = "啟用";   // Different from the above. This denotes the act of enabling
var ArchivingDisabled = "已停用";
var ArchivingDisable  = "停用";  // Different from the above. This denotes the act of disabling
var GeneratedByYammy  = "由 Yammy 0.9 產生"; // The footer text
