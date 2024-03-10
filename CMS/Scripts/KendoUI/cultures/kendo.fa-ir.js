/*
* Kendo UI Localization Project for v2012.3.1114 
* Copyright 2012 Telerik AD. All rights reserved.
* 
* Standard persian (fa-IR) Language Pack
*
* Project home  : https://github.com/loudenvier/kendo-global
* Kendo UI home : http://kendoui.com
* Author        : Mohsen soodbakhsh, Farshad Nasehi
*                 
*
* This project is released to the public domain, although one must abide to the 
* licensing terms set forth by Telerik to use Kendo UI, as shown bellow.
*
* Telerik's original licensing terms:
* -----------------------------------
* Kendo UI Web commercial licenses may be obtained at
* https://www.kendoui.com/purchase/license-agreement/kendo-ui-web-commercial.aspx
* If you do not own a commercial license, this file shall be governed by the
* GNU General Public License (GPL) version 3.
* For GPL requirements, please review: http://www.gnu.org/copyleft/gpl.html
*/

kendo.ui.Locale = "Persian (fa-IR)";
kendo.ui.ColumnMenu.prototype.options.messages =
  $.extend(kendo.ui.ColumnMenu.prototype.options.messages, {

	/* COLUMN MENU MESSAGES 
	****************************************************************************/
	sortAscending: "صعودی",
	sortDescending: "نزولی",
	filter: "جتسجو",
	columns: "ستون"
	/***************************************************************************/
  });



kendo.ui.Groupable.prototype.options.messages =
  $.extend(kendo.ui.Groupable.prototype.options.messages, {

	/* GRID GROUP PANEL MESSAGES 
	****************************************************************************/
	empty: "رکوردی یافت نشد."
	/***************************************************************************/
  });

kendo.ui.FilterMenu.prototype.options.messages =
  $.extend(kendo.ui.FilterMenu.prototype.options.messages, {

	/* FILTER MENU MESSAGES 
	***************************************************************************/
	info: "جستجو",        // sets the text on top of the filter menu
	filter: "جستجو",      // sets the text for the "Filter" button
	clear: "پاک کردن",        // sets the text for the "Clear" button
	// when filtering boolean numbers
	isTrue: "درست", // sets the text for "isTrue" radio button
	isFalse: "نادرست",     // sets the text for "isFalse" radio button
	//changes the text of the "And" and "Or" of the filter menu
	and: "و",
	or: "یا",
	selectValue: "مقدار انتخابی"
	/***************************************************************************/
  });

kendo.ui.FilterMenu.prototype.options.operators =
  $.extend(kendo.ui.FilterMenu.prototype.options.operators, {

	/* FILTER MENU OPERATORS (for each supported data type) 
	****************************************************************************/
	string: {
		eq: "برابر با",
		neq: "نا برابر با",
		startswith: "شروع با",
		contains: "شامل",
		doesnotcontain: "به جز",
		endswith: "پایان با"
	},
	number: {
		eq: "مساوی با",
		neq: "نا مساوی با",
		gte: "بزرگتر مساوی از",
		gt: "بزرگتر از",
		lte: "کوچتر مساوی از",
		lt: "کوچکتر از"
	},
	date: {
		eq: "برابر با",
		neq: "نا برابر با",
		gte: "بزرگتر مساوی از",
		gt: "بزرگتر از",
		lte: "کوچتر مساوی از",
		lt: "کوچکتر از"
	},
	enums: {
		eq: "برابر با",
		neq: "نا برابر با",
	}
	/***************************************************************************/
  });

kendo.ui.Pager.prototype.options.messages =
  $.extend(kendo.ui.Pager.prototype.options.messages, {

	/* PAGER MESSAGES 
	****************************************************************************/
	display: "{0} - {1} از {2} رکورد",
	empty: "صفحه ای یافت نشد",
	page: "صفحه",
	of: "از {0}",
	itemsPerPage: "مورد در صفحه",
	first: "اولین صفحه",
	previous: "صفحه قبلی",
	next: "صفحه بعدی",
	last: "آخرین صفحه",
	refresh: "بارگزاری مجدد"
	/***************************************************************************/
  });

