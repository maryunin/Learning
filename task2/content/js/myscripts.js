$(function() {
	var lang = $.cookie('Lang');
	$("#selectedImage").attr("src", "content/images/"+lang+"Flag.png");
});
//});

function SetLang(lang){
	$.cookie('Lang', lang, {expires: 5, path: '/'});
	$("#selectedImage").attr("src", "/content/images/"+lang+"Flag.png");
};