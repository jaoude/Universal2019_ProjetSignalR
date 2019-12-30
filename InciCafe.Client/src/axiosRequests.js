import Axios from "axios";
import App from "./Components/App"


class axiosRequests
{
      
    get()
    {
        Axios.get('http://localhost:5002/api/orders').then((response)=>
        {
           
    
				  
           localStorage.setItem(1, JSON.stringify(response.data));
            
        })
    }
    getCoffees()
    {
       Axios.get('http://localhost:5002/api/coffees').then((response)=>
        {
            
           localStorage.setItem(2,JSON.stringify(response.data))
           
           
        })
    }
   getClientName()
   {
    Axios.get('http://localhost:5002/api/clients').then((response)=>
    {
        
       localStorage.setItem(8,JSON.stringify(response.data))
       
       
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
        
         Axios.post(
            'http://localhost:5002/api/orders/',
            {   "ClientId" : body.ClientId,
                "StatusId" : 1,
                "Size" : body.Size,
                "CoffeeId" : body.CoffeeId },
            { headers: { 'Content-Type': 'application/json' },
            
            
         }
        );
        app.showOrders();
    }
   
}
export default axiosRequests;