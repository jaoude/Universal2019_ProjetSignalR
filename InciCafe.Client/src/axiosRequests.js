import Axios from "axios";
import App from "./Components/App"
import { JsonHubProtocol } from "@aspnet/signalr";

class axiosRequests
{
   
    
    get()
    {
       

        Axios.get('http://localhost:5002/api/orders').then((response)=>
        {
           
         //  console.log( JSON.stringify(response.data))
				  
           localStorage.setItem(1, JSON.stringify(response.data));
            
        })
    }

    getCoffeeById(id)
    {
        
        Axios.get('http://localhost:5002/api/coffees/'+id).then((response)=>
        {
          localStorage[2] =response.data;
            
        })
    }
    getStatusById(id)
    {
        
        Axios.get('http://localhost:5002/api/status/'+id).then((response)=>
        {
           localStorage[3] = response.data;
        })

    }
     postOrder()
    {
        var app = new App();
        var body =app.CreatePostBody();
        app.showOrders(app.UserId);
        const response =  Axios.post(
            'http://localhost:5002/api/orders/',
            {   "ClientId" : body.ClientId,
                "StatusId" : 2,
                "Size" : body.Size,
                "CoffeeId" : body.CoffeeId },
            { headers: { 'Content-Type': 'application/json' },
            
            
         }
        )
    }
   
}
export default axiosRequests;