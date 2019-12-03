import React from 'react';
import HttpClient from '../httpRequests';
import './App.css';
import coffee from '../Assets/coffee.jpg';
import axiosRequests from '../axiosRequests.js';
import * as signalR from '@aspnet/signalr';




class App extends React.Component 
{

    httpClient = new HttpClient(); 
    axiosClient = new axiosRequests();
    
    componentDidMount = () => {
     
       let  connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5002/chatHub")
    .build();
    /*
      
        this.setState({ connection, nick }, () => {
          this.state.connection
            .start()
            .then(() => console.log('Connection started!'))
            .catch(err => console.log('Error while establishing connection :('));
    
          this.state.connection.on('ReceiveMessage', (nick, receivedMessage) => {
            const text = `${nick}: ${receivedMessage}`;
            const messages = this.state.messages.concat([text]);
            this.setState({ messages });
          });
       */
      connection.on("ReceiveMessage", data => {
        alert('a')
  
    });
        
    }

 

    render() {
        return (
            
            <div className="App">
                <button className="MyOrders" style={{float: 'right'} } onClick={()=>this.showOrders()}>My Orders</button>
                <header className="App-header">
                    
                    <img className="Coffee-Logo" src={coffee} alt="logo" />
                    

                    <p>Choose your Coffee :</p>

                    <select id="Coffees" ref={ref => this.Coffees_Ref = ref}>
                        <option value="Espresso">Espresso</option>
                        <option value="Latte">Latte</option>
                        <option value="Americano">Americano</option>
                        <option value="Cappucino">Cappucino</option>
                    </select>

                    <p>Choose the size :</p>

                    <select id="Sizes">
                        <option value="XL">XL</option>
                        <option value="L">L</option>
                        <option value="M">M</option>
                        <option value="S">S</option>
                    </select>

                   

                    <button  onClick={()=>this.axiosClient.postOrder()} value ="Order">order</button>
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
     
      //this.axiosClient.getStatusById(1);

        
        
    
      
      
   
        for (var i = 0 ; i<items.length ; i++)
        {
            
            
            
            this.axiosClient.getCoffeeById(items[i].coffeeId);
            console.log('Coffee by Id :'+localStorage[2]);
            this.axiosClient.getStatusById(items[i].statusId);
            console.log('status by Id :'+localStorage[3]);

           



            var div = document.getElementById("orders");
            console.log(div)
            var coffee_p = document.createElement("p");
            coffee_p.innerHTML ="<p>"+localStorage[2]+"</p>";
            var status_p = document.createElement("p");
            status_p.innerHTML ="<p>"+localStorage[3]+"</p>";

            div.append(coffee_p);
            div.append(status_p)

        }
       
    }
  
    
    CreatePostBody()
    {
       
        var size =  document.getElementById("Sizes").options[document.getElementById("Sizes").options.selectedIndex].value;
       

    var coffee_id = document.getElementById("Coffees").options.selectedIndex;
    
    var obj = new Object();
   obj.CoffeeId = coffee_id+1;
   obj.ClientId = 1;
   obj.StatusId = 2;
   obj.Size = size;
   

   
   

    

    JSON.stringify(obj)
    console.log(obj)
   
   return obj;
 
 

        

    }
}

export default App;