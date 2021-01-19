$( document ).ready(function() {
	
	$("#btnNavResize" ).click(function() {
		$('.myNav').toggleClass('navNarrow');
		$('.main').toggleClass('navNarrow');
		$('header').toggleClass('navNarrow');
		$('footer').toggleClass('navNarrow');
		$('#btnNavResize').toggleClass('navNarrow');
		if($('.myNav').width()>60)
			$('.hidable').toggleClass('d-none');
		else
			setTimeout(function(){ $('.hidable').toggleClass('d-none') }, 300);
		
		
	});

	var viewModel={
		mainNavigation:{
			curNode:null,
			nodes:ko.observableArray([]),
		},
		mainContent:{
			curNode:null,
			nodes:ko.observableArray([]),
		}
	  };
	  //ko.applyBindings(viewModel);
	  // https://stackoverflow.com/questions/9293761/knockoutjs-multiple-viewmodels-in-a-single-view
	  // ko.applyBindings(myViewModel, document.getElementById('someElementId'))
	  ko.applyBindings(viewModel, $("body")[0]);

	  $.getJSON('/data/links.json', function (data) {		
		viewModel.mainNavigation.nodes.removeAll();
		for(var i=0;i<data.items.length;i++){
			viewModel.mainNavigation.nodes.push( data.items[i]);
		};
	});

	
	$.getJSON('/data/main.json', function (data) {
		//console.log(data);
		viewModel.mainContent.nodes.removeAll();
		for(var i=0;i<data.items.length;i++){
			viewModel.mainContent.nodes.push( data.items[i]);
		};
		

	});
});

