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
 * Language: Portuguese
 * Translator: Vinicius Pinto
 * Contact: http://vinicius.biz/
 *
 */

var AppName    = "Yammy"; // Do not edit
var AppVersion = "0.9"; // Do not edit

var TrayMenuOpen     = "&Abrir";
var TrayMenuSettings = "&Configurações";
var TrayMenuExit     = "&Sair";

// ConversationBetween
// {0} -> local user-id
// {1} -> remote user-id.
// ex: Conversation between jack and jill
var ConversationBetween = "Conversa entre {0} e {1}"; 

// ConversationStarted
// {0} -> date
// ex: Conversation started on January 26, 2007
var ConversationStarted = "Conversa iniciada em {0}";

// NumSearchResults
// {0} -> starting number
// {1} -> total number
// ex. 11 of 2154 search results
var NumSearchResults = "{0} de {1} resultados de busca";

// SearchingFor
// {0} -> search term
// ex. Searching for apple
// TotalConvos
// {0} -> number
var TotalConvos = "Total de conversas: {0}";

// LastConvo
// {0} -> Date
var LastConvo = "Última conversa: {0}";

// Archiving
// {0} -> this will be one of 'Enabled' or 'Disabled' depending on status
var Archiving = "Arquivamento: {0}";

// ShowingConvoFor
// {0} -> user-id
// ex. Showing conversations for Jack
var ShowingConvoFor = "Exibindo conversas para {0}";

var Error  = "Erro"; // Generic error string
var Home   = "Principal"; // Main page title
var More   = "Mais"; // Lets you view the whole conversation
var Hours  = "h"; // Settings: Lets you set the indexing frequency
var Users  = "Usuários"; // Local users on this system
var Search = "Buscar"; // Search button text
var Help   = "Ajuda"; // Navigation: Takes you to the help page

var ViewLog  = "Exibir Log"; // Navigation: Displays the log file
var Language = "Idioma"; // Option in Settings: Lets you select your display language
var PrevPage = "Página Anterior"; // Takes you to the previous page while Searching or while browsing conversations
var NextPage = "Próxima Página"; 
var Settings = "Configurações"; // Navigation: Takes you to the settings page

var UpdateFreq   = "Freqüência de Atualização";
var SaveSettings = "Salvar Configurações";
var ExportConvos = "Exportar Conversas";
var NoIndexFound = "Índice não encontrado!";
var FileNotFound = "Arquivo não encontrado";
var NoConvoFound = "Nenhuma conversa encontrada";
var SearchingFor = "Buscando por {0}"; // {0} -> search term
var VisitWebsite = "Visitar Website";

var NoResultsFound    = "Nenhum resultado encontrado"; // When searching for something returns no results
var ArchivingEnabled  = "Habilitado";
var ArchivingEnable   = "Habilitar";   // Different from the above. This denotes the act of enabling
var ArchivingDisabled = "Desabilitado";
var ArchivingDisable  = "Desabilitar";  // Different from the above. This denotes the act of disabling
var GeneratedByYammy  = "Gerado por Yammy 0.9"; // The footer text