kendo.ui.Validator.prototype.options.messages =
  $.extend(kendo.ui.Validator.prototype.options.messages, {

	/* VALIDATOR MESSAGES 
	****************************************************************************/
	required: "{0} الزامی",
	pattern: "{0} الگو",
	min: "{0} باید بزرگتر یا مساوی با {1}",
	max: "{0} باید کمتر یا برابر باشد با {1}",
	step: "{0} نامعتبر است",
	email: "{0} آدرس ایمیل معتبر نیست",
	url: "{0} آدرس اینترنتی معتبر نیست",
	date: "{0} تاریخ معتبر نیست"
	/***************************************************************************/
  });

kendo.ui.ImageBrowser.prototype.options.messages =
  $.extend(kendo.ui.ImageBrowser.prototype.options.messages, {

	/* IMAGE BROWSER MESSAGES 
	****************************************************************************/
	uploadFile: "بارگذاری فایل",
	orderBy: "مرتب سازی بر اساس",
	orderByName: "نام",
	orderBySize: "اندازه",
	directoryNotFound: "کتابخانه یافت نشد.",
	emptyFolder: "پوشه خالی",
	deleteFile: "آیا شما مطمئن هستید که میخواهید فایل را حذف کنید: \"{0}\"?",
	invalidFileType: "فرمت فایل های انتخاب شده: \"{0}\" نامعتبر است. فرمت های فایل پشتیبانی {1}.",
	overwriteFile: "یک فایل با همان نام \"{0}\" در حال حاضر وجود دارد، آیا بازنویسی شود?",
	dropFilesHere: "فایل را به اینجا بکشید"
	/***************************************************************************/
  });

kendo.ui.Editor.prototype.options.messages =
  $.extend(kendo.ui.Editor.prototype.options.messages, {

	/* EDITOR MESSAGES 
	****************************************************************************/
	bold: "Fet",
	italic: "Kursiv",
	underline: "Understreket",
	strikethrough: "Gjennomstreket",
	superscript: "Fremhevet",
	subscript: "Senket",
	justifyCenter: "Sentrert",
	justifyLeft: "Venstrejuster",
	justifyRight: "Høyrejuster",
	justifyFull: "like marger",
	insertUnorderedList: "Sett inn uordnet liste",
	insertOrderedList: "Sett inn ordnet liste",
	indent: "Øk innrykk",
	outdent: "Reduser innrykk",
	createLink: "Opprett link",
	unlink: "Fjern link",
	insertImage: "Sett inn bilde",
	insertHtml: "Sett inn HTML",
	fontName: "Skrifttype",
	fontNameInherit: "(Arv skrifttype)",
	fontSize: "Skriftstørrelse",
	fontSizeInherit: "(Arv skriftstørrelse)",
	formatBlock: "Format",
	foreColor: "Farge",
	backColor: "Bakgrunns farge",
	style: "Stil",
	emptyFolder: "Tom mappe",
	uploadFile: "Sender",
	orderBy: "Sorter etter:",
	orderBySize: "Størrelse",
	orderByName: "Navn",
	invalidFileType: "Det valgte filformatet: \"{0}\" er ugyldig. Støttede filformater er {1}.",
	deleteFile: "Er du sikker på du vil slette filen: \"{0}\"?",
	overwriteFile: "En fil med samme navn \"{0}\" eksisterer fra før, vil du overskrive?",
	directoryNotFound: "Biblioteket ble ikke funnet.",
	imageWebAddress: "Internett adresse",
	imageAltText: "Alternativ Tekst",
	dialogInsert: "Sett inn",
	dialogButtonSeparator: "eller",
	dialogCancel: "Annuller"
	/***************************************************************************/
  });