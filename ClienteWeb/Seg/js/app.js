$(document).ready(function()
{
	/*$datos = {"nombre"};
	$("#Canciones").on('click', function(){
		$.getJSON("http://localhost/AOS/servicioWeb/",$datos).done(function(datos_del_ws){
			$.each(datos_del_ws, function(indice, valor){
				$("#reultCanciones ul").append("<li>" + valor.nombre + "</li>");
			})
		});
	});

	

	$("#Canciones").click(function llamarServicio() {
		var SendObj = {
            action: 'canciones'
        };

	    var stringData = JSON.stringify(SendObj);

        $.ajax({
            type: "POST",
            url: "http://localhost/AOS/servicioWeb/index.php",
            data: stringData,
            contentType: "application/json; utf-8",
            dataType: "json",
            success: function (data) {
            	var stringData2 = JSON.stringify(data);
            	var algo = JSON.parse(stringData2);

                /*if (data.nombre != null) {
                    alert(data.nombre);
                }
                alert(algo[0]);
            },
            error: function (jqXHR, textStatus, errorThrown) {                
            }

        });        
    });*/

});