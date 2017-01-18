function ls(driver, d) {
	
	var url = driver + '?d=' + d;
	
	$.get( url, function( list ) {

		console.log(list);
	
		var dirs = "";
		list.DIRs.forEach(function(dir) {
			dirs += "<li><a href='/index.html?d=" + d + "/" + dir + "'>&lt;" + dir + "></a></li>";
		})
				
		var files = "";
		list.Files.forEach(function(file) {
			files += "<li><a href='/player.html?file=" + d + file.FileName + "'>" + file.FileName + "</a></li>";
		})
		
		var data = "";
		
		data += dirs;
		data += files;
		
		$( "#DIR" ).html( data );

	});
}