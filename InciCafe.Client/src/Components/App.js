import React from 'react';

import './App.css';
import coffee from '../Assets/coffee.jpg';
import axiosRequests from '../axiosRequests.js';
import * as signalR from '@aspnet/signalr';
import 'bootstrap/dist/css/bootstrap.min.css';





class App extends React.Component 
{
    axiosClient = new axiosRequests();


    
    client = null;

   
    
    componentDidMount = () => {
        localStorage[4]  = prompt("Please Write Your Id : ");

        var clients= JSON.parse(localStorage[8])
        console.log(clients);
        console.log(this.IdOfTheUser)
      
     

        
       

        this.axiosClient.getCoffees();
        let data = JSON.parse(localStorage[2]);
        this.showOrders();
        var list = document.getElementById('Coffees');
        for (var i = 0 ; i < data.length;i++)
        {
          list.innerHTML+=   " <option value='"+data[i].id+"'>"+data[i].name+"</option>"
        }

let connection = new signalR.HubConnectionBuilder()
.configureLogging(signalR.LogLevel.Debug)
.withUrl("http://localhost:5002/ChatHub", {
  skipNegotiation: true,
  transport: signalR.HttpTransportType.WebSockets
})
.build();


connection.start()
  .then(() => console.log("connection started"));
connection.on("ReceiveMessage", data => {
    console.log(data);
  this.showOrders();
  
});
     
    }

 

    render() {
        return (
            
            
            <div className="App">
                <header className="App-header">
                    
                    <img className="Coffee-Logo" src={coffee} alt="logo" />
                    

                    <p>Choose your Coffee :</p>

                    <select id="Coffees">
                     
                    </select>

                    <p>Choose the size :</p>

                    <select id="Sizes">
                        <option value="XL">XL</option>
                        <option value="L">L</option>
                        <option value="M">M</option>
                        <option value="S">S</option>
                    </select>

                   

                    <button style={{marginTop: 10 + 'px'}} onClick={()=>this.axiosClient.postOrder()} value ="Order">order</button>
                    <br/>
                    <br/>
                    <div id="orders"></div>

                   
                   
                </header>
            </div>
           
        );
    }
    
    showOrders()
    {

    
    
        this.axiosClient.get();
     
        var items = JSON.parse( localStorage[1])
        console.log(items);
     
   


        
      var div = document.getElementById("orders");
      div.innerHTML="";

      var outertable = "<table style='margin-top : 10px' class='table table-dark table-bordered'>"+
      "<thead class='thead-dark'>"+
       " <tr>"+
       "<th scope=col>Client Name</th>"+
         " <th scope=col>Coffee</th>"+
         " <th scope=col>Status</th>"+
         "<th scope=col>Size</th>"+
       
      "  </tr>"+
     " </thead>"+
     "<tbody>";
      
    
      
      
   
        for (var i = 0 ; i<items.length ; i++)
        {
            
            
           if(parseInt(localStorage[4]) === items[i].clientId)
           {
           
            var innerTable = " <tr id='item_"+items[i].id+"'>"+
            "<th scope='row'>"+items[i].clientName +"</th>"+
                  "<th scope='row'>"+items[i].coffeeName+"</th>"+
                
               " <td>"+items[i].statusName+"</td>"+
               "<td>"+items[i].size+"</td>"+
              
            
            "</tr>";
            outertable+=innerTable
        }
         
        }
        outertable +="</tbody>"+
           "</table>"
        div.innerHTML=outertable
    
    }
  
    
    CreatePostBody()
    {
       
        var size =  document.getElementById("Sizes").options[document.getElementById("Sizes").options.selectedIndex].value;
       

    var coffee_id = document.getElementById("Coffees").options.selectedIndex;
    
    var obj = new Object();
   obj.CoffeeId = coffee_id+1;
   obj.ClientId = parseInt(localStorage[4])


   obj.StatusId = 1;
   obj.Size = size;
   

   
   

    

    JSON.stringify(obj)
    console.log(obj)
   
   return obj;
 
 

        

    }
}

export default App;