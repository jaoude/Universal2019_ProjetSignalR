import Axios from "axios";



class axiosRequests
{
   
    
    get()
    {
       

        Axios.get('http://localhost:5002/api/orders').then((response)=>
        {
           
      
				  
           localStorage.setItem(1, JSON.stringify(response.data));
            
        })
    }

}
export default axiosRequests;