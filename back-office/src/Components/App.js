import React from 'react';
import HttpClient from '../httpRequests';
import './App.css';

import axiosRequests from '../axiosRequests.js';
import * as signalR from '@aspnet/signalr';
import 'bootstrap/dist/css/bootstrap.min.css';




class App extends React.Component 
{

    httpClient = new HttpClient(); 
    axiosClient = new axiosRequests();

    
    showOrders()
    {
    
    
        this.axiosClient.get();

        var items = JSON.parse( localStorage[1])
        console.log(items);
    


        
      var div = document.getElementById("App");
      div.innerHTML="";

      var outertable = "<table class= 'table  table-dark table-bordered'>"+
      "<thead class='thead-dark'>"+
       " <tr>"+
       " <th scope=col>#</th>"+
       " <th scope=col>Client Id</th>"+
       " <th scope=col>Client Name</th>"+
         " <th scope=col>Coffee</th>"+
         " <th scope=col>Status</th>"+
       
      "  </tr>"+
     " </thead>"+
     "<tbody>";
      
    
      
      
   
        for (var i = 0 ; i<items.length ; i++)
        {
            
           
           
            var innerTable = " <tr id='item_"+items[i].id+"'>"+
            " <th>"+items[i].id+"</th>"+
            " <th>"+items[i].clientId+"</th>"+
            " <th>"+items[i].clientName+"</th>"+
         
                  "<th scope='row'>"+items[i].coffeeName+"</th>"+
                
               " <th>"+items[i].statusName+"</th>"+
              
            
            "</tr>";
            outertable+=innerTable
       

        }
        outertable +="</tbody>"+
           "</table>"
        div.innerHTML=outertable
       
    }

    
    componentDidMount = () =>
     {
        this.showOrders();
     

    

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

                <div id="App"></div>
                   
                   
                </header>
            </div>
           
        );
    }
  
  
    
  
}

export default App;