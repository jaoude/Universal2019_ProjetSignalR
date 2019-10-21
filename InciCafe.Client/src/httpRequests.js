class HttpClient {
	
	post(body) {
		var xhr = new XMLHttpRequest();
		xhr.open('POST', "http://localhost:5002/orders"); // url est le lien pour le api
		xhr.send(body); // Les donnees que l'on va envoyer
		xhr.addEventListener('load', () => {
			console.log(xhr.responseText);// reponse de la requete 
		})
		if (xhr.status === 200)
		{
			console.log('posted');
		}
	}

	get() {
		// create a new XMLHttpRequest
		var xhr = new XMLHttpRequest();
		// get a callback when the server responds
		xhr.addEventListener('load', () => {
			// update the state of the component with the result here
			//console.log(xhr.responseText)
			if (xhr.readyState === 4) {
				localStorage.clear();
				if (xhr.status === 200) {
				  var json_obj = JSON.parse(xhr.responseText);
				  
				 localStorage.setItem(1,JSON.stringify(json_obj));
				  
				 
				} else {
				 return xhr.statusText;
				}
			  }
			
		})
		// open the request with the verb and the url, should enter the url given in the parameters
		xhr.open('GET', "http://localhost:5002/api/orders")
		xhr.send();
		xhr.onload = function(e)
		{
			
			//	.bind(this);
			  //xhr.onerror = function (e) {
				//console.error(xhr.statusText);
			  
		}
		// send the request
		

	}
	getStatusById(id) {
		// create a new XMLHttpRequest
		var xhr = new XMLHttpRequest();
		// get a callback when the server responds
		xhr.addEventListener('load', () => {
			// update the state of the component with the result here
			//console.log(xhr.responseText)
			if (xhr.readyState === 4) {
				if (xhr.status === 200) {
				 // var json_obj = JSON.parse(xhr.responseText);
				  
				 return xhr.responseText
				} else {
				  console.error(xhr.statusText);
				}
			  }
			
		})
		// open the request with the verb and the url, should enter the url given in the parameters
		xhr.open('GET', "http://localhost:5002/api/status/"+id)
		xhr.send();
		xhr.onload = function(e)
		{
			
			//	.bind(this);
			  //xhr.onerror = function (e) {
				//console.error(xhr.statusText);
			  
		}
		// send the request
		

	}
	getCoffeeById(id) {
		// create a new XMLHttpRequest
		var xhr = new XMLHttpRequest();
		// get a callback when the server responds
		xhr.addEventListener('load', () => {
			// update the state of the component with the result here
			//console.log(xhr.responseText)
			if (xhr.readyState === 4) {
				if (xhr.status === 200) {
				  return xhr.statusText;
				} else {
				  console.error(xhr.statusText);
				}
			  }
			
		})
		// open the request with the verb and the url, should enter the url given in the parameters
		xhr.open('GET', "http://localhost:5002/api/coffees/"+id)
		xhr.send();
		xhr.onload = function(e)
		{
			
			//	.bind(this);
			  //xhr.onerror = function (e) {
				//console.error(xhr.statusText);
			  
		}
		// send the request
		

	}
	getCoffeeByName(name) {
		// create a new XMLHttpRequest
		var xhr = new XMLHttpRequest();
		// get a callback when the server responds
		xhr.addEventListener('load', () => {
			// update the state of the component with the result here
			//console.log(xhr.responseText)
			if (xhr.readyState === 4) {
				if (xhr.status === 200) {
				  var json_obj = JSON.parse(xhr.responseText);
				  
				  console.log(json_obj);
				} else {
				  console.error(xhr.statusText);
				}
			  }
			
		})
		// open the request with the verb and the url, should enter the url given in the parameters
		xhr.open('GET', "http://localhost:5002/api/coffees/"+name)
		xhr.send();
		xhr.onload = function(e)
		{
			
			//	.bind(this);
			  //xhr.onerror = function (e) {
				//console.error(xhr.statusText);
			  
		}
		// send the request
		

	}
}
export default HttpClient;