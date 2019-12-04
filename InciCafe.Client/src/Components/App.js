import React from 'react';
import HttpClient from '../httpRequests';
import './App.css';
import coffee from '../Assets/coffee.jpg';
import axiosRequests from '../axiosRequests.js';
import * as signalR from '@aspnet/signalr';
import 'bootstrap/dist/css/bootstrap.min.css';




class App extends React.Component 
{

    httpClient = new HttpClient(); 
    axiosClient = new axiosRequests();

    constructor(props)
    {
        super(props)
        // this.state=
        // {
        //     statusOrder : '',
        //     connection : null


        // };

    }
    
    componentDidMount = () => {
     

    

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
 
// connection.start()
//     .then(() => connection.invoke("ReceiveMessage"));
    //    const  connection = new HubConnection("http://localhost:5002/ChatHub","","");

    //    this.setState({connection},()=>{
    //        this.state.connection.start().then(()=> console.log('connection started'))
    //        .catch((err)=>console.log('error : '+err));
    //    });

    //    this.state.connection.on('ReceiveMessage',(message)=>{
    //        const statusOrder = message;
    //        this.setState({statusOrder});
    //    });
 
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
     
      //this.axiosClient.getStatusById(1);


        
      var div = document.getElementById("orders");
      div.innerHTML="";

      var outertable = "<table class= 'table  table-dark table-bordered'>"+
      "<thead class='thead-dark'>"+
       " <tr>"+
       
         " <th scope="+"col>Coffee</th>"+
         " <th scope="+"col>Status</th>"+
       
      "  </tr>"+
     " </thead>"+
     "<tbody>";
      
    
      
      
   
        for (var i = 0 ; i<items.length ; i++)
        {
            var innerTable = " <tr>"+
                  "<th scope=row>"+items[i].coffeeName+"</th>"+
                
               " <td>"+items[i].statusName+"</td>"+
              
            
            "</tr>";
            outertable+=innerTable
           
            
           /* this.axiosClient.getCoffeeById(items[i].coffeeId);
            console.log('Coffee by Id :'+localStorage[2]);
            this.axiosClient.getStatusById(items[i].statusId);
            console.log('status by Id :'+localStorage[3]);

           */




//     <tr>
//       <th scope="row">1</th>
//       <td>Mark</td>
//       <td>Otto</td>
//       <td>@mdo</td>
//     </tr>
//     <tr>
//       <th scope="row">2</th>
//       <td>Jacob</td>
//       <td>Thornton</td>
//       <td>@fat</td>
//     </tr>
//     <tr>
//       <th scope="row">3</th>
//       <td>Larry</td>
//       <td>the Bird</td>
//       <td>@twitter</td>
//     </tr>
//   </tbody>
// </table>
      
           
          
         
        /*    var coffee_p = document.createElement("p");
            coffee_p.innerHTML ="<p>"+items[i].coffeeName+"</p>";
            var status_p = document.createElement("p");
            status_p.innerHTML ="<p>"+items[i].statusName+"</p>";

            div.append(coffee_p);
            div.append(status_p)
*/
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
   obj.ClientId = 1;
   obj.StatusId = 1;
   obj.Size = size;
   

   
   

    

    JSON.stringify(obj)
    console.log(obj)
   
   return obj;
 
 

        

    }
}

export default App;