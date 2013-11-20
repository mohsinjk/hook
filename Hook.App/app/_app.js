$(document).ready( function(){
var container=$('#container');
var btnBack=$('#back');
var btnFeed=$('#feed');
var btnPeople=$('#people');
var btnMe = $('#me');
var btnWrite = $('#write');
var btnLoding=$('#loading');
var navName=$('#navName');
var logo = $('#logo');

var navButton = $('.myNav .navButton');

var html = container.html();

var loginPage = $.get('login.html');
	//container.html('');

btnWrite.on('click', function () {
	navName.html('Login');
	$.get('login.html', function (data) {
		showContents(data);
	});
	navButtonActiv(this);
});

var navButtonActiv= function (data) {
	navButton.removeClass('navButtonActiv');
	$(data).find(".navButton").addClass('navButtonActiv');
};

btnBack.on('click', function () {
	window.history.back();
	navName.html(currentNav(document.location.hash));
});


btnFeed.on('click', function(){
	navName.html('Feed');
	showContents(html);
	navButtonActiv(this);
});

btnPeople.on('click', function(){
	navName.html('People');
	showContents('People');
	navButtonActiv(this);
});

btnMe.on('click', function(){
	navName.html('Me');
	showContents('Me');
	navButtonActiv(this);
});

var currentNav= function( hash ){
	//var i= data.substring(data.indexOf("#"), data.length);
	switch(hash)
	{
		case "#/feed":
			btnFeed.trigger("click");
			break;
		case "#/people":
			btnPeople.trigger("click");
			break;
		case "#/me":
			btnMe.trigger("click");
			break;
	}
};
var showContents=function( data ){
	logo.attr("src", "ajax-loader.gif");
	container.html(data);
	logo.attr("src","comaroundLogo.jpg");
};

});