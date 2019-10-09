class HttpClient {
	post(body, url) {
		var xhr = new XMLHttpRequest();
		xhr.open('POST', url); // url est le lien pour le api
		xhr.send(JSON.stringify(body)); // Les donnees que l'on va envoyer
		xhr.addEventListener('load', () => {
			console.log(xhr.responseText); // reponse de la requete 
		})
	}

	get(url) {
		// create a new XMLHttpRequest
		var xhr = new XMLHttpRequest()
		// get a callback when the server responds
		xhr.addEventListener('load', () => {
			// update the state of the component with the result here
			console.log(xhr.responseText)
		})
		// open the request with the verb and the url, should enter the url given in the parameters
		xhr.open('GET', url)
		// send the request
		xhr.send()
	}
}
export default HttpClient;