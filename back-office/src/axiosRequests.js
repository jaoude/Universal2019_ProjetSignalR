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

}
export default axiosRequests;